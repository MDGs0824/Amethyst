using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    Color color ;

    [SerializeField] float fadeInSpeed;
    [SerializeField] float fadeOutSpeed;

    [SerializeField] float fadeInStartTimeSec;
    [SerializeField] float fadeOutWaitTimeSec;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Invoke("fadeIn", fadeInStartTimeSec);
        //Invoke("fadeOut", fadeInStartTimeSec + fadeOutWaitTimeSec);

    }

    // Update is called once per frame
    void Update()
    {
        fadeIn();
        Debug.Log(color);
    }

    void fadeIn()
    {
        Debug.Log("fadeinOK");

        color = spriteRenderer.color;
        color.a += fadeInSpeed / 100 * Time.deltaTime;
        if(color.a >= 1)
        {
            color.a = 1;
        }
        spriteRenderer.color = color;
    }

    void fadeOut()
    {
        color = spriteRenderer.color;
        color.a -= fadeOutSpeed / 100 * Time.deltaTime;
        if (color.a <= 0)
        {
            color.a = 0;
        }
        spriteRenderer.color = color;
    }
}
