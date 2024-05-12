using UnityEngine;
using System.Diagnostics;
using System.IO;
using System.Text;
using UnityEditor;
public class ActivatePy : MonoBehaviour
{   
   /* void Start()
    {
        RunPythonScript();
    }
   */
    public void RunPythonScript()
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "python"; // Python 실행 파일
        start.Arguments = Path.Combine(Application.dataPath,"Resources","test.py"); // 파이썬 스크립트-
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.RedirectStandardError = true;
        start.StandardOutputEncoding = Encoding.UTF8;
        
        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                UnityEngine.Debug.Log(result);
              //  AssetDatabase.Refresh();
            }
        }
        
    }

}