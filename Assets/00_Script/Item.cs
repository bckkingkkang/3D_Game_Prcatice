using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item_State
{
    ATK_Speed,
    ATK_Count
}

public class Item : MonoBehaviour
{
    private float speed = 2;

    public GameObject[] Cubes;

    Item_State[] state = new Item_State[2];

    public Material[] materials;

    private void Start()
    {
        state[0] = (Item_State)Random.Range(0, 2);

        /*
        if(Item_State.ATK_Speed == state[0])
        {
            state[1] = Item_State.ATK_Count;
        } else
        {
            state[1] = Item_State.ATK_Speed;
        }
        */
        state[1] = Item_State.ATK_Speed == state[0] ? Item_State.ATK_Count : Item_State.ATK_Speed;

        for(int i=0; i<state.Length; i++)
        {
            Cubes[i].GetComponent<Renderer>().material = materials[(int)state[i]];
        }

    }

    private void Update()
    {
        transform.position += -transform.forward * Time.deltaTime * speed;
    }
}
