using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWatermelon : EnemyBaseController
{
    private void Awake()
    {
        lives = 5;
    }
    public override void TakeDamage(int damageAmount)
    {
        lives -= damageAmount;

    }
}
