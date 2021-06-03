using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(1, 1, 1);

    }

    // Update is called once per frame
    void Update()
    {

        verticalInput = Input.GetAxis("Vertical");
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed * Time.deltaTime * verticalInput;
        
    }

    void Gravity()
    {

    }
}
