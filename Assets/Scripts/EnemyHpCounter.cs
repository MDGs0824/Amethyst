using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHpCounter : MonoBehaviour
{
    public GameObject Enemy;
    public Slider HpGauge;
    public int Value;
    EnemyManager enemyManager;

    public GameObject filled;
    Image filledImage;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = Enemy.GetComponent<EnemyManager>();
        filledImage = filled.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        Value = enemyManager.Hp;
        //HpGauge.value = Value;
        filledImage.fillAmount = (float)Value / 1000;

    }

}