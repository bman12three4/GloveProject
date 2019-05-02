using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;
using System.Threading.Tasks;

using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

public class PlayerController : MonoBehaviour
{

    NamedPipeClientStream client;

    bool clear = false;
    bool flag = false;

    float xScale = 1.5f;
    float yScale = 1.5f;
    float zScale = 1.5f;

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

            transform.Translate((-float.Parse(values[16])) * xScale, float.Parse(values[17]) * yScale, float.Parse(values[18]) * zScale);

            if (float.Parse(values[1]) < 50)
            {
                if (float.Parse(values[4]) < 50 && float.Parse(values[7]) < 50)
                {
                    clear = true;
                    flag = false;
                }
                else
                {
                    clear = false;
                    flag = true;
                }
            }
            else
            {
                clear = false;
                flag = false;
            }


        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
