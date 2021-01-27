using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 100f;

    private float lifeTime = 10f;

    private Transform tf;

    private Rigidbody rb;

    private Vector3 dir;

    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(tf.forward.x * speed, tf.forward.y * speed, tf.forward.z * speed,ForceMode.Impulse);
        StartCoroutine(WaitThenDie());
    }

    void OnTriggerEnter(Collider collision)
    {
      if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
      {
        Debug.Log("pokrgokgrokrgkogrok");
        collision.transform.gameObject.SendMessage("TakeDamage", 10);
      }
      else if (collision.transform.gameObject.layer != LayerMask.NameToLayer("Bullets") && collision.transform.gameObject.layer != LayerMask.NameToLayer("Player"))
      {
        Destroy(gameObject);
      }
    }

    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
