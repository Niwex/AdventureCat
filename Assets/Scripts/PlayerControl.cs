using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  //Stats
  public GameObject fireBall;

  public float speed = 3;
  public int maxHealth = 6;
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

  void FireAttack()
  {
    int fireBallNumber = 5;
    float fireBallStartRadius = 4f;
    for (int i = 0; i < fireBallNumber; i++)
    {
      Debug.Log("here");
      // float angle = piMultiplier * Mathf.PI;


      float x = fireBallStartRadius;
      Vector3 pos = transform.position + new Vector3(fireBallStartRadius, fireBallStartRadius);
      // float angleDegrees = -angle * Mathf.Rad2Deg;
      Quaternion rot = Quaternion.Euler(i * 45, 0, 0);
      Instantiate(fireBall, pos, rot);
    }
  }
  void Update()
  {

    horizontal = Input.GetAxis("Horizontal");
    vertical = Input.GetAxis("Vertical");
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
      FireAttack();
      // int piMultiplier = 1;

    }
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
