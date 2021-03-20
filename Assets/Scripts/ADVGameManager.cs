using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ADVGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // FPSを60に設定
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }

    public void LordTitle() //1 = タイトルß
    {
        SceneManager.LoadScene("1");
    }
}
