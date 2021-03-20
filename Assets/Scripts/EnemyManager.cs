using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    int AttackNo;
    public GameObject AttackPrefab5;
    public GameObject AttackPrefab1;
    public GameObject AttackPoint;

    public int Hp;

    public float WaitTime = 2f;

    Animator animator;

    [SerializeField] Camera maincamera;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackPatterns());
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        deathExplosion();
    }

    void AttackNumbers() //呼び出されるたびに0〜101の値を返す
    {
        AttackNo = Random.Range(0, 101); 
    }

    public IEnumerator AttackPatterns() //攻撃の種類ごとに確率／１００で出るようにしている。
    {
        while(true)
        {
            if (Hp > 0)
            {
                AttackNumbers(); //AttackNoを0〜101で選出
                yield return new WaitForSeconds(WaitTime); //WaitTime分待ってから次にいく。
                if (AttackNo < 6)
                {
                    AttackNo1Animation();
                    Debug.Log("攻撃①　0 - 5");
                }
                else if (AttackNo < 16)
                {
                    AttackNo1Animation();
                    Debug.Log("攻撃②　6 - 15");

                }
                else if (AttackNo < 31)
                {
                    AttackNo1Animation(); //アニメーションをセット。AttackNo5Instance();をアニメーションアドイベントから任意のタイミングで実行する。
                    Debug.Log("攻撃③　16 - 30");
                }
                else if (AttackNo < 51)
                {
                    AttackNo5Animation(); //アニメーションをセット。AttackNo5Instance();をアニメーションアドイベントから任意のタイミングで実行する。

                    Debug.Log("攻撃④　31 - 50");
                }
                else if (AttackNo < 101)
                {
                    AttackNo5Animation(); //アニメーションをセット。AttackNo5Instance();をアニメーションアドイベントから任意のタイミングで実行する。
                                          
                    Debug.Log("攻撃⑤　51 - 100");
                }
            }
            else
                yield break;

        }
    }

    void deathExplosion()
    {
        if (Hp <= 0)
        {
            animator.SetTrigger("Death");
        }
    }


    void AttackNo5Animation() //
    {
        animator.SetTrigger("AttackNo5Trigger");//triggerをセットする
    }

    void AttackNo1Animation() //
    {
        animator.SetTrigger("AttackNo1Trigger");//triggerをセットする
    }


    void AttackNo5Instance()//アニメーションのアドイベントから任意のタイミングで実行する。
    {
      Instantiate(AttackPrefab5, AttackPoint.transform.position,transform.rotation);
    }

    void AttackNo1Instance()//アニメーションのアドイベントから任意のタイミングで実行する。
    {
        Instantiate(AttackPrefab1, AttackPoint.transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision) //攻撃ごとにタグつけてスクリプトからダメージ量を引っ張ってくる（しかやり方わからない）
    {
        float time = 0.1f;
        float strength = 0.3f;

        if (collision.CompareTag("SonicBoom"))
        {
            Hp -= collision.GetComponent<SonicBoom>().Damage;
            maincamera.DOShakePosition(time, strength, 90);
            Invoke("CameraReset", time);
            Invoke("DoTweenKillAll", 3f);
        }

        if (collision.CompareTag("SonicBoomPowerUp"))
        {
            Hp -= collision.GetComponent<SonicBoomPowerUp>().Damage;
            maincamera.DOShakePosition(time, strength, 90);
            Invoke("CameraReset", time);
            Invoke("DoTweenKillAll", 3f);
        }

        if (collision.CompareTag("CounterAttackNo5"))
        {
            Hp -= collision.GetComponent<AttackNo5>().Damage;
            maincamera.DOShakePosition(time, strength, 90);
            Invoke("CameraReset", time);
            Invoke("DoTweenKillAll", 3f);
        }

        if (collision.CompareTag("CounterAttackNo1"))
        {
            Hp -= collision.GetComponent<AttackNo1>().Damage;
            maincamera.DOShakePosition(time, strength, 90);
            Invoke("CameraReset", time);
            Invoke("DoTweenKillAll", 3f);
        }


    }

    public void Death()
    {
        Destroy(gameObject);
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
