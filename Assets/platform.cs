using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    [SerializeField] float passThroughTime;
    public float waitTime;
    bool isGrounded;
    void Start() {
        effector = GetComponent<PlatformEffector2D>();
        effector.rotationalOffset = 0f;
    }
    void Update(){
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 180f;
            waitTime = passThroughTime;
        }

        waitTime -= Time.deltaTime;

        if(waitTime <= 0)
        {
            effector.rotationalOffset = 0f;
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
