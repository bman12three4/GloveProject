using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProtoTurtle.BitmapDrawing;

public class Canvas : MonoBehaviour
{

    Texture2D texture;


    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(300, 300, TextureFormat.RGB24, false);
        this.GetComponent<MeshRenderer>().material.mainTexture = texture;
        texture.wrapMode = TextureWrapMode.Clamp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name != "Color Wheel")
        {
            texture.DrawFilledCircle(150 - ((int)other.transform.position.x), 150 - ((int)other.transform.position.y), 5, other.gameObject.GetComponent<Renderer>().material.color);
            texture.Apply();
        }
    }
}
