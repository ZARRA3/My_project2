using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // movement ball
    public float speed = 100.0f;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
    float HitFactor(Vector2 ballpos, Vector2 racketpos, float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1 <- x value
        //
        // =================== <- racket
        //
        return (ballpos.x - racketpos.x) / racketWidth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Hit thr Racket ?
        float x = HitFactor(transform.position,
                          collision.transform.position,
                          collision.collider.bounds.size.x);
        // Calculate direction, set lenth to 1 
        Vector2 dir = new Vector2(x, 1).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
}
