using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseController : MonoBehaviour
{
    public int lives;
    [SerializeField] protected float speed;
    [SerializeField] protected int power;

    public virtual void TakeDamage(int damageAmount)
    {

    }

    public virtual void OnDeath()
    {

    }
}
