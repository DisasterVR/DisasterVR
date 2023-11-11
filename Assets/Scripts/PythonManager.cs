using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;

public class PythonManager : MonoBehaviour
{
    //private const string PythonAppName = "python/3DBodyTracking.exe"; // Ruta relativa dentro de StreamingAssets
   
    //private static Process PythonProcess;
   
    //[RuntimeInitializeOnLoadMethod]
    //private static void RunOnStart()
    //{
    //    UnityEngine.Debug.Log(Application.dataPath + PythonAppName);

    //    ProcessStartInfo PythonInfo = new ProcessStartInfo();
    //    PythonInfo.FileName = Application.dataPath + PythonAppName;
    //    PythonInfo.WindowStyle = ProcessWindowStyle.Hidden;
    //    PythonInfo.CreateNoWindow = true;

    //    PythonProcess = Process.Start(PythonInfo);

    //    Application.quitting += () =>
    //        { if (!PythonProcess.HasExited) PythonProcess.Kill(); };
    //}
}