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
    void Die()
    {
        Destroy(terrain);
    }
}
