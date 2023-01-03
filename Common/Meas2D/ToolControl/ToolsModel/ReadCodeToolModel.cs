using System;
using HalconDotNet;
using MeasResult;
using Vision2D;

namespace Meas2D
{
    public class ReadCodeToolModel : Tool2DBaseModel
    {
        public Shape2DRect ROI;

        public string Code;

        public string CodeType = "Data Matrix ECC 200";

        private HDataCode2D _codeModel;

        public ReadCodeToolModel()
        {
            NormalView = new MinimizedView(this);
            Type = ETool2DType.READCODE;
            ROI = new Shape2DRect() { Color = "blue" };
        }

        public override void InitShape()
        {
            ROI.IsEditable = false;
            OnAddShape?.Invoke(ROI);
            ROI.OnMoved += UpdateResult;
            ROI.OnMoved += UpdateShape;
            OnRepaint?.Invoke();
            CreateModel();
            if (Results != null)
                return;
            Results = new MesResult[1];
            Results[0] = new MesResult(Name, "二维码", "") { HasLimit = false };
        }

        public void CreateModel()
        {
            _codeModel = new HDataCode2D(CodeType, "default_parameters", "standard_recognition");
        }

        public override void UpdateResult()
        {
            try
            {
                Results[0].Result = "无";
                if (_image == null)
                    goto UpdateValue;
                _image.GetImageSize(out int w, out int h);
                _image = _image.Clone();
                HImage imgReduced = _image.ReduceDomain(ROI.GetRegion());
                _codeModel.FindDataCode2d(imgReduced, new HTuple(), new HTuple(), out HTuple result, out HTuple code);
                Code = code.Length > 0 ? code.ToSArr()[0] : "无";
                Results[0].Result = Code;
                UpdateValue:
                OnUpdateValue?.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void UpdateShape()
        {
            try
            {
                if (_image == null)
                    return;
                OnRepaint();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void OpenSetupView()
        {
            SetupView = new ReadCodeToolView(this);
            ROI.IsEditable = true;
            OnRepaint?.Invoke();
            base.OpenSetupView();
        }

        public override void CloseSetupView()
        {
            ROI.IsEditable = false;
            OnRepaint?.Invoke();
            base.CloseSetupView();
        }

        public override void DeleteTool()
        {
            OnRemoveShape?.Invoke(ROI);
            OnRepaint();
            base.DeleteTool();
        }
    }
}
