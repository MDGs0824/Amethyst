using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectInstancePlayer : MonoBehaviour
{
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(effect, this.transform.position, transform.rotation);
        }
    }

}
