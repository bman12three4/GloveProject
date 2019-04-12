using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProtoTurtle.BitmapDrawing;

public class Canvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Texture2D texture = new Texture2D(300,300, TextureFormat.RGB24, false); 
        this.GetComponent<MeshRenderer>().material.mainTexture = texture; 
        texture.wrapMode = TextureWrapMode.Clamp; 

        texture.DrawFilledCircle(150, 150, 50, Color.red);

        texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
