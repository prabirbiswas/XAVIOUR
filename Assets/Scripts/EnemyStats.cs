using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private float scoreAddAmount = 10;
    

    private void Start()
    {
        maxHealth = 50;
        currhealth = maxHealth;
    }

    private void Update()
    {
        
    }
    public override void die()
    {
        Destroy(this.gameObject);
    }
}
