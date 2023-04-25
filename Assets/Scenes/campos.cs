using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campos : MonoBehaviour
{
    PlayerMovement playerRef;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = FindObjectOfType<PlayerMovement>();
        GetComponent<Transform>().position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(playerRef.playerXPos, 0f, -10f); 
    }
}
