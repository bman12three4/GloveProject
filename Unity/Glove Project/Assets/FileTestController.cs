﻿using System.Collections;
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


/*


    2 5 8 11
    1 4 7 10
    0 3 6 9
  13
  12
 */


    // Update is called once per frame
    void Update()
    {
        string line = reader.ReadLine();

        if (line != null){
            String[] values = line.Split(',');

            for (int i = 0; i < this.gameObject.transform.childCount; i++){
                this.gameObject.transform.GetChild(i).localEulerAngles = new Vector3(90 + float.Parse(values[3*i]), 0, 0);
                this.gameObject.transform.GetChild(i).GetChild(0).localEulerAngles = new Vector3(float.Parse(values[3*i + 1]), 0, 0);
                if (i <4)
                    this.gameObject.transform.GetChild(i).GetChild(0).GetChild(0).localEulerAngles = new Vector3(float.Parse(values[3*i +2]), 0, 0);
            }

        }

    }
}
