using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using BoardSDK;
using Serilizer;
using JLogging;

namespace BoardSys
{
    public class BoardSysIF
    {
        private static BoardSysIF _instance;

        public static BoardSysIF Instance => _instance ?? (_instance = new BoardSysIF());

        private Dictionary<string, BoardParam> _dictBoards;

        private Dictionary<string, DIParam> _dictDIsParam;

        private Dictionary<string, DOParam> _dictDOsParam;

        private readonly string ParamPath = AppDomain.CurrentDomain.BaseDirectory + "Config//BoardsParam.xml";

        public BoardSysIF()
        {
            _dictBoards = new Dictionary<string, BoardParam>();
            _dictDIsParam = new Dictionary<string, DIParam>();
            _dictDOsParam = new Dictionary<string, DOParam>();
            if (!File.Exists(ParamPath))
                return;
            BoardParam[] boardsParam = XMLSerializer.Deserialize<BoardParam[]>(ParamPath);
            foreach (BoardParam boardParam in boardsParam)
            {
                foreach (DIParam param in boardParam.DIsParam)
                {
                    param.BoardID = boardParam.ID;
                    _dictDIsParam.Add(param.Name, param);
                }
                foreach (DOParam param in boardParam.DOsParam)
                {
                    param.BoardID = boardParam.ID;
                    _dictDOsParam.Add(param.Name, param);
                }
                IBoard board = BoardFactory.CreateBoard(boardParam.Type);
                boardParam.Board = board;
                _dictBoards.Add(boardParam.ID, boardParam);
            }
        }

        ~BoardSysIF()
        {
            SaveParam();
        }

        public bool Init(out string msg)
        {
            bool ret = true;
            msg = "";
            foreach (BoardParam boardParam in _dictBoards.Values)
            {
                if (CheckConnect(boardParam.ID))
                {
                    msg += $"板卡{boardParam.ID}初始化成功；";
                    continue;
                }
                if (!Connect(boardParam.ID))
                {
                    ret &= false;
                    msg += $"板卡{boardParam.ID}初始化失败；";
                    continue;
                }
                if (boardParam.AxesParam != null)
                {
                    foreach (AxisParam axis in boardParam.AxesParam)
                        boardParam.Board.Stop(axis.Index);
                }
                msg += $"板卡{boardParam.ID}初始化成功；";
            }
            return ret;
        }

