using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFireball : MonoBehaviour
{
  [SerializeField] float throwSpeed = 5;

  public int damage = 5;


  public void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log(collision);
    Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    if (enemy != null)
    {
      enemy.TakeDamage(damage);
    }

    Destroy(this.gameObject);
  }
  void Update()
  {
    transform.Translate(throwSpeed * Time.deltaTime, 0, 0);
    // transform.position = new Vector3(
    //   transform.position.x + (throwSpeed * Time.deltaTime),
    //   transform.position.y,
    //   transform.position.z
    // );

  }
}
