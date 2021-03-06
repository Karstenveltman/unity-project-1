﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed;

    private float lifeTime = 10f;

    private Transform tf;

    private Rigidbody rb;

    private Vector3 dir;

    private PlayerHealth playerHealth;

    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        rb.AddForce(tf.forward.x * speed, tf.forward.y * speed, tf.forward.z * speed, ForceMode.Impulse);
        StartCoroutine(WaitThenDie());
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerHealth.playerHealth -= 1;
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