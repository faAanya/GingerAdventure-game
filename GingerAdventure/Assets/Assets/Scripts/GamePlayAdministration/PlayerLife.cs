using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float healthMax = 100.0f;
    public float currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = healthMax;
        healthBar.SetMaxHealth(healthMax);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0f)
        {
            Die();
            RestartLevel();
        }
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
      
    }


    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("TriggerDeath");
        
    }
    private void RestartLevel()
    {
        ItemCollector.totalScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

}
