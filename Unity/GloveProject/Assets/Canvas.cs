using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;
using System.Threading.Tasks;

using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

using ProtoTurtle.BitmapDrawing;

public class Canvas : MonoBehaviour
{

    Texture2D texture;

    NamedPipeClientStream client;

    StreamReader reader;

    int size = 5;


    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(300, 300, TextureFormat.RGB24, false);
        this.GetComponent<MeshRenderer>().material.mainTexture = texture;
        texture.wrapMode = TextureWrapMode.Clamp;

        client = new NamedPipeClientStream(".", "/tmp/canvas", PipeDirection.In);
        client.Connect();
        reader = new StreamReader(client);
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log("Running Update");

        string line = reader.ReadLine();
        if (line != null)
        {

            String[] values = line.Split(',');

            if (float.Parse(values[1]) < 50)
            {
                //UnityEngine.Debug.Log("first");
                size = 5;

                if (float.Parse(values[4]) < 50)
                {
                    //UnityEngine.Debug.Log("second");
                    size = 10;

                    if (float.Parse(values[7]) < 50)
                    {
                        //UnityEngine.Debug.Log("third");
                        size = 15;
                    }
                }
            } else {
                size = 0;
            }
            UnityEngine.Debug.Log(size);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name != "Color Wheel")
        {
            texture.DrawFilledCircle(150 - ((int)other.transform.position.x), 150 - ((int)other.transform.position.y), size, other.gameObject.GetComponent<Renderer>().material.color);
            texture.Apply();
        }
    }
}
