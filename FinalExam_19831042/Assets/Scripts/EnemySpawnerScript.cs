using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject item;
    public float currentTime = 0;
    public float coolTime = 2f;
    public static float chance = 15;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; //시간 경과가 세팅한 쿨타임보다 커지면 생성
        if (currentTime > coolTime)
        {
            currentTime = 0;
            Debug.Log("COOL 됐다.");
            int rnd = Random.Range(0, 100);
            if (rnd > chance)
            {
                Instantiate(enemy, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(item, transform.position,transform.rotation);
            }
        }
    }
}
