using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PreMainUIEffect : MonoBehaviour //UIの発生演出用
{
    Transform tr; //UI郡BG01のtransform変数宣言
    string sceneName;
    int sceneNameInt;


    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        //tr.DOScale(100f, 1.5f).SetEase(Ease.OutQuart);
        Invoke("ScaleChange", 1.5f);
        Invoke("DoTweenKillAll", 3.9f); //シーン遷移する前に全てのDOTweenを止める。
        Invoke("SceneChangeToNext", 4.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ScaleChange() //Ui郡のスケール変更用

    {
        tr.DOScale(100f, 0.5f).SetEase(Ease.OutExpo);　//1.5秒でスケール100に変更する。最初は０にセットしてある。OutExpoは最初に多く演出して一気に減衰する。
    }

    void SceneChangeToNext() //現在のシーン名にプラス１してそのシーンを読み込み。
    {
        sceneNameInt = int.Parse(SceneManager.GetActiveScene().name);
        sceneNameInt++;
        sceneName = sceneNameInt.ToString();
        SceneManager.LoadScene(sceneName);
    }


    void DoTweenKillAll()
    {
        DOTween.KillAll();
    }
}