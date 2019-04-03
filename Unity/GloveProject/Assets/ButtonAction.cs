using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{

    bool red = false;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.green);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (red)
        {
            //Fetch the Renderer from the GameObject
            Renderer rend = GetComponent<Renderer>();

            //Set the main Color of the Material to green
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.green);

            //Find the Specular shader and change its Color to red
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.green);

            red = false;
        }
        else
        {
            Renderer rend = GetComponent<Renderer>();

            //Set the main Color of the Material to green
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.red);

            //Find the Specular shader and change its Color to red
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.red);

            red = true;
        }
    }
}
