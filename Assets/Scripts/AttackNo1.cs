using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackNo1 : MonoBehaviour
{
    public float Speed;
    public int Damage;
    bool Countered = false;
    Transform myTransform;

    public GameObject effect;

    GameObject Player;
    PlayerManager playerManager;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerManager = Player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()　//Time.timeScale = 0の時に止まらないもの
    {
        //Move();
        //transform.position += new Vector3(Speed * -1, 0) * Time.deltaTime;
    }

    private void FixedUpdate() //Time.timeScale = 0の時に止まるもの
    {
        Move();
    }

    private void Move()
    {
        if (Countered == false)
        {
            transform.position += new Vector3(Speed * -1, 0, 0) * Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, 20));
        }

        else
        {
            transform.position += new Vector3(Speed, 0, 0) * Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, -20));
            this.tag = "CounterAttackNo1"; //タグをプレイヤーの攻撃に変える。
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)　// 他のオブジェクトに接触した時。isTriggerとどちらかにrigitbodyが必要。collisionの中に当たったオブジェクトの情報が入っている。
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(effect, this.transform.position, transform.rotation);
            Destroy(gameObject, 0.03f);
        }

        if (collision.CompareTag("CounterWall"))
        {
            Countered = true;
            Vector3 Scale = myTransform.localScale;
            transform.localScale = new Vector3(Scale.x * -1, Scale.y, Scale.z);
            playerManager.Mikiri += Damage * 4; //プレイヤーの見切りゲージの上がり具合。固定orダメージ比例

            float time = 0.1f;
            Camera maincamera = Camera.main;
            maincamera.DOShakePosition(time, 0.1f, 90);
            Invoke("CameraReset", time);
            Invoke("DoTweenKillAll", 3f);
        }

        if (collision.CompareTag("Enemy"))
            if (Countered == true)
            {
                {
                    Instantiate(effect, this.transform.position, transform.rotation);
                    Destroy(gameObject, 0.05f);
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