﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;
using System.Threading.Tasks;

using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

public class PaintbrushController : MonoBehaviour
{

    NamedPipeClientStream client;

    StreamReader reader;

    // Start is called before the first frame update
    void Start()
    {
        client = new NamedPipeClientStream(".", "/tmp/glove", PipeDirection.In);
        client.Connect();
        reader = new StreamReader(client);
    }

    // Update is called once per frame
    void Update()
    {
        string line = reader.ReadLine();

        if (line != null)
        {
            String[] values = line.Split(',');

            transform.Translate((-float.Parse(values[16])) / 1.5f, float.Parse(values[17]) / 1.5f, float.Parse(values[18]) / 1.5f);

        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(0, 0, 5);
        }
    }
}
