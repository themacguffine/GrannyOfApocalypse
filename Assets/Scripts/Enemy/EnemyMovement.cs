using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;


    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(playerTransform.position.x - transform.position.x, 0f).normalized;
        if (direction.x > 0)
        {
            transform.Translate(-direction * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (direction.x < 0)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
