using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackBulletScript : MonoBehaviour
{
    public float speed = 100f;
    private float lifeTime = 10f;
    private Transform tf;
    private Rigidbody rb;
    private Rigidbody rbPlayer;
    private Vector3 dir;
    private GameObject player;

    public float knockbackForce;
    public float knockbackRadius;

    void Start()
    {
        player = GameObject.Find("Player");
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rbPlayer = player.GetComponent<Rigidbody>();
        rb.AddForce(tf.forward.x * speed, tf.forward.y * speed, tf.forward.z * speed, ForceMode.Impulse);
        StartCoroutine(WaitThenDie());
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Ground")
        {
            rbPlayer.AddExplosionForce(knockbackForce, transform.position, knockbackRadius, 0f, ForceMode.Acceleration);
            Destroy(gameObject);
        }
    }

    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void KnockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, knockbackRadius);

        foreach (Collider nearby in colliders)
        {
            Rigidbody rigg = nearby.GetComponent<Rigidbody>();
            if(rigg != null)
            {
                rigg.AddExplosionForce(knockbackForce, transform.position, knockbackRadius);
            }
        }
    }
    //collision.transform.gameObject.layer == LayerMask.NameToLayer("Player")
}