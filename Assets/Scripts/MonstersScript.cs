using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonstersScript : MonoBehaviour
{
    public float maxHealth = 100;
    protected float currentHealth;

    float moveSpeed;
    int attackDmg;
    float attackRate;
    float attackRadius;

    float followRadius;

    public enum State
    {
        IDLE,
        ATTACK,
        FOLLOW,
        BLOCK,
        GETHIT,
        DIE
    }
    public void Attack(CircleCollider2D weaponCollider)
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

    public void Die()
    {
        Debug.Log("die!" );

        //die anim


    }

    public void MoveToPlayer(Transform playerTransform)
    {
        float distCovered = Time.deltaTime * moveSpeed;
        float distBetweenMonsterAndPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distBetweenMonsterAndPlayer <= followRadius)
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position, distCovered / distBetweenMonsterAndPlayer);
            
        }
    }

    public State setState(Transform playerTransform)
    {
        if (checkAttackRadius(playerTransform))
        {
            return State.ATTACK;
        }
        if (checkFollowRadius(playerTransform))
            return State.FOLLOW;
        else return State.IDLE;
    }
    public void setMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public void setAttackDamage(int attdmg)
    {
        attackDmg = attdmg;
    }
    public void setAttackRate(float attRate)
    {
        attackRate = attRate;
    }
    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    public int getAttackDamage()
    {
        return attackDmg;
    }
    public float getAttackRate()
    {
        return attackRate;
    }

    //movement toward a player
    public void setFollowRadius(float r)
    {
        followRadius = r;
    }
    //attack radius 
    public void setAttackRadius(float r)
    {
        attackRadius = r;
    }

    //if player in radius move toward him 
    public bool checkFollowRadius(Transform playerTransform)
    {
        Vector3 position = transform.position;
        
        if (Vector3.Distance(position, playerTransform.position) <= followRadius)
        {
            //player in range
            return true;
        }
        else
        {
            return false;
        }
    }

    //if player in radius attack him
    public bool checkAttackRadius( Transform playerTransform)
    {
        Vector3 position = transform.position;
        position.y += 0.6f;
        if (Vector3.Distance(position, playerTransform.position) < attackRadius)
        {
            //in range for attack
            return true;
        }
        else
        {
            return false;
        }
    }
}
