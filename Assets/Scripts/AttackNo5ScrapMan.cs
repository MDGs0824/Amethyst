using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackNo5ScrapMan : MonoBehaviour
{
    public float Speed;
    public int Damage;
    bool Countered = false;
    Transform myTransform;

    [SerializeField] int MikiriPercent;

    public GameObject effect;

    GameObject Player;
    PlayerManagerVsScrapMan playerManager;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerManager = Player.GetComponent<PlayerManagerVsScrapMan>();

    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        //transform.position += new Vector3(Speed * -1, 0) * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Countered == false)
        {
            transform.position += new Vector3(Speed* -1, 0, 0) * Time.deltaTime;
        }

        else
        {
            transform.position += new Vector3(Speed, 0, 0) * Time.deltaTime;
            this.tag = "CounterAttackNo5"; //タグをプレイヤーの攻撃に変える。
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)　// 他のオブジェクトに接触した時。isTriggerとどちらかにrigitbodyが必要。collisionの中に当たったオブジェクトの情報が入っている。
    {
        //float time = 0.2f;

        if (collision.CompareTag("Player"))
        {
            Instantiate(effect, this.transform.position, transform.rotation);
            Destroy(gameObject,0.03f);
        }

        if (collision.CompareTag("CounterWall"))
        {
            Countered = true;
            Vector3 Scale = myTransform.localScale;
            transform.localScale = new Vector3(Scale.x * -1, Scale.y, Scale.z);
            playerManager.Mikiri += Damage * MikiriPercent; //プレイヤーの見切りゲージの上がり具合。固定orダメージ比例

            float time = 0.1f;
            Camera maincamera = Camera.main;
            maincamera.DOShakePosition(time, 0.3f, 90);
            Invoke("CameraReset", time);
            Invoke("DoTweenKillAll", 3f);
            
        }

        if (collision.CompareTag("Enemy"))
            if (Countered == true)
            {
                {
                    Instantiate(effect, this.transform.position, transform.rotation);
                    Destroy(gameObject, 0.03f);
                }
            }

    }

    void DoTweenKillAll()
    {
        DOTween.KillAll();
    }

    void CameraReset()
    {
        Camera maincamera = Camera.main;
        Transform tr = maincamera.transform;
        tr.position = new Vector3(0, 0, 0);
    }



}