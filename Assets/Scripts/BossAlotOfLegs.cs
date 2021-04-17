using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlotOfLegs : MonoBehaviour
{
    public float moveSpeed;
    public int attackDamage;
    public float attackRate;
    public int maxHealth;
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
        playerTransform = FindObjectOfType<CharacterControl>().GetComponent<Transform>();
        bossSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        //if (attackPoint == null)
        //return;
        Vector3 position = transform.position;
        position.y += 0.6f;
        Gizmos.DrawWireSphere(position, attackRadius);
        Gizmos.DrawWireSphere(transform.position, followRadius);

    }
}
