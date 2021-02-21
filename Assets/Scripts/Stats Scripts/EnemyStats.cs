using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();

        //add ragdoll effect / death animation
        Debug.Log($"{transform.name} SHOULD DIE NOW");
        Destroy(gameObject);
    }
}
