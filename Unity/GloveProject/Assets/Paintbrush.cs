using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintbrush : MonoBehaviour
{

    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        float x = transform.position.x;
        float y = transform.position.y;

        Debug.Log("\n\nDATA");
        float angle = Mathf.Atan(-y/x);
        Debug.Log(angle);


        if (x >= 0 && y > 0){
            angle = Mathf.PI + angle;
        }

        if (y <= 0 && x > 0){
            angle = Mathf.PI + angle;
        }

        if (y <= 0 && x <= 0){
            angle = 2*Mathf.PI + angle;
        }

        Debug.Log(angle);

        float hue = angle / (2*Mathf.PI);

        float sat = Mathf.Sqrt(x*x + y*y)/25;

        renderer.material.color = Color.HSVToRGB(hue, sat, 1f);
        //renderer.material.color = Color.HSVToRGB(.5f, 1f, 1f);
        
        Debug.Log(hue);
        Debug.Log(sat);
    }
}
