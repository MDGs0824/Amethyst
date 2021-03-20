using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MikiriCounter : MonoBehaviour
{
    public GameObject Player;
    public Slider MikiriGauge;
    public float Value;
    PlayerManager playerManager;

    public GameObject filled;
    Image filledImage;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = Player.GetComponent<PlayerManager>();
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