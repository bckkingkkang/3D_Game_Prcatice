using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float speed = 2;

    public int HP = 5;

    Animator anim;
    bool isDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isDead == false)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            HP--;

            if(HP <= 0)
            {
                anim.SetTrigger("Death");
                isDead = true;
            }

            Destroy(other.transform.parent.gameObject);
        }
    }
}
