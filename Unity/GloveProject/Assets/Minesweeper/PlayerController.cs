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

    public bool clear = false;
    public bool flag = false;

    public float xScale = .5f;
    public float yScale = .5f;
    public float zScale = .5f;

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


            if (float.Parse(values[1]) < 50)// if the first finger is out
            {
                if (float.Parse(values[4]) < 50 && float.Parse(values[7]) < 50) // if the second and third fingers are also out
                {
                    clear = false;
                    flag = false;
                } else {
                    clear = false;
                    flag = true;
                }
            } else {
                if (float.Parse(values[4]) > 50 && float.Parse(values[7]) > 50) // if the second and third fingers are also out
                {
                    clear = true;
                    flag = false;
                }
            }


        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(5, 3, -5);
        }
    }
}
