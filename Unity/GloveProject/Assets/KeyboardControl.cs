using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControl : MonoBehaviour
{

    float RotateSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //w-s is x axis
        //q-e is z axis
        //a-d is y axis

        if (Input.GetKey(KeyCode.W))
            transform.Rotate(-Vector3.right * RotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.S))
            transform.Rotate(Vector3.right * RotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.E))
            transform.Rotate(-Vector3.forward * RotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);



    }
}
