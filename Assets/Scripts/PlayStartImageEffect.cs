using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayStartImageEffect : MonoBehaviour
{
    Transform tr;
    Image img;

    GameObject startImage;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        /*
        tr = GetComponent<Transform>();
        img = GetComponent<Image>();
        Sequence1();
        */

        Invoke("SetActive", 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetActive()
    {
        Debug.Log("OK");
        img.enabled = true;
    }

    /*
    void Sequence1()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(tr.DOMove(new Vector3(0, 0, 0), 2.5f).SetEase(Ease.InExpo));
        sequence.Join(tr.DOScale(200f, 2.5f).SetEase(Ease.InExpo));
        sequence.AppendInterval(1f);
        sequence.Append(tr.DOMove(new Vector3(13, 0, 0), 1.5f).SetEase(Ease.OutExpo));
        sequence.Join(tr.DOScale(0f,1.5f).SetEase(Ease.OutExpo));

        sequence.Play();
        Debug.Log("OK");
    }
    */


}
