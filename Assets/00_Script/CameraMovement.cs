using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public Transform Player;

    private void Update()
    {
        float LerpX = Mathf.Lerp(transform.position.x, Player.position.x, speed * Time.deltaTime);
        transform.position = new Vector3(LerpX, transform.position.y, transform.position.z);
    }
}
