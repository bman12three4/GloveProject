using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWheel : MonoBehaviour
{

    bool visible = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            visible = !visible;

            if (visible){
               transform.position = new Vector3(0F, 0F, -15.0F);
            } else {
                transform.position = new Vector3(0F, 0F, -55.0F);
            }
        }
    }
}
