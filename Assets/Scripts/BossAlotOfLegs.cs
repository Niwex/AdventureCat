using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlotOfLegs : MonoBehaviour
{
    public float moveSpeed;
    public int attackDamage;
    public float attackRate;
    public int maxHealth;

    public float currentHealth;
    float HealthLastFrame;

    public float attackRadius;

    float nextAttackTime = 0f;
    //movement
    public float followRadius;
    //end

    [SerializeField] Transform playerTransform;
    [SerializeField] Collider2D topHandAttackpoint;
    [SerializeField] Collider2D leftHandAttackpoint;
    [SerializeField] Collider2D rightHandAttackpoint;
    [SerializeField] Animator animator;
    SpriteRenderer bossSprite;
    void Start()
    {
        currentHealth = maxHealth;
        playerTransform = FindObjectOfType<CharacterControl>().GetComponent<Transform>();
        bossSprite = GetComponent<SpriteRenderer>();

        topHandAttackpoint.enabled = false;
        leftHandAttackpoint.enabled = false;
        rightHandAttackpoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthLastFrame - currentHealth != 0)
        {
            //StartCoroutine(waitGetHit());
        }
        if (checkAttackRadius(topHandAttackpoint, playerTransform) || checkAttackRadius(leftHandAttackpoint, playerTransform) || checkAttackRadius(rightHandAttackpoint, playerTransform))
        {
            if (Time.time >= nextAttackTime)
            {
                //attack
                animator.SetTrigger("attack");
                StartCoroutine(AttackWait());
                Debug.Log("Attack");
                nextAttackTime = Time.time + 1 / attackRate;
            }
            else
            {
                //idle
                animator.SetTrigger("idle");
                //Debug.Log("wait for Attack");
            }
        }
        else if (checkFollowRadius(playerTransform))
        {
            if (playerTransform.position.x > transform.position.x)
            {
                //Follow
                animator.SetTrigger("move");
                MoveToPlayer(playerTransform);
                transform.localScale = new Vector3(2, 2, 1);
                //Debug.Log("Move");
            }
            else
            {
                animator.SetTrigger("move");
                MoveToPlayer(playerTransform);
                transform.localScale = new Vector3(-2, 2, 1);
            }
        }
        else
        {
            //idle
            animator.SetTrigger("idle");
            //Debug.Log("Idle");
        }
        HealthLastFrame = currentHealth;
    }
    public void Attack(CharacterControl player)
    {
        //attack
        if (player.getHealth > 0)
        {
            player.ChangeHealth(-attackDamage);
            Debug.Log(this.gameObject + " Attacked " + player.gameObject + " and dealed " + attackDamage + "dmg");
            Debug.Log(player.gameObject + ":Health left" + player.getHealth);
        }
    }
    IEnumerator AttackWait()
    {

        yield return new WaitForSeconds(0.3f);
        //Debug.Log(checkAttackRadius(FindObjectOfType<CharacterControl>().transform));
        topHandAttackpoint.enabled = true;
        leftHandAttackpoint.enabled = true;
        rightHandAttackpoint.enabled = true;


    }
    public void getHit(float dmg)
    {
        currentHealth -= dmg;
        Debug.Log("Hit Apply");
        //Die 
        if (currentHealth <= 0)
            Die();
    }

   
    public void Die()
    {
        StartCoroutine(DieWait());
    }
    IEnumerator DieWait()
    {
        yield return new WaitForSeconds(4);

        Destroy(gameObject);
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
    public bool checkAttackRadius(Collider2D collider2D, Transform playerTransform)
    {
        Vector3 position = collider2D.transform.position;

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
    void OnDrawGizmosSelected()
    {
        //if (attackPoint == null)
        //return;
        Vector3 position = transform.position;
        //position.y += 0.6f;
        Gizmos.DrawWireSphere(topHandAttackpoint.transform.position, attackRadius);
        Gizmos.DrawWireSphere(leftHandAttackpoint.transform.position, attackRadius);
        Gizmos.DrawWireSphere(rightHandAttackpoint.transform.position, attackRadius);

        Gizmos.DrawWireSphere(transform.position, followRadius);

    }
}
