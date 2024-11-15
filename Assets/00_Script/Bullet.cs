using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}