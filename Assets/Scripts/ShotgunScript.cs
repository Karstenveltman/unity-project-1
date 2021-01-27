using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public Camera cam;

    private Transform tf;

    public GameObject bulletPrefab;

    public GameObject KnockbackBulletPrefab;

    private Vector3 shootPoint = new Vector3(0, 0, (float)0.04);

    public float Ammo = 100;

    private float BulletsPerShot = 18;

    private float ShotSpread = 3.0f;

    void Start()
    {
      tf = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Ammo > 0)
            {
                for (int i = 0; i < BulletsPerShot; i++)
                {
                    Shoot();
                }
                Shoot2();
                Ammo -= 1;
            }
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, tf.position + shootPoint, tf.rotation * Quaternion.Euler(Random.Range(-ShotSpread, ShotSpread), Random.Range(-ShotSpread, ShotSpread), Random.Range(-ShotSpread, ShotSpread)));
    }

    public void Shoot2()
    {
        Instantiate(KnockbackBulletPrefab, tf.position + shootPoint, tf.rotation);
    }

    void Reload()
    {

    }
}
