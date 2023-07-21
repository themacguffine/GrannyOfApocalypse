using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeethBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float direction;

    private BoxCollider2D boxCollider;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) { return; }

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
        print("salam");
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localeScaleX  = transform.localScale.x;
        if(Mathf.Sign(localeScaleX) != _direction) {
            localeScaleX = -localeScaleX;
        }

        transform.localScale = new Vector3(localeScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
