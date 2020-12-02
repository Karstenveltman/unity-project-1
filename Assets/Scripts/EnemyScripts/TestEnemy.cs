using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
  public float Health = 30f;
  public void TakeDamage(float damage)
  {
    Health -= damage;

    if (Health < 0)
    {
      Destroy(gameObject);
    }
  }
}
