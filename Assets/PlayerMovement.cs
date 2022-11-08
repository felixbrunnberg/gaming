using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    bool isGrounded;
    bool dropThrough;
    
    private void Awake()
    {
        GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -5), ForceMode2D.Impulse);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 18), ForceMode2D.Impulse);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

       if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
       if(Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -12), ForceMode2D.Impulse);
        }
        
    }

    void OnTriggerEnter2D()
    {
        isGrounded = true;
        dropThrough = false;
    }
    void OnTriggerExit2D()
    {
        isGrounded = false;
    }
}

