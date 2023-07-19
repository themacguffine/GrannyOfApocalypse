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
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInp = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInp * speed, rb.velocity.y);

        if (horizontalInp > 0.01f)
        {
            transform.localScale = new Vector3(10, 10, 1);
            

        }        
        else if (horizontalInp < -0.01f)
        {
            transform.localScale = new Vector3(-10,10,1);
            
        }

        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }
        anim.SetBool("run", horizontalInp != 0);
        anim.SetBool("grounded", grounded);
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
            grounded = true;
    }

}
