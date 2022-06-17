using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRolling : MonoBehaviour
{
    public float speed = -10, limitZ = -50;
    public float originZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        if (transform.position.z < limitZ)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
