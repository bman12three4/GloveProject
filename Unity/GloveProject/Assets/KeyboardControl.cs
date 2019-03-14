using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControl : MonoBehaviour
{

    float MoveSpeed = 30f;

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

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-Vector3.right * MoveSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * MoveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.E))
            transform.Translate(-Vector3.up * MoveSpeed * Time.deltaTime);



    }
}
