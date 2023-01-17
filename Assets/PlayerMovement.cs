using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float jumpMod;
    public bool isWalledLeft;
    public bool isWalledRight;
    public bool isGrounded;
    public float playerCrouchHeight = 0.5f;
    public float playerStandHeight = 1.7f;
    [SerializeField] Sprite crouchSprite;
    [SerializeField] Sprite standSprite;
    private void Awake()
    {
        GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -5), ForceMode2D.Impulse);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 18 * jumpMod), ForceMode2D.Impulse);
                //GetComponent<Rigidbody2D>().velocity = new Vector2(0,100);
            }
        }

        if (Input.GetKey(KeyCode.A) && !isWalledLeft)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.D) && !isWalledRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -12), ForceMode2D.Impulse);
             
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1, playerCrouchHeight);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, (0.05f - (playerStandHeight - playerCrouchHeight) * 0.5f));
            GetComponent<SpriteRenderer>().sprite = crouchSprite;
        }
        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1, playerStandHeight);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, 0.05f);
            GetComponent<SpriteRenderer>().sprite = standSprite;
        }
    }
}

