using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float wallJumpCoolDown;
    private float horizontalInp;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        horizontalInp = Input.GetAxis("Horizontal");

        if (horizontalInp > 0.01f)
        {
            transform.localScale = new Vector3(10, 10, 1);
        }        
        else if (horizontalInp < -0.01f)
        {
            transform.localScale = new Vector3(-10,10,1);
        }
        anim.SetBool("run", horizontalInp != 0);
        anim.SetBool("grounded", isGrounded());

        if(wallJumpCoolDown > 0.2f)
        {
            

            rb.velocity = new Vector2(horizontalInp * speed, rb.velocity.y);

            if(onWall() && !isGrounded())
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                print("presalkfsm");
            }else
            {
                rb.gravityScale = 7;
                print("aaaaaaa");
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            wallJumpCoolDown += Time.deltaTime;
        }
    }
    private void Jump()
    {
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        } else if (onWall() && !isGrounded())
        {
            if (horizontalInp == 0)
            {
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 6);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            }else
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
                
            wallJumpCoolDown = 0;

        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer) ;
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer) ;
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInp == 0 && isGrounded() && !onWall();
    }
}
