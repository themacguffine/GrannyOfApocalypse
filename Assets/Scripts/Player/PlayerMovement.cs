using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumForce = 10f;
    [SerializeField] private CheckIsGroundedPlayer checkIsGroundedPlayer;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        if (movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }



        if (Input.GetKeyDown(KeyCode.Space) && checkIsGroundedPlayer.isGrounded)
        {
            Jump();
        }

    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumForce, ForceMode2D.Impulse);
    }
}
