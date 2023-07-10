using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int lives;
    public bool isAttacking;
    public Animator animator;
    public LayerMask enemyLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Aüake()
    {
        lives = 5;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isAttacking = true;
            StartCoroutine(AttackAnim());            
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isAttacking)
        {
            lives = lives - damageAmount;
        }
    }

    IEnumerator AttackAnim()
    {
        animator.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(.5f);
        animator.SetBool("IsAttacking", false);
        isAttacking= false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isAttacking && enemyLayer == (enemyLayer | (1 << other.gameObject.layer)))
        {
            EnemyWatermelon enemy = other.gameObject.GetComponent<EnemyWatermelon>();
            if (enemy)
            {
                Debug.Log("dskfdsfsdfjdslfjdslkf");
                enemy.TakeDamage(1);
            }
        }
    }
}
