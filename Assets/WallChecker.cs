using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    [SerializeField] bool isRight;
    [SerializeField] bool isGround;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            if (isRight)
            {
                player.isWalledRight = true;
            }
            else
            {
                player.isWalledLeft = true;
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
            player.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            if (isRight)
            {
                player.isWalledRight = false;
            }
            else
            {
                player.isWalledLeft = false;
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
            player.isGrounded = false;
    }
}
