using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public float Health = 30f;

    private Transform target;

    private Transform tf;

    private Rigidbody rb;

    private Vector3 shootPoint = new Vector3(0, (float)0.08, (float)0.8);

    public GameObject bulletPrefab;

    public float perShotDelay;

    public float speed;

    private float timestamp = 0.0f;

    public float minAttackDistance;
    private float distance;

    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        
    }

    void Update()
    {
        distance = Vector3.Distance(tf.position, target.position);
        if (distance < minAttackDistance)
        {
            if (Time.time > timestamp)
            {
                timestamp = Time.time + perShotDelay;
                Instantiate(bulletPrefab, tf.position + shootPoint, transform.rotation);
            }
        }
    }

    void FixedUpdate()
    {
        if (distance < minAttackDistance)
        {
            tf.LookAt(target.position);
            Vector3 moveDir = (transform.forward) * speed;

            rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Destroy(gameObject);
        }
    }
}
