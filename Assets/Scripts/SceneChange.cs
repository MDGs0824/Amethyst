using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    string sceneName;
    int sceneNameInt;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SceneChangeToMain()
    {
        SceneManager.LoadScene("Main");
    }


    public void SceneChangeToNext() //現在のシーン名を取得して、プラス１して次のシーン名（数）にして再度読みこむ。メモ用このスクリプトでは使用していない。
    {
        sceneNameInt = int.Parse(SceneManager.GetActiveScene().name);
        sceneNameInt++;
        sceneName = sceneNameInt.ToString();
        SceneManager.LoadScene(sceneName);
    }

}
