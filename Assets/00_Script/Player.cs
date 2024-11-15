using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    Vector3 StartPosition;
    Vector3 EndPosition;

    private float speed = 3;
    private float bullet_speed = 0.5f;

    // 벽에 부딪혔을 때 튕겨져나오는 현상 해결
    Rigidbody rigidbody;

    Animator anim;

    public GameObject Bullet;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        StartCoroutine(Bullet_Coroutine());
    }

    private void Update()
    {
        // 마우스 좌클릭 되었을 경우
        if (Input.GetMouseButtonDown(0)) // 0 은 좌클릭, 1은 우클릭
        {
            // 시작 위치 저장
            StartPosition = Input.mousePosition;
        }

        // 마우스 좌클릭 눌려있는 동안
        if (Input.GetMouseButton(0))
        {
            // 마지막 위치 저장
            EndPosition = Input.mousePosition;

            Vector3 Distance = EndPosition - StartPosition;

            // Sign : 값이 음수라면 -1, 양수라면 +1 출력
            int value = (int)Mathf.Sign(Distance.x);

            // 0.5f 이상의 드래그 거리가 있어야 움직이도록 if문 추가
            if (Vector3.Distance(StartPosition, EndPosition) >= 0.5f)
            {
                if (value == 1)
                {
                    StartPosition = new Vector3(EndPosition.x - 1.0f, StartPosition.y, StartPosition.z);

                    rigidbody.velocity = new Vector3(speed, rigidbody.velocity.y, rigidbody.velocity.z);

                    // 오른쪽으로 드래그 시 양수, +1 출력
                    //transform.Translate(Vector3.right * speed * Time.deltaTime);

                    AnimatorChange("RUN");
                }
                else if (value == -1)
                {
                    StartPosition = new Vector3(EndPosition.x + 1.0f, StartPosition.y, StartPosition.z);

                    rigidbody.velocity = new Vector3(-speed, rigidbody.velocity.y, rigidbody.velocity.z);

                    // 왼쪽으로 드래그 시 음수, -1 출력
                    //transform.Translate(Vector3.left * speed * Time.deltaTime);

                    AnimatorChange("RUN");
                }
            }
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            StartPosition = Vector3.zero;
            EndPosition = Vector3.zero;

            // 마우스를 뗐을 경우 미끄러지는 문제 해결
            rigidbody.velocity = Vector3.zero;

            AnimatorChange("AIM");
        }

        // A Key 입력 시 실행
        /*
        if(Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("SHOOT");
            Bullet_Make();
        }
        */
    }

    // Coroutine
    // A key 입력 시 실행 -> 1초마다 실행되도록 변경
    private IEnumerator Bullet_Coroutine()
    {
        Bullet_Make();
        yield return new WaitForSeconds(bullet_speed);
        StartCoroutine(Bullet_Coroutine());

    }

    private void AnimatorChange(string temp)
    {
        if (temp == "SHOOT")
        {
            anim.SetTrigger("SHOOT");
            return;
        }

        anim.SetBool("RUN", false);
        anim.SetBool("AIM", false);
        anim.SetBool(temp, true);
    }

    private void Bullet_Make()
    {
        // anim.SetTrigger("SHOOT");
        AnimatorChange("SHOOT");
        GameObject go = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z + 1.0f), Quaternion.identity);
        Destroy(go, 3.0f);
    }
}
