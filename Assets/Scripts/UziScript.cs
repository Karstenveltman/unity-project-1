using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziScript : MonoBehaviour
{
    public Camera cam;

    private Transform tf;

    public GameObject bulletPrefab;

    private Vector3 shootPoint = new Vector3(0, 0, (float)0.04);

    public float Ammo = 100;

    public float perShotDelay = 0.1f;

    private float timestamp = 0.0f;

    void Start()
    {
        tf = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timestamp)
        {
            timestamp = Time.time + perShotDelay;
            if (Ammo > 0)
            {
                Shoot();
                Ammo -= 1;
            }
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, tf.position, transform.rotation);
    }

}
