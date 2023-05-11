using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camYLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, 0f, -10f);
    }
}
