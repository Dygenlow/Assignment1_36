using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController36 : MonoBehaviour
{
    float speed = 10.0f;
    float vLimit = 4.8f;

    float gravityModifier = 2.5f;

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Code
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        //Front and Back Boundary
        if (transform.position.z < -vLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -vLimit);
        }

        else if (transform.position.z > vLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, vLimit);
        }

        //Left and Right Boundary
        if (transform.position.x < -vLimit)
        {
            transform.position = new Vector3(-vLimit, transform.position.y, transform.position.z);
        }

        else if (transform.position.x > vLimit)
        {
            transform.position = new Vector3(vLimit, transform.position.y, transform.position.z);
        }

        //Jump Code
        if (transform.position.y <= 0.5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            }
        }
    }
}
