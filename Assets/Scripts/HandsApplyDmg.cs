using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsApplyDmg : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.GetComponent<CharacterControl>().ChangeHealth(-gameObject.GetComponentInParent<BossAlotOfLegs>().attackDamage);
        }
        Debug.Log(other + " in trigger" + gameObject);
        //other.GetComponent<CharacterControl>().ChangeHealth(-gameObject.GetComponentInParent<BossAlotOfLegs>().attackDamage);
        //this.enabled = false;
    }
}
