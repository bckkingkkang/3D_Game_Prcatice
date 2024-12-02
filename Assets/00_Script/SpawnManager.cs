using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Monster monster;
    public Item item;

    private void Start()
    {
        StartCoroutine(Spawn_Coroutine());
        StartCoroutine(Spawn_Item_Coroutine());
    }

    IEnumerator Spawn_Item_Coroutine()
    {
        float zPosition = Random.Range(55f, 70f);

        Instantiate(item, new Vector3(-2.42f, 1.51f, zPosition), Quaternion.identity);

        yield return new WaitForSeconds(Random.Range(5f, 20f));

        StartCoroutine(Spawn_Item_Coroutine());
    }

    IEnumerator Spawn_Coroutine()
    {
        // Cube 사이 영역에서 랜덤으로 Monster 생성
        float xPosition = Random.Range(-5f, 5f);
        float zPosition = Random.Range(55f, 70f);

        Instantiate(monster, new Vector3(xPosition, 0.05f, zPosition), Quaternion.Euler(0f, 180f, 0f));

        yield return new WaitForSeconds(Random.Range(5f, 10f));

        StartCoroutine(Spawn_Coroutine());
    }
}
