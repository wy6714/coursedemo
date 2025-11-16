using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform player;
    public float speed;
    //public Vector2 movedirec;

    private Rigidbody2D rb;

    //Event
    public static event Action<GameObject> EnemyKilled;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(movedirec * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            
            Vector2 direction = (player.transform.position - transform.position).normalized;

            
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            EnemyKilled?.Invoke(gameObject);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
