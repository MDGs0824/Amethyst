using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHpCounter : MonoBehaviour
{
    public GameObject Player;
    public Slider HpGauge;
    public int Value;
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
        Value = playerManager.Hp;
        //HpGauge.value = Value;

        filledImage.fillAmount = (float)Value / 100;

    }

}