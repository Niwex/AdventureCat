using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    [SerializeField] float fireBallDmg;
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<MonstersScript>();
        var boss = collision.gameObject.GetComponent<BossAlotOfLegs>();
        if (enemy != null)
        {
            enemy.getHit(fireBallDmg);
            Destroy(gameObject);
        }
        if (boss != null)
        {
            boss.getHit(fireBallDmg + 50);
            Destroy(gameObject);
        }
    }
    
   
}
