using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.IO.Pipes;

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
        Debug.Log(line);

        transform.eulerAngles = new Vector3(float.Parse(line), 0, 0);

    }
}
