using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 5;

    public SpriteRenderer sr;
    public Sprite flyingSprite;
    public Sprite normalSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemyHealth);
        if(enemyHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void DamageEnemy()
    {
        enemyHealth--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            sr.sprite = normalSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Platform")
        {
            sr.sprite = flyingSprite;
        }
    }
}
