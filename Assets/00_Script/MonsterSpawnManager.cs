using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Monster monster;

    private void Start()
    {
        StartCoroutine(Spawn_Coroutine());
    }

    IEnumerator Spawn_Coroutine()
    {
        // Cube 사이 영역에서 랜덤으로 Monster 생성
        float xPosition = Random.Range(-5f, 5f);
        float zPosition = Random.Range(55f, 70f);

        Instantiate(monster, new Vector3(xPosition, 0.05f, zPosition), Quaternion.Euler(0f, 180f, 0f));

        yield return new WaitForSeconds(Random.Range(1, 3));

        StartCoroutine(Spawn_Coroutine());
    }
}
