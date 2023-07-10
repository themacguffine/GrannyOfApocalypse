using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsGroundedPlayer : MonoBehaviour
{
    public bool isGrounded;
    public int layer;
    public LayerMask layermask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherLayer = collision.collider.gameObject.layer;

        if (layermask == (layermask | (1 << otherLayer)))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var otherLayer = collision.collider.gameObject.layer;

        if (layermask == (layermask | (1 << otherLayer)))
        {
            isGrounded = false;
        }
    }
}
