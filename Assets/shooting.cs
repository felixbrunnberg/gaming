using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public SpriteRenderer target;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        Debug.Log(rotZ);

        if(rotZ > 90 && rotZ < 180 || rotZ < -90 && rotZ > -180)
        {
            target.flipY = true;
        }
        else
        {
            target.flipY = false;
        }

        transform.rotation = Quaternion.Euler(0, 0,rotZ);

    }
}
