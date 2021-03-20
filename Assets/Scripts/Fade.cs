using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image img;
    [SerializeField] float fadeInTimeSec;
    [SerializeField] float intervalSec;
    [SerializeField] float fadeOutTimeSec;
    [SerializeField] float NextWaitTime;

    private float DoTweenKillTimeSec;
    private float ActiveNextTimeSec;

    [SerializeField] GameObject NextActiveObject;
    [SerializeField] GameObject NextActiveObject2;



    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        Sequence1();

        DoTweenKillTimeSec = fadeInTimeSec + intervalSec + fadeOutTimeSec + 1f;
        Invoke("DoTweenKillAll",DoTweenKillTimeSec);
        ActiveNextTimeSec = DoTweenKillTimeSec + NextWaitTime;
        Invoke("SetActiveNext", ActiveNextTimeSec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Sequence1() 
    {
        Sequence sequence1 = DOTween.Sequence();
        sequence1.Append(img.DOFade(1, fadeInTimeSec).SetEase(Ease.InCubic));
        sequence1.AppendInterval(intervalSec);
        sequence1.Append(img.DOFade(0, fadeOutTimeSec).SetEase(Ease.InCubic));
    }

    void DoTweenKillAll()
    {
        Debug.Log("KillOK");
        DOTween.KillAll();
    }

    void SetActiveNext()
    {
        NextActiveObject.SetActive(true);
        NextActiveObject2.SetActive(true);

        this.gameObject.SetActive(false);
    }
}
