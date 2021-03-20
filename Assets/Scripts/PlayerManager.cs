using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    Animator animator;

    public int Hp;
    public int Mikiri = 0;
    public int MikiriPowerUp = 3;

    public GameObject Enemy;
    EnemyManager enemyManager;


    public GameObject BoomInstancePoint;
    public GameObject SonicBoomPrefab;
    public GameObject PowerUpSonicBoomPrefab;

    //SonicBoom sonicBoom;

    public GameObject CounterInstancePoint;
    public GameObject CounterObject;
    public float ConterFinishTime = 0.1f;

    [SerializeField] GameObject skillButtonImage;
    [SerializeField] GameObject skillButtonImage2;

    public int Skill1Dmg = 100;

    [SerializeField] Camera maincamera;







    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyManager = Enemy.GetComponent<EnemyManager>();
     }

    // Update is called once per frame
    void Update()
    {
        MikiriCounter();
        MikiriCounter2();
        deathAnime();
    }

    private void FixedUpdate()
    {
        //MikiriCounter();
        //deathAnime();
    }

    public void AttackButton()
    {
        if (Time.timeScale > 0)
        {
            animator.SetTrigger("AttackTrigger");
        }
    }

    public void CounterButton()
    {
        if (Time.timeScale > 0)
        {
            animator.SetTrigger("CounterTrigger");
        }
    }

    public void SkillButton()
    {
        //if (Time.timeScale > 0)
       // {
            

            if (Mikiri == 100)
            {
                animator.updateMode = AnimatorUpdateMode.UnscaledTime;
                timeStop();
                animator.SetTrigger("SkillTrigger");
                InstanceSkill();
            }
        //}
    }

        public void InstanceSkill() //時間停止と見切りゲージの初期化。ボタンを押した瞬間に呼び出す。
        {
            Mikiri = 0;
        }

            void Skill1Damage() //暗転中なので、相手のHPを直接取得して減らす。スキルアニメーションのダメージ発生時に呼び出す。
            {
                enemyManager.Hp -= Skill1Dmg;
            }


        public void InstanceBoom() //ソニックブーム発生。アニメーションから呼び出す。
        {
            if (Mikiri < 100)
            {
                Instantiate(SonicBoomPrefab, BoomInstancePoint.transform.position, transform.rotation);
            }
            else
                Instantiate(PowerUpSonicBoomPrefab, BoomInstancePoint.transform.position, transform.rotation);

    }

        public void InstanceCounterWall()　//カウンターウォール発生。アニメーションから呼び出す。
        {
            Instantiate(CounterObject, CounterInstancePoint.transform.position, transform.rotation);
            Invoke("CounterWallDestroy", ConterFinishTime);
        
        }

            void CounterWallDestroy()
            { 
                GameObject CounterWallObj = GameObject.FindGameObjectWithTag("CounterWall");
                Destroy(CounterWallObj);
            }

    void MikiriCounter()
    {
        if (Mikiri >= 100)
        {
            Mikiri = 100;
            skillButtonImage.SetActive(false);

        }
        else
            skillButtonImage.SetActive(true);
    }
    void MikiriCounter2()
    {
        if (Mikiri >= 100)
        {
            Mikiri = 100;
            skillButtonImage2.SetActive(true);

        }
        else
            skillButtonImage2.SetActive(false);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        float time = 0.2f;

        if (collision.CompareTag("AttackNo5"))
        {
            Hp -= collision.GetComponent<AttackNo5>().Damage;
            DamagedAnimation();
            maincamera.DOShakePosition(time, 1f, 90);
            Invoke("CameraReset", time);
            Invoke("DoTweenKillAll", 3f);
        }

        if (collision.CompareTag("AttackNo1"))
        {
            Hp -= collision.GetComponent<AttackNo1>().Damage;
            DamagedAnimation();
            maincamera.DOShakePosition(time, 1f, 90);
            Invoke("CameraReset", time);
            Invoke("DoTweenKillAll", 3f);
        }
    }

    void DamagedAnimation()
    {
        animator.SetTrigger("DamageTrigger");
    }

    void deathAnime()
    {
        if (Hp <= 0)
        {
            animator.SetTrigger("Death");
        }
    }

    public void Death() //deathAnimeから呼び出し
    {
        Destroy(gameObject);
    }

    public void timeStop()
    {
        Time.timeScale = 0;
    }

    public void timeRestart()
    {
        Time.timeScale = 1;
        animator.updateMode = AnimatorUpdateMode.Normal;
    }

    public void CameraShake()
    {
        float time = 0.2f;

        maincamera.DOShakePosition(time, 2f, 90).SetUpdate(true);
        Invoke("CameraReset", time);
        Invoke("DoTweenKillAll",3f);
    }

    void DoTweenKillAll()
    {
        DOTween.KillAll();
    }

    void CameraReset()
    {
        Transform tr = maincamera.transform;
        tr.position = new Vector3(0, 0, 0);
    }
}
