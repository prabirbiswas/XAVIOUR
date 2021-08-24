using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float currhealth;
    public float maxHealth;

    public bool isDead = false;

    public virtual void CheckHealth()
    {
        if (currhealth >= maxHealth)
        {
            currhealth = maxHealth;
        }
        if (currhealth <= 0)
        {
            currhealth = 0;
            isDead = true;
            die();
            
        }
    }

    public virtual void die()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currhealth -= damage;
    }

    public void destroyZombie()
    {
        //Instantiate(ZombieDestroyed, transform.position,transform.rotation);
        Destroy(this.gameObject);
    }
}
