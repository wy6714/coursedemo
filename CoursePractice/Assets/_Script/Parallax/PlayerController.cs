using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private SpriteRenderer sr;

    [Header("Animation")]
    public GameObject emojiObj;
    private Animator emojiAni;

    [Header("health bar")]
    public float health;
    public float maxHealth; 
    public float width,Height;
    private RectTransform healthBar;
    public GameObject healthBarUI;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //获得emoji 动画需要的组件
        emojiAni = emojiObj.GetComponent<Animator>();

        //给healthbar ui赋值
        healthBar = healthBarUI.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(moveX, moveY);

        transform.Translate(direction * speed * Time.deltaTime);

        if(moveX < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        //test health bar
        if (Input.GetKeyUp(KeyCode.H) && health<3)
        {
            health += 1;
            updateHealthBar(health);
        }

        if (Input.GetKeyUp(KeyCode.L) && health >0)
        {
            health -= 1;
            updateHealthBar(health);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //当碰到标签为mushroom的物体，触发question emoji的动画
        if (collision.CompareTag("mushroom"))
        {
            //Debug.Log("collide");
            emojiAni.SetTrigger("questionState");

        }
    }

    private void updateHealthBar(float targetHealth)
    {
        health = targetHealth;
        float newWidth = (health / maxHealth) * width;

        healthBar.sizeDelta = new Vector2(newWidth, Height);
    }

}
