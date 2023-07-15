using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator anim;
    private Rigidbody2D rb;
    private bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInp = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInp * speed, rb.velocity.y);

        if (horizontalInp > 0.01)
        {
            transform.localScale = new Vector3(10, 10, 1);
            //anim.SetBool("isWalking", true);

        }        
        else if (horizontalInp < -0.01)
        {
            transform.localScale = new Vector3(-10,10,1);
            //anim.SetBool("isWalking", true);
        }
        else
        {
            //anim.SetBool("isWalking", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);
        grounded = false;
    }

}
