using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonstersScript
{


    public float _moveSpeed;
    public int _attackDamage;
    public int _maxHealth;
    public float _attackRadius;

    //movement
    public float _followRadius;
    //end
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer enemySR;

    void Start()
    {
        //get the player transform   
        playerTransform = FindObjectOfType<CharacterControl>().GetComponent<Transform>();
        //enemy animation and sprite renderer 
        enemyAnim = gameObject.GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();
        //set the variables
        setMoveSpeed(_moveSpeed);
        setAttackDamage(_attackDamage);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkFollowRadius(playerTransform.position.x, transform.position.x))
        {
            //if player in front of the enemies
            if (playerTransform.position.y < transform.position.y)
            {

                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", true);
                    enemyAnim.SetTrigger("AttackA");
                }
                else
                {
                    MoveToPlayer(0, -1);
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", false);
                    //walk
                    //enemyAnim.SetBool("Walking", true);
                    enemyAnim.SetTrigger("Walking");
                    enemySR.flipX = true;
                }

            }
            //if player is behind enemies
            else if (playerTransform.position.y > transform.position.y)
            {
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    //nemyAnim.SetBool("AttackA", true);
                    enemyAnim.SetTrigger("AttackA");
                }
                else
                {
                    MoveToPlayer(0, 1);
                    
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", false);
                    //walk
                    //enemyAnim.SetBool("Walking", true);
                    enemyAnim.SetTrigger("Walking");
                    enemySR.flipX = false;
                }


            }
            else if (playerTransform.position.x > transform.position.x)
            {
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    //nemyAnim.SetBool("AttackA", true);
                    enemyAnim.SetTrigger("AttackA");
                }
                else
                {
                    MoveToPlayer(-1, 0);

                    //for attack animation
                    //enemyAnim.SetBool("AttackA", false);
                    //walk
                    //enemyAnim.SetBool("Walking", true);
                    enemyAnim.SetTrigger("Walking");
                    enemySR.flipX = false;
                }


            }
            else if (playerTransform.position.x > transform.position.x)
            {
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    //nemyAnim.SetBool("AttackA", true);
                    enemyAnim.SetTrigger("AttackA");
                }
                else
                {
                    MoveToPlayer(1, 0);

                    //for attack animation
                    //enemyAnim.SetBool("AttackA", false);
                    //walk
                    //enemyAnim.SetBool("Walking", true);
                    enemyAnim.SetTrigger("Walking");
                    enemySR.flipX = false;
                }


            }
        }
        else
        {
            enemyAnim.SetBool("Walking", false);
        }


    }
    void OnDrawGizmosSelected()
    {
        //if (attackPoint == null)
            //return;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
        Gizmos.DrawWireSphere(transform.position, _followRadius);

    }
}
