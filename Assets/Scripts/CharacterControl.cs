﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    //Stats
    public float speed = 3;
    public float maxHealth;
    public float attackDmg = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public float getHealth { get { return currentHealth; } }
    float currentHealth;

    //Attack stats
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayers;

    Rigidbody2D rigidbody2d;
    public Animator animator;
    float horizontal;
    float vertical;
    Vector2 lookDirection = new Vector2(1, 0);
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();


        attackRadius = 1.17f;
        currentHealth = maxHealth/2;
    }


    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Move X", lookDirection.x);
        //animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("speed", move.magnitude);

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

    public void ChangeHealth(float amount)
    {
        animator.SetTrigger("getHit");
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("health  " + currentHealth);
    }

    public void Attack()
    {
        Debug.Log(this.animator);
        this.animator.SetTrigger("attack");
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
