using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileTestController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string[] lines = System.IO.File.ReadAllLines("/home/byron/Desktop/GloveProject/GloveProject/adc.txt");
        Debug.Log(lines[0]);

        transform.eulerAngles = new Vector3(float.Parse(lines[0]), 0, 0);
        //transform.eulerAngles = new Vector3(90, 0, 0);

    }
}
