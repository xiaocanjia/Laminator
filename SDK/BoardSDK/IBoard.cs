namespace BoardSDK
{
    /// <summary>
    /// 板卡接口
    /// </summary>
    public interface IBoard
    {
        #region 初始化
        /// <summary>
        /// 连接板卡
        /// </summary>
        /// <returns></returns>
        bool Connect(string filePath);

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns></returns>
        bool Disconnect();

        /// <summary>
        /// 检测是否连接
        /// </summary>
        /// <returns></returns>
        bool CheckConnect();
        #endregion

        #region IO

        /// <summary>
        /// 设置输出
        /// </summary>
        /// <param name="IOIdx">轴序号</param>
        /// <param name="IOIdx">IO序号</param>
        /// <param name="Value"></param>
        /// <returns>是否设置成功</returns>
        bool SetOut(int axisIdx, int IOIdx, bool Value);

        /// <summary>
        /// 获取指定位输出值
        /// </summary>
        /// <param name="IOIdx">轴序号</param>
        /// <param name="IOIdx">IO序号</param>
        /// <returns></returns>
        bool GetOut(int axisIdx, int IOIdx);

        /// <summary>
        /// 获取输入口值
        /// </summary>
        /// <param name="IOIdx">轴序号</param>
        /// <param name="IOIdx">IO序号</param>
        /// <returns></returns>
        bool GetIn(int axisIdx, int IOIdx);

        #endregion

        #region 轴控
        /// <summary>
        /// 清除轴的报警信号
        /// </summary>
        /// <param name="axisCount">轴号</param>
        bool ClearAlarm(int axis);

        /// <summary>
        /// 获取指定轴的使能状态
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>是否使能</returns>
        bool GetAxisServoEnabled(int axis);

        /// <summary>
        /// 指定轴使能
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <param name="isOn"></param>
        /// <returns>返回值:0成功</returns>
        bool SetAxisServoEnabled(int axis, bool isOn);

        /// <summary>
        /// 回原点
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="homeVelL"></param>
        /// <param name="homeVelH"></param>
        /// <param name="homeAcc"></param>
        /// <param name="homeDcc"></param>
        /// <param name="homeMode"></param>
        /// <param name="homeDir"></param>
        /// <returns></returns>
        bool GoHome(int axis, double homeVelL, double homeVelH, double homeAcc, double homeDcc, uint homeMode, uint homeDir);

        /// <summary>
        /// 检查当前轴是否停止
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        bool CheckIsStop(int axis);

        /// <summary>
        /// 获取指定轴的运动状态
        /// </summary>
        /// <param name="axis"></param>
        /// <returns>0-驱动器报警,1-正限位,2-负限位,3-原点,4-急停</returns>
        byte GetAxisState(int axis);

        /// <summary>
        /// 获取指定轴的实际位置
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>位置</returns>
        double GetActPos(int axis);

        /// <summary>
        /// 获取指定轴的命令位置
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>位置</returns>
        double GetCmdPos(int axis);

        /// <summary>
        /// 以绝对位置做点位运动
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="moveVelL"></param>
        /// <param name="moveVelH"></param>
        /// <param name="moveAcc"></param>
        /// <param name="moveDcc"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        bool AbsMove(int axis, double moveVelL, double moveVelH, double moveAcc, double moveDcc, double pos);

        /// <summary>
        /// 相对运动
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="moveVelL"></param>
        /// <param name="moveVelH"></param>
        /// <param name="moveAcc"></param>
        /// <param name="moveDcc"></param>
        /// <param name="dist"></param>
        /// <returns></returns>
        bool RelMove(int axis, double moveVelL, double moveVelH, double moveAcc, double moveDcc, double dist);

        /// <summary>
        /// Jog运动
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="isPositive"></param>
        /// <param name="moveVelL"></param>
        /// <param name="moveVelH"></param>
        /// <param name="moveAcc"></param>
        /// <param name="moveDcc"></param>
        /// <returns></returns>
        bool JogMove(int axis, bool isPositive, double moveVelL, double moveVelH, double moveAcc, double moveDcc);

        /// <summary>
        /// 指定轴停止
        /// </summary>
        /// <returns></returns>
        bool Stop(int axis);

        /// <summary>
        /// 紧急停止
        /// </summary>
        /// <returns></returns>
        bool InstancyStop(int axis);

        #endregion
    }
}
