using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlotOfLegs : MonoBehaviour
{
    public float _moveSpeed;
    public int _attackDamage;
    public float _attackRate;
    public int _maxHealth;
    public float _attackRadius;

    float _nextAttackTime = 0f;
    //movement
    public float _followRadius;
    //end
    
    //[SerializeField] Transform playerTransform;
    [SerializeField] Animator bossAnimator;
    SpriteRenderer enemySR;
    void Start()
    {
        
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
        Gizmos.DrawWireSphere(position, _attackRadius);
        Gizmos.DrawWireSphere(transform.position, _followRadius);

    }
}
