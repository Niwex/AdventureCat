using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    [SerializeField] float fireBallDmg;
  // Start is called before the first frame update
  void Start()
  {

  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    var enemy = collision.gameObject.GetComponent<MonstersScript>();
    if (enemy != null)
    {
      enemy.getHit(fireBallDmg);
      Destroy(gameObject);
    }
  }
  // Update is called once per frame
  void Update()
  {

  }
}
