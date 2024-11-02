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
        // ���콺 ��Ŭ�� �Ǿ��� ���
        if (Input.GetMouseButtonDown(0)) // 0 �� ��Ŭ��, 1�� ��Ŭ��
        {
            // ���� ��ġ ����
            StartPosition = Input.mousePosition;
        }

        // ���콺 ��Ŭ�� �����ִ� ����
        if (Input.GetMouseButton(0))
        {
            // ������ ��ġ ����
            EndPosition = Input.mousePosition;

            Vector3 Distance = EndPosition - StartPosition;

            // Sign : ���� ������� -1, ������ +1 ���
            int value = (int)Mathf.Sign(Distance.x);

            if (value == 1)
            {
                // ���������� �巡�� �� ���, +1 ���
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else if (value == -1)
            {
                // �������� �巡�� �� ����, -1 ���
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
