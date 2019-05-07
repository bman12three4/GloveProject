using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;
using System.Threading.Tasks;

using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

public class ManualControl : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-Vector3.right * xScale * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * xScale * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * zScale * Time.deltaTime);
        else if (Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * zScale * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.up * yScale * Time.deltaTime);
        else if (Input.GetKey(KeyCode.E))
            transform.Translate(-Vector3.up * yScale * Time.deltaTime);

        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(5, 3, -5);
        }
    }
}
