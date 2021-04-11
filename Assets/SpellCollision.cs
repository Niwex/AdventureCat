using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    if (enemy != null)
    {
      enemy.TakeDamage(5);
      Destroy(gameObject);
    }
  }
  // Update is called once per frame
  void Update()
  {

  }
}