        public bool Connect(string boardID)
        {
            try
            {
                if (!_dictBoards.ContainsKey(boardID) || _dictBoards[boardID].Board == null)
                    return false;
                string cardPath = $"{AppDomain.CurrentDomain.BaseDirectory}Config\\{boardID}.cfg";
                if (!File.Exists(cardPath))
                {
                    LoggingIF.Log($"未能找到板卡{boardID}的配置文件", LogLevels.Error);
                    return false;
                }
                if (!_dictBoards[boardID].Board.Connect(cardPath))
                {
                    LoggingIF.Log($"板卡{boardID}连接失败，请检查配置文件是否有误", LogLevels.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LoggingIF.Log(ex.Message);
                return false;
            }
        }

        public bool DisConnect(string boardID)
        {
            if (!_dictBoards.ContainsKey(boardID) || _dictBoards[boardID].Board == null)
                return false;
            return _dictBoards[boardID].Board.Disconnect();
        }

        public bool CheckConnect(string boardID)
        {
            if (_dictBoards == null || !_dictBoards.TryGetValue(boardID, out BoardParam param))
                return false;
            return param.Board.CheckConnect();
        }

        public void JogMove(string boardID, int axisIdx, bool isPositive, double speed = -1)
        {
            if (!CheckConnect(boardID))
                return;
            BoardParam boardParam = _dictBoards[boardID];
            AxisParam axisParam = boardParam.AxesParam[axisIdx];
            isPositive = axisParam.MoveDir == 0 ? isPositive : !isPositive;
            boardParam.Board.JogMove(axisIdx, isPositive, axisParam.MoveVelLPluse, speed == -1 ? axisParam.MoveVelHPluse : speed * axisParam.PlusePerMM, axisParam.MoveAccPluse, axisParam.MoveDccPluse);
        }

        public void StopMove(string boardID, int axisIdx)
        {
            if (!CheckConnect(boardID))
                return;
            BoardParam boardParam = _dictBoards[boardID];
            boardParam.Board.Stop(axisIdx);
        }

        public void GoHome(string boardID, int axisIdx)
        {
            if (!CheckConnect(boardID))
                return;
            BoardParam boardParam = _dictBoards[boardID];
            AxisParam axisParam = boardParam.AxesParam[axisIdx];
            boardParam.Board.GoHome(axisIdx, axisParam.HomeVelLPluse, axisParam.HomeVelHPluse, axisParam.HomeAccPluse, axisParam.HomeDccPluse, axisParam.HomeMode, axisParam.HomeDir);
        }

        public void RelMove(string boardID, int axisIdx, double dist, double speed = -1)
        {
            if (!CheckConnect(boardID))
                return;
            BoardParam boardParam = _dictBoards[boardID];
            if (boardParam.AxesParam == null) return;
            AxisParam axisParam = boardParam.AxesParam[axisIdx];
            boardParam.Board.RelMove(axisIdx, axisParam.MoveVelLPluse, speed == -1 ? axisParam.MoveVelHPluse : speed * axisParam.PlusePerMM, axisParam.MoveAccPluse, axisParam.MoveDccPluse, dist * axisParam.PlusePerMM);
        }

        public void AbsMove(string boardID, int axisIdx, double pos, double speed = -1)
        {
            if (!CheckConnect(boardID) || double.IsNaN(pos))
                return;
            BoardParam boardParam = _dictBoards[boardID];
            AxisParam axisParam = boardParam.AxesParam[axisIdx];
            boardParam.Board.AbsMove(axisIdx, axisParam.MoveVelLPluse, speed == -1 ? axisParam.MoveVelHPluse : speed * axisParam.PlusePerMM, axisParam.MoveAccPluse, axisParam.MoveDccPluse, pos * axisParam.PlusePerMM);
        }

        public bool CheckIsStop(string boardID, int axisIdx)
        {
            BoardParam boardParam = _dictBoards[boardID];
            return boardParam.Board.CheckIsStop(axisIdx);
        }

        public byte GetAxisState(string boardID, int axisIdx)
        {
            if (!CheckConnect(boardID))
                return 0;
            BoardParam boardParam = _dictBoards[boardID];
            return boardParam.Board.GetAxisState(axisIdx);
        }

        public double GetActPos(string boardID, int axisIdx)
        {
            if (!CheckConnect(boardID))
                return 0.0;
            BoardParam boardParam = _dictBoards[boardID];
            if (boardParam.AxesParam == null) return 0.0;
            AxisParam axisParam = boardParam.AxesParam[axisIdx];
            return boardParam.Board.GetActPos(axisIdx) / axisParam.PlusePerMM;
        }

        public double GetCmdPos(string boardID, int axisIdx)
        {
            if (!CheckConnect(boardID))
                return 0.0;
            BoardParam boardParam = _dictBoards[boardID];
            if (boardParam.AxesParam == null) return 0.0;
            AxisParam axisParam = boardParam.AxesParam[axisIdx];
            return boardParam.Board.GetCmdPos(axisIdx) / axisParam.PlusePerMM;
        }

        public bool GetAxisServoEnabled(string boardID, int axisIdx)
        {
            if (!CheckConnect(boardID))
                return false;
            BoardParam boardParam = _dictBoards[boardID];
            return boardParam.Board.GetAxisServoEnabled(axisIdx);
        }

        public void SetAxisServoEnabled(string boardID, int axisIdx, bool isOn)
        {
            if (!CheckConnect(boardID))
                return;
            BoardParam boardParam = _dictBoards[boardID];
            boardParam.Board.SetAxisServoEnabled(axisIdx, isOn);
        }

        public AxisParam GetAxisParam(string boardID, int axisIdx)
        {
            if (_dictBoards == null || !_dictBoards.TryGetValue(boardID, out BoardParam param))
                return null;
            BoardParam boardParam = _dictBoards[boardID];
            return boardParam.AxesParam[axisIdx];
        }

        public void SetOut(string DOName, bool value)
        {
            if (_dictDOsParam == null || !_dictDOsParam.TryGetValue(DOName, out DOParam param))
            {
                LoggingIF.Log($"未能找到名称{DOName}", LogLevels.Error);
                return;
            }
            if (!CheckConnect(param.BoardID))
                return;
            BoardParam boardParam = _dictBoards[param.BoardID];
            boardParam.Board.SetOut(param.AxisIndex, param.PointIndex, value);
        }

        public bool GetOut(string DOName)
        {
            if (_dictDOsParam == null || !_dictDOsParam.TryGetValue(DOName, out DOParam param))
            {
                LoggingIF.Log($"未能找到名称{DOName}", LogLevels.Error);
                return false;
            }
            if (!CheckConnect(param.BoardID))
                return false;
            BoardParam boardParam = _dictBoards[param.BoardID];
            return boardParam.Board.GetOut(param.AxisIndex, param.PointIndex);
        }

        public bool GetIn(string DIName)
        {
            if (_dictDIsParam == null || !_dictDIsParam.TryGetValue(DIName, out DIParam param))
            {
                LoggingIF.Log($"未能找到名称{DIName}", LogLevels.Error);
                return false;
            }
            if (!CheckConnect(param.BoardID))
                return false;
            BoardParam boardParam = _dictBoards[param.BoardID];
            return boardParam.Board.GetIn(param.AxisIndex, param.PointIndex);
        }

        public string[] GetInNames()
        {
            return _dictDIsParam.Keys.ToArray();
        }

        public string[] GetOutNames()
        {
            return _dictDOsParam.Keys.ToArray();
        }

        public bool SaveParam()
        {
            try
            {
                XMLSerializer.Serialize(_dictBoards.Values.ToArray(), ParamPath);
                return true;
            }
            catch (Exception ex)
            {
                LoggingIF.Log("序列化失败" + ex.Message);
                return false;
            }
        }
    }
}
