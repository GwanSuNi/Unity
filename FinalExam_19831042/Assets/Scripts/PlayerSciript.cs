using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerSciript : MonoBehaviour
{
    public float limitX, speed;
    public float playerHP = 100;
    public float fuel = 50;
    public float fuelDifficulty = 1;
    float currentTime = 0;

    public GameObject hpGuage;
    public GameObject fuelGuage;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (transform.position.x < -limitX )
        {
            transform.position = new Vector3(-limitX, 0.5f, -20);
        }
        else if (transform.position.x > limitX)
        {
            transform.position = new Vector3(limitX, 0.5f, -20);
        }

        hpGuage.GetComponent<Slider>().value = playerHP;

        currentTime += Time.deltaTime;
        if(currentTime >= fuelDifficulty)
        {
            fuel -= currentTime;
            currentTime = 0;
        }
        fuelGuage.GetComponent<Slider>().value = fuel;
        
        if(fuel <= 0 || playerHP <= 0)
        {
            
            //todo 메인화면으로 돌아가기
        }
    
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ItemGas"))
        {
            Debug.Log("item");
            Destroy(other.gameObject);
            if(fuel >= 0)
            {
                fuel += 0.5f;
            }
        }
        else if (other.gameObject.CompareTag("")) // 수리 스페어 자리
        {
            Destroy(other.gameObject);
            if(playerHP < 100)
            {
                playerHP += 5;
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            Destroy(other.gameObject);
            if (playerHP >= 0)
            {
                playerHP -= 10;
            }
        }
        else
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
