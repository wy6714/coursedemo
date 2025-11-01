using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 direction = new Vector2(1, 1);
    public int healthnum;
    public TMP_Text healthtext;

    public bool ishurting;

    //jump
    public float jumpForce = 10f;    // 跳跃高度
    private Rigidbody2D rb;          // 引用 Rigidbody2D component
    private bool isGrounded;        // flag 检测是否玩家在地面，避免空中连跳

    void Start()
    {
        ishurting = false;
        healthnum = 3;
        healthtext.text = healthnum.ToString();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * 2f * Time.deltaTime);
        //transform.Translate(new Vector2(1, 1) * 2f * Time.deltaTime);
        //transform.Translate(direction * 2f * Time.deltaTime);

        float moveX = Input.GetAxis("Horizontal");

        Vector2 Movement = new Vector2(moveX, 0);

        transform.Translate(Movement * 2f * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy")&& ishurting == false)
        {
            ishurting = true;
            healthnum -= 1;
            healthtext.text = healthnum.ToString();
        }
        if (collision.CompareTag("ground"))
        {
            isGrounded = true; // Player is on the ground
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy") && ishurting == true)
        {
            ishurting = false;
        }
        if (collision.CompareTag("ground"))
        {
            isGrounded = false; // Player is no longer grounded
        }
    }


}
