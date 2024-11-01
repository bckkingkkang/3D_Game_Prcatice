using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector3 StartPosition;
    Vector3 EndPosition;

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

            Debug.Log(Distance.x);
        }

    }
}
