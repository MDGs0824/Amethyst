using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyScrapManHpCounter : MonoBehaviour
{
    public GameObject Enemy;
    public Slider HpGauge;
    public int Value;
    EnemyManagerScrapMan enemyManager;

    public GameObject filled;
    Image filledImage;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = Enemy.GetComponent<EnemyManagerScrapMan>();
        filledImage = filled.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        Value = enemyManager.Hp;
        //HpGauge.value = Value;
        filledImage.fillAmount = (float)Value / 700; //設定体力で割る。

    }

}