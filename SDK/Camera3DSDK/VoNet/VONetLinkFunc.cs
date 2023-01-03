//----------------------------------------------------------------------------- 
// <copyright file="VONetLinkFunc.cs" company="O-NET">
//	 Copyright (c) 2020 O-NET.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 


/*本文件仅引入了SDK部分常用的接口函数，全部的接口函数定义请见vonet_lp3000.h，若需使用到其他接口函数，可按照格式自行添加*/


using System;
using System.Runtime.InteropServices;

namespace Camera3DSDK
{
    internal class VONetLinkFunc                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
    {
        /***************************************************************
        *    brief VONET_EthernetOpen   通信连接.
        *    param local_ip  [IN]       本地ip地址,如无特殊要求可赋值为"0.0.0.0"
        *    param device_ip [IN]       设备ip地址.
        *    return:       <0:          失败.
        *                   0:          成功.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_EthernetOpen(string local_ip, string device_ip);


        /***************************************************************
        *    brief VONET_CommClose      断开与相机的连接.
        *    return:       <0:          失败.
        *                   0:          成功.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_CommClose();


        /***************************************************************
        *    brief VONET_GetVersion         获取sdk版本号.
        *    return:                        sdk版本号
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern IntPtr VONET_GetVersion();


        /***************************************************************
        *    brief VONET_GetModels          获取相机型号.
        *    return:                        相机型号
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern IntPtr VONET_GetModels();

        /***************************************************************
        *    brief VONET_ProfilePointGetCount      当前批处理设定行数.
        *    return:       <0:                     失败.
        *                 其他:                     实际批处理设定行数.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_ProfilePointGetCount();


        /***************************************************************
        *    brief VONET_ProfileDataWidth   获取批处理数据宽度.
        *    return:        返回x方向上像素点数
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_ProfileDataWidth();


        /***************************************************************
        *    brief VONET_StartMeasure       开始批处理,立即执行批处理程序.
        *    param Timeout  [IN]            非循环获取时，超时时间(单位ms).
        *    return:       <0:              失败.
        *                   0:              成功.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_StartMeasure(int Timeout = 50000);


        /***************************************************************
        *    brief VONET_StartIOTriggerMeasure       开始批处理,硬件IO触发开始批处理，具体查看硬件手册.
        *    param Timeout  [IN]                    非循环获取时，超时时间(单位ms).
        *    return:       <0:                      失败.
        *                   0:                      成功.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_StartIOTriggerMeasure(int Timeout = 50000, int Restart = 0);


        /***************************************************************
        *    brief VONET_StopMeasure      停止批处理.
        *    return:       <0:            失败.
        *                   0:            成功.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_StopMeasure();


        /***************************************************************
        *    brief VONET_GetBatchProfile        非阻塞式批处理获取轮廓线数据
        *    param count            [IN]        每次获取轮廓线和亮度线的条数
        *    param profile          [OUT]       轮廓线数据缓存
        *    param intensity        [OUT]       亮度图数据缓存
        *    return:         <0:                失败.
        *                 其他值:                返回实际获取到的轮廓线和亮度线的条数.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_GetBatchProfile(uint count, float[] center, byte[] light);    //参数的转换形式待定


        /***************************************************************
        *    brief VONET_GetBatchProfileBlock   阻塞式批处理获取轮廓线数据
        *    param profile          [OUT]       轮廓线数据缓存
        *    param intensity        [OUT]       亮度图数据缓存
        *    return:         <0:                失败.
        *                 其他值:                返回实际获取到的轮廓线和亮度线的条数.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_GetBatchProfileBlock(float[] profile, byte[] intensity);


        /***************************************************************
        *    brief VONET_GetBatchRollData       无限循环批处理获取轮廓线数据
        *    param count            [IN]        每次获取轮廓线和亮度线的条数
        *    param profile          [OUT]       轮廓线数据缓存
        *    param intensity        [OUT]       亮度图数据缓存
        *    param frameLoss        [OUT]       批处理过快掉帧数量数据指针，不需要赋值为NULL
        *    return:         <0:                失败.
        *                 其他值:                返回实际获取到的轮廓线和亮度线的条数.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_GetBatchRollData(uint count, float[] profile, byte[] intensity, uint[] frameLoss);

        /***************************************************************
        *    brief VONET_ChangeActiveProgram       切换相机活动程序编号.
        *    param prog_no  [IN]                   工程号.
        *    return:       <0:                     失败.
        *                   0:                     成功.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_ChangeActiveProgram(uint prog_no);

        /***************************************************************
        *    brief VONET_GetActiveProgram          获取活动程序编号.
        *    return:       <0:                     失败.
        *                 其他:                     当前程序活动编号.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern int VONET_GetActiveProgram();


        /***************************************************************
        *    brief VONET_ExportParameters   将系统参数导出，注意只导出当前任务的参数.
        *    param size          [OUT]      返回参数表的大小
        *    return:        NULL            失败.
        *                   其他:            成功.
        ****************************************************************/
        [DllImport("vonet_sdk.dll")]
        internal static extern IntPtr VONET_ExportParameters(uint[] size);


        /***************************************************************
          *    brief VONET_LoadParameters     将导出的参数导入到系统中.
          *    param size          [IN]       导入参数表的大小
          *    param pSettingdata  [IN]       导入参数表指针
          *    return:        <0:             失败.
          *                   =0:             成功.
          ****************************************************************/
       [DllImport("vonet_sdk.dll")]
       internal static extern int VONET_LoadParameters(byte[] pSettingdata, uint size);




        /***************************************************************
        *    brief cloudShow       显示批处理后的三维点云
        *    param batchData            [IN]        高度数据
        *    param xTrueStep          [IN]       x方向点间距
        *    param yTrueStep        [IN]       y方向点间距
        *    param xPointNum        [IN]       x方向点数
        *    param yBatchpointNum        [IN]       扫描行数
        *    param zMin        [IN]       高度显示下限
        *    param zMax        [IN]       高度显示上限
        *    return:        
        ****************************************************************/
        [DllImport("CloudShowDll.dll")]
        internal static extern int cloudShow(float[] batchData,
        double xTrueStep,
        double yTrueStep,
        int xPointNum,
        int yBatchpointNum,
        double zMin,
        double zMax);
    }
}
