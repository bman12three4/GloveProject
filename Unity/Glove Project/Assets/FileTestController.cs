using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

public class FileTestController : MonoBehaviour
{

    //public int channel = 0;
    NamedPipeClientStream client;

    StreamReader reader;

    // Start is called before the first frame update
    void Start()
    {
        client =  new NamedPipeClientStream(".", "/home/byron/Desktop/GloveProject/GloveProject/pipe_test", PipeDirection.In);
        client.Connect();
        reader = new StreamReader(client);
    }

    // Update is called once per frame
    void Update()
    {
        string line = reader.ReadLine();

        if (line != null){
            String[] values = line.Split(',');
            Debug.Log(values[0]);
            transform.eulerAngles = new Vector3(float.Parse(values[0]), 0, 0);
            this.gameObject.transform.GetChild(0).transform.eulerAngles = new Vector3(float.Parse(values[1]), 0, 0);
        }


    }
}
