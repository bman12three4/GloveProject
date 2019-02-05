using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

public class FileTestController : MonoBehaviour
{
    NamedPipeClientStream client;

    StreamReader reader;

    // Start is called before the first frame update
    void Start()
    {
        client =  new NamedPipeClientStream(".", "/tmp/glove", PipeDirection.In);
        client.Connect();
        reader = new StreamReader(client);

    }

    // Update is called once per frame
    void Update()
    {
        string line = reader.ReadLine();

        if (line != null){
            String[] values = line.Split(',');
            //Debug.Log(values[0]);

            this.gameObject.transform.GetChild(0).localEulerAngles = new Vector3(float.Parse(90+values[0]), 0, 0);
            this.gameObject.transform.GetChild(0).GetChild(0).localEulerAngles = new Vector3(float.Parse(values[1]), 0, 0);
            this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).localEulerAngles = new Vector3(float.Parse(values[2]), 0, 0);
            
        }


    }
}
