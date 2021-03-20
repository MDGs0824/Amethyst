using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject blackOutCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 60; // FPSを60に設定
        DOTween.KillAll();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        testMethod();
    }

    void GameOver()
    {
        if(GameObject.FindGameObjectWithTag("Player")==false|| GameObject.FindGameObjectWithTag("Enemy") == false)
        {
            Invoke("blackOut", 1);
            Invoke("timeStop", 1);
        }
    }

    void timeStop()
    {
        Time.timeScale = 0;
    }

    void blackOut()
    {
        blackOutCanvas.SetActive(true);
    }

    void testMethod()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            timeStop();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 1;
        }
    }

    public void quit()
    {

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
