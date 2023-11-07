using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

    public class ItemCollector : MonoBehaviour
    {
        [SerializeField] private TMP_Text mouseText;
        public static int totalScore = 0;
     

    public void Update()
    {
        mouseText.text = "Score: " + totalScore;
    }
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Mouse"))
            {
                
                Destroy(collision.gameObject);
                totalScore += 20;

            }
        }
    }
