using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public Camera cam;

    private Transform tf;

    public GameObject bulletPrefab;

    private Vector3 shootPoint = new Vector3(0, 0, (float)0.04);

    public float Ammo = 100;

    public float ammoInMag = 10f;

    private float magSize = 10f;

    private float BulletsPerShot = 9;

    private float ShotSpread = 5.0f;

    void Start()
    {
      tf = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Update()
    {
      if (Input.GetButtonDown("Fire1"))
      {
        if (ammoInMag > 0)
        {
          for (int i = 0; i < BulletsPerShot; i++)
          {
            Shoot();
          }
          ammoInMag -= 1;
        }
      }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, tf.position + shootPoint, tf.rotation * Quaternion.Euler(Random.Range(-ShotSpread, ShotSpread), Random.Range(-ShotSpread, ShotSpread), Random.Range(-ShotSpread, ShotSpread)));
        Debug.Log("Pew!!");
    }

    void Reload()
    {

    }
}
