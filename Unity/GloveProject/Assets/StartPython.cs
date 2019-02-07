using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;
using System.Threading.Tasks;

public class StartPython : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "/usr/bin/python";

        string path = Application.dataPath + "/Python/main.py";

        UnityEngine.Debug.Log(path);

        //start.Arguments = string.Format("{0} {1}", "/Users/byron.lathi/Desktop/School/GloveProject/GloveProject/Python/main.py", "");
        start.Arguments = string.Format("{0} {1}", path, "");
        start.UseShellExecute = true;
        start.UseShellExecute = true;
        start.RedirectStandardOutput = false;
        Process.Start(start);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
