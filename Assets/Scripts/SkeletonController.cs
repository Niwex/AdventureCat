using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonstersScript
{


    public float _moveSpeed;
    public int _attackDamage;
    public float _attackRate;
    public int _maxHealth;
    public float _attackRadius;

    public float _nextAttackTime = 0f;
    //movement
    public float _followRadius;
    //end
    [SerializeField] CircleCollider2D weaponCollider;
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
        setAttackRate(_attackRate);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
        setNextAttackTime(_nextAttackTime);
        HealthLastFrame = _maxHealth;
        currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        
        State state = setState(playerTransform);
        
        
        switch (state)
        {
            case State.IDLE:
                enemyAnim.SetTrigger("idle");
                //Debug.Log("IDDLE");
                break;

            case State.ATTACK:
                if(Time.time >=getNextAttackTime())
                {
                    enemyAnim.SetTrigger("attack");
                    //Attack func
                    StartCoroutine(AttackWait());
                    setNextAttackTime(Time.time + 1f / getAttackRate());
                    //Debug.Log("ATTACK");
                    
                }
                break;

            case State.FOLLOW:
                MoveToPlayer(playerTransform);
                if (playerTransform.position.x < transform.position.x) 
                    enemyAnim.SetFloat("Move X", -1);

                else enemyAnim.SetFloat("Move X", 1);
                enemyAnim.SetTrigger("walking");
                //Debug.Log("FOLLOW");
                break;

            case State.BLOCK:
                break;

            case State.GETHIT:
                enemyAnim.SetTrigger("getHit");
                break;
            case State.DIE:
                enemyAnim.SetTrigger("die");
                
                Die();
                break;
        }

     HealthLastFrame = currentHealth;
    }
    IEnumerator AttackWait()
    {
        
        yield return new WaitForSeconds(1f);
        Debug.Log(checkAttackRadius(FindObjectOfType<CharacterControl>().transform));
        if (checkAttackRadius(FindObjectOfType<CharacterControl>().transform))
        {
            Attack(FindObjectOfType<CharacterControl>());
        }
    }
    void OnDrawGizmosSelected()
    {
        //if (attackPoint == null)
        //return;
        Vector3 position = transform.position;
        position.y += 0.6f;
        Gizmos.DrawWireSphere(position, _attackRadius);
        Gizmos.DrawWireSphere(transform.position, _followRadius);

    }

    
}
