using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public GameObject terrain;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(20);
        }
    }

    void Die()
    {
        Destroy(terrain);
    }
}
