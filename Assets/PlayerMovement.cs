using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    bool isGrounded;
    
    void Update()
    {
        

       if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
           GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15), ForceMode2D.Impulse);


        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * moveSpeed;
        }
       if(Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }

    }

    void OnTriggerEnter2D()
    {
        isGrounded = true;
    }
    void OnTriggerExit2D()
    {
        isGrounded = false;
    }
}
