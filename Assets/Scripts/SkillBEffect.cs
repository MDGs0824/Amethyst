using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBEffect : MonoBehaviour
{

    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void VanishThis() // アニメーションから呼び出す
    {
        Destroy(gameObject);
    }
}
