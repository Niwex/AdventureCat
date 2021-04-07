using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    //Stats
    public float speed = 3;
    public int maxHealth = 5;
    public float attackDmg = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public int getHealth { get { return currentHealth; } }
    int currentHealth;

    //Attack stats
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayers;

    Rigidbody2D rigidbody2d;
    public Animator animator;
    float horizontal;
    float vertical;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();


        attackRadius = 1.17f;
        currentHealth = 3;
    }


    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

    }

    public void Attack()
    {
        Debug.Log(this.animator);
        this.animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy);
            enemy.GetComponent<MonstersScript>().getHit(attackDmg);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
