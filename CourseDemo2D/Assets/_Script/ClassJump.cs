using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClassJump : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpforce = 10f;
    public bool isground;

    public int healthnum = 3;
    public TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        isground = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isground)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            isground = true;
        }

        if (collision.CompareTag("enemy"))
        {
            healthnum = healthnum -1;
            healthText.text = healthnum.ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            isground = false;
        }
    }

    
}
