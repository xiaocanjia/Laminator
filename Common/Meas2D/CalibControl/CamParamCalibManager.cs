using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Meas2D.CalibControl
{
    /// <summary>
    /// 相机内外参标定
    /// </summary>
    public class CamParamCalibManager
    {
        [XmlIgnore]
        public HCamPar CamPar;

        public double[] CamParRawData;

        [XmlIgnore]
        public HPose CamPose;

        public double[] CamPoseRawData;

        public CamParamCalibManager()
        {

        }

        public void Init()
        {
            CamPar = new HCamPar(new HTuple(CamParRawData));
            CamPose = new HPose(new HTuple(CamPoseRawData));
        }

        public void EnableCalib(List<string> imagesPath)
        {

        }
    }
}
