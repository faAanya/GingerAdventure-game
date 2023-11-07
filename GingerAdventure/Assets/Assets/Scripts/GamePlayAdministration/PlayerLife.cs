using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    Slider slider;
    public float healthPlayer = 100;
    // Start is called before the first frame update
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(healthPlayer == 0f)
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
