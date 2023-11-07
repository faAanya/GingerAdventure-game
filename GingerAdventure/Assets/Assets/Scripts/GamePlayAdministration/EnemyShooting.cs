using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    private float timer;
    private GameObject player;
    public int health = 80;
    private Animator anim;
  

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if ((!PauseMenu.isPaused))
        {
            if (health > 0)
            {
                if (distance < 10)
                {
                    timer += Time.deltaTime;
                    if (timer > 2)
                    {
                        timer = 0;
                        Shoot();
                    }

                }

            }
        }

    }
    void Shoot()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            anim.SetTrigger("EnemyTriggerDeath");
            Invoke("EnemyDie", 3);
        }
    }
    public void EnemyDie()
    {
        ItemCollector.totalScore += 10;
        Destroy(gameObject);
    }
}
