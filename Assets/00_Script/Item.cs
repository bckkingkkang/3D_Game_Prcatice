using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float speed = 2;

    public GameObject[] Cubes;

    public enum Item_State
    {
        ATK_Speed,
        ATK_Count
    }
    public Item_State state;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position += -transform.forward * Time.deltaTime * speed;
    }
}
