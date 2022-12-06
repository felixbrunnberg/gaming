using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiscript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    bool isFollowing;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        isFollowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angel = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        if(distance < 4)
        {
            isFollowing = true;

        }
        if(distance > 12) 
        {
            isFollowing = false;
        }

        if (isFollowing)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angel);
        }
       


    }
}
