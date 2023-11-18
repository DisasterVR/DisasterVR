using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;

public class PythonManager2 : MonoBehaviour
{
    private const string PythonAppName = "Python/CVZONE_2/CVZONE_2.exe"; // Ruta relativa dentro de StreamingAssets

    private static Process PythonProcess;

    [RuntimeInitializeOnLoadMethod]
    private static void RunOnStart()
    {
        string pythonAppPath = System.IO.Path.Combine(Application.streamingAssetsPath, PythonAppName);
        UnityEngine.Debug.Log(pythonAppPath);

        ProcessStartInfo PythonInfo = new ProcessStartInfo();
        PythonInfo.FileName = pythonAppPath;
        PythonInfo.WindowStyle = ProcessWindowStyle.Hidden;
        PythonInfo.CreateNoWindow = true;

        PythonProcess = Process.Start(PythonInfo);

        Application.quitting += () =>
        { if (!PythonProcess.HasExited) PythonProcess.Kill(); };
    }
}