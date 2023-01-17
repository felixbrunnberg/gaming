using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float jumpMod;
    public bool isWalledLeft;
    public bool isWalledRight;
    public bool isGrounded;
    public float playerCrouchHeight = 0.9f;
    public float playerStandHeight = 1.7f;
    public float playerCrouchWidth = 1;
    [SerializeField] Sprite crouchSprite;
    [SerializeField] Sprite standSprite;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform spritepos;
    [SerializeField] BoxCollider2D wallcheckRight;
    [SerializeField] BoxCollider2D wallcheckLeft;
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
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D) && !isWalledRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -12), ForceMode2D.Impulse);
             
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(playerCrouchWidth, playerCrouchHeight);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, (0.05f - (playerStandHeight - playerCrouchHeight) * 0.5f));
            spriteRenderer.sprite = crouchSprite;
            spritepos.transform.localPosition = new Vector3(0, 0.25f, 0);
            wallcheckLeft.size = new Vector2(1, 0.525f);
            wallcheckLeft.offset = new Vector2(-12, -0.255f);
            wallcheckRight.size = new Vector2(1, 0.525f);
            wallcheckRight.offset = new Vector2(12, -0.255f);
        }
        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1, playerStandHeight);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, 0.05f);
            spriteRenderer.sprite = standSprite;
            spritepos.transform.localPosition = new Vector3(0, 0, 0);
            wallcheckLeft.size = new Vector2(1, 1);
            wallcheckLeft.offset = new Vector2(0, 0);
            wallcheckRight.size = new Vector2(1, 1);
            wallcheckRight.offset = new Vector2(0, 0);
        }
    }
}

