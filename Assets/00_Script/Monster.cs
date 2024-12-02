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

    public GameObject HitParticle;

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

            /*
                Instantiate
                : 새로운 게임 오브젝트를 생성하는 함수로
                이를 통해 기존 프리팹 또는 게임 오브젝트의 복사본을 만들 수 있다.
                주로 캐릭터 스폰, 총알 발사, 환경 생성 등 동적으로 오브젝트를 생성할 때 사용된다. 
            */
            Instantiate(HitParticle, other.gameObject.transform.position, Quaternion.identity);

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
