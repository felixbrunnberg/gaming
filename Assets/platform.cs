using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;
    bool isGrounded;
    void Start() {

        effector = GetComponent<PlatformEffector2D>();
    }
    void Update(){
        
        effector.rotationalOffset = 0f;
        if (Input.GetKey(KeyCode.S) &&isGrounded)
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0f;
                
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

       /* if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
       






        }*/
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
