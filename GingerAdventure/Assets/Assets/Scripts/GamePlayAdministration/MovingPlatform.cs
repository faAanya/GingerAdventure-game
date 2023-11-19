using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA, pointB;
    //private Rigidbody2D rb;
    //private Animator anim;
    Vector2 currentPoint;
    public float speed;

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //currentPoint = pointB.transform;
        currentPoint = pointB.position;
        //anim.SetBool("isRunning",true);
    }


    private void Update()
    {
        //Vector2 point = currentPoint.position - transform.position;

        //if(currentPoint == pointB.transform)
        //{
        //    rb.velocity = new Vector2(speed, 0);
        //}
        //else
        //{
        //    rb.velocity = new Vector2(-speed, 0);
        //}

        //if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        //{
        //    Flip();
        //    currentPoint = pointA.transform;
        //}
        //if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        //{
        //    Flip();
        //    currentPoint = pointB.transform;
        //}

        if (Vector2.Distance(transform.position, pointA.position) < .1f)
        {
            Flip();
            currentPoint = pointB.position;
        }

        if (Vector2.Distance(transform.position, pointB.position) < .1f)
        {
            Flip();
            currentPoint = pointA.position;
        }



        transform.position = Vector2.MoveTowards(transform.position, currentPoint, speed * Time.deltaTime);

    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        collision.transform.SetParent(this.transform);
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        collision.transform.SetParent(null);
    //    }
    //}


    /// <summary>
    /// Draws UI between start and end point 
    /// </summary>
    private void OnDrawGizmos()
    {

        //Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        //Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);

    }

    /// <summary>
    /// Flips object by Ox axes
    /// </summary>
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}