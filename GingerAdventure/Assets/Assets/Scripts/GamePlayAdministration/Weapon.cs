using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Weapon : MonoBehaviour
{
    public Transform shotPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    // Update is called once per frame
    void Update()
    {
        if ((!PauseMenu.isPaused))
        {

            Vector2 pawPosition = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - pawPosition;
            transform.right = direction;
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }
    void Shoot()

    {

       GameObject newBullet =  Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
    }
}
