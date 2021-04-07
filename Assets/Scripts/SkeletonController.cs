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
        

        State state = State.FOLLOW;
        MoveToPlayer(playerTransform);
        
        switch (state)
        {
            case State.IDLE:
                break;
            case State.ATTACK:
                break;
            case State.FOLLOW:
                
                MoveToPlayer(playerTransform);
                break;
            case State.BLOCK:
                break;
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
