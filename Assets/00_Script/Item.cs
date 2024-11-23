using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float speed = 2;

    void Update()
    {
        transform.position += -transform.forward * Time.deltaTime * speed;
    }
}
