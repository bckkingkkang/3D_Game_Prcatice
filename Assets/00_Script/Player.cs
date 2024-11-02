using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    Vector3 StartPosition;
    Vector3 EndPosition;

    public float speed;

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

            if (value == 1)
            {
                // 오른쪽으로 드래그 시 양수, +1 출력
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else if (value == -1)
            {
                // 왼쪽으로 드래그 시 음수, -1 출력
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            StartPosition = Vector3.zero;
            EndPosition = Vector3.zero;
        }
    }
}
