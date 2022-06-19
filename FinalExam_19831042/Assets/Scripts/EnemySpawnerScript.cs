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

    int rndX;
    int[] posX = { -6, -4, -2, 2, 4, 6 };
    int[] number = new int[6];
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
                Instantiate(item, transform.position, transform.rotation);
            }

            // 스폰 포지션에 대한 랜덤 검사 부분
            int rndZ = Random.Range(50, 90);

            for (int i = 0; i < 6; i++)
            {
                number[i] = Random.Range(0, 6);
            }

            for (int i = 0; i < number.Length; i++)
            {
                for(int j = i + 1; j <number.Length; j++)
                {
                    if(number[i] == number[j] && i != j)
                    {
                        number[i] = Random.Range(0, 6);
                        rndX = posX[number[i]];
                        j = -1;
                    }
                }
            }
            transform.position = new Vector3(rndX, 0.5f, rndZ);
            
        }

    }
}
