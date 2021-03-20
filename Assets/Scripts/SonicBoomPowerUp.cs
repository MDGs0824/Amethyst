using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicBoomPowerUp : MonoBehaviour
{
    public float Speed;
    public int Damage = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FieldOut();
        transform.position += new Vector3(Speed, 0) * Time.deltaTime;
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
            Destroy(gameObject,0.02f);
        }
    }

}
