using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    private float speed = 2;

    public Slider slider;
    int MaxHP;

    public int HP = 5;

    Animator anim;
    bool isDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        MaxHP = HP;
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

            if(slider.gameObject.activeSelf == false)
            {
                slider.gameObject.SetActive(true);
            }

            slider.value = (float)HP / (float)MaxHP;

            if(isDead == false)
            {
                if (HP <= 0)
                {
                    anim.SetTrigger("Death");

                    GetComponent<CapsuleCollider>().enabled = false;
                    Destroy(GetComponent<Rigidbody>());

                    isDead = true;
                    slider.gameObject.SetActive(false);
                }
                Destroy(other.transform.parent.gameObject);
            }


        }
    }
}
