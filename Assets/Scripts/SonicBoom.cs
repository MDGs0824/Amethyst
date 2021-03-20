using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicBoom : MonoBehaviour
{
    public float Speed;
    public int Damage = 5;
    //public int MikiriPowerUpDamage = 15;

    

    //GameObject Player;
    //PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        //playerManager = Player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FieldOut();
        transform.position += new Vector3(Speed, 0) * Time.deltaTime;
        //OnDamage();
    }

    void FieldOut()
    {
        if(transform.position.x > 11)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //playerManager.Mikiri += Damage;
            Destroy(gameObject,0.02f);
        }
    }

    /*
    void OnDamage()
    {
        if(playerManager.Mikiri == 100)
        {
            Damage = MikiriPowerUpDamage;
        }
    }
    */

}
