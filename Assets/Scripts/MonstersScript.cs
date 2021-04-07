using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonstersScript : MonoBehaviour
{
    public float maxHealth = 100;
    protected float currentHealth;

    float moveSpeed;
    int attackDmg;
    float attackRadius;

    float followRadius;

    public enum State
    {
        IDLE,
        ATTACK,
        FOLLOW,
        BLOCK
    }
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

    public void Die()
    {
        Debug.Log("die!" );

        //die anim


    }

    public void ChooseTheWay(Transform playerTransform)
    {
        if (playerTransform.position.y < transform.position.y && playerTransform.position.x < transform.position.x) return;
        if (playerTransform.position.y < transform.position.y && playerTransform.position.x < transform.position.x) return;
        if (playerTransform.position.y < transform.position.y && playerTransform.position.x < transform.position.x) return;
        if (playerTransform.position.y < transform.position.y && playerTransform.position.x < transform.position.x) return;
        if (playerTransform.position.y < transform.position.y && playerTransform.position.x < transform.position.x) return;
        if (playerTransform.position.y < transform.position.y && playerTransform.position.x < transform.position.x) return;
        if (playerTransform.position.y < transform.position.y && playerTransform.position.x < transform.position.x) return;
        if (playerTransform.position.y < transform.position.y && playerTransform.position.x < transform.position.x) return;

    }
    public void MoveToPlayer(Transform playerTransform)
    {
        float distCovered = Time.deltaTime * moveSpeed;
        float distBetweenMonsterAndPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distBetweenMonsterAndPlayer <= followRadius)
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position, distCovered / distBetweenMonsterAndPlayer);
            Debug.Log("FOLLOW");
        }
    }

    public void setState()
    {

    }
    public void setMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public void setAttackDamage(int attdmg)
    {
        attackDmg = attdmg;
    }
    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    public int getAttackDamage()
    {
        return attackDmg;
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
    public bool checkFollowRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < followRadius)
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
    public bool checkAttackRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < attackRadius)
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
