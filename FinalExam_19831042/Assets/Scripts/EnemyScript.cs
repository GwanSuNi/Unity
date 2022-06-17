using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed;
    public GameObject[] cars;

    // Start is called before the first frame update
    void Start()
    {
        int rnd = Random.Range(0, 3);
        Debug.Log("랜덤 : " + rnd);
        cars[rnd].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);

    }
}
