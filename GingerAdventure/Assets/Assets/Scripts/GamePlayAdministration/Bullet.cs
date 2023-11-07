using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public float speed = 10f;
    public int damage = 34;
    public Rigidbody2D rb;
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        //rb.velocity = transform.right * speed;
    }

     void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Health health = hitInfo.GetComponent<Health>();
        EnemyShooting enemyHealth = hitInfo.GetComponent<EnemyShooting>();
        if(health != null)
        {
            health.TakeDamage(damage);
        }
        if (!hitInfo.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
       
    }


}
