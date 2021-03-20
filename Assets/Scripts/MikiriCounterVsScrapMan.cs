using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MikiriCounterVsScrapMan : MonoBehaviour
{
    public GameObject Player;
    public Slider MikiriGauge;
    public float Value;
    PlayerManagerVsScrapMan playerManager;

    public GameObject filled;
    Image filledImage;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = Player.GetComponent<PlayerManagerVsScrapMan>();
        filledImage = filled.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        Value = playerManager.Mikiri;
        //MikiriGauge.value = Value;
        filledImage.fillAmount = Value / 100;

    }

}