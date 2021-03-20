using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable2 : MonoBehaviour
{
    new Camera camera;
    public float baseWidth = 9.0f;
    public float baseHeight = 16.0f;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Awake()
    {
        // アスペクト比固定
        var scale = Mathf.Min(Screen.height / baseHeight, Screen.width / baseWidth);
        var width = (baseWidth * scale) / Screen.width;
        var height = (baseHeight * scale) / Screen.height;
        camera.rect = new Rect((1.0f - width) * 0.5f, (1.0f - height) * 0.5f, width, height);
    }
}
