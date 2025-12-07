using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private SpriteRenderer sr;

    [Header("Animation")]
    public GameObject emojiObj;
    private Animator emojiAni;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //获得emoji 动画需要的组件
        emojiAni = emojiObj.GetComponent<Animator>();
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
}
