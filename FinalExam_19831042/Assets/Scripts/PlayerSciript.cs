using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSciript : MonoBehaviour
{
    public float limitX, speed;

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
            transform.position = new Vector3(-limitX, 0.5f, -15);
        }
        else if (transform.position.x > limitX)
        {
            transform.position = new Vector3(limitX, 0.5f, -15);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ItemGas"))
        {
            Debug.Log("item");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
