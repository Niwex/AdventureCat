using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonstersScript : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
   public void Attack()
    {
        //atack animation

        //attack 
    }

    public void getHit(float dmg)
    {
        currentHealth -= dmg;

        //hurt anim

        //Die 
        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("die!" );

        //die anim


    }
}
