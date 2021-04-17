using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlotOfLegs : MonoBehaviour
{
    public float moveSpeed;
    public int attackDamage;
    public float attackRate;
    public int maxHealth;

    float currentHealth;

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void getHit(float dmg)
    {
        currentHealth -= dmg;
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
        position.y += 0.6f;
        Gizmos.DrawWireSphere(topHandAttackpoint.transform.position, attackRadius);
        Gizmos.DrawWireSphere(leftHandAttackpoint.transform.position, attackRadius);
        Gizmos.DrawWireSphere(rightHandAttackpoint.transform.position, attackRadius);
        
        Gizmos.DrawWireSphere(transform.position, followRadius);

    }
}
