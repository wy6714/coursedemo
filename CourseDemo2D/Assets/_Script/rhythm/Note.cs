using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float speed = 5f;
    private bool canBeHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // 玩家按下攻击键且在判定区
        if (canBeHit && Input.GetKeyDown(KeyCode.Space))
        {
            HitNote();//攻击类型
        }

        // 超出屏幕下方自动销毁
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void HitNote()//()读攻击类型
    {
        //根据攻击类型发动攻击
        Debug.Log("发动xx攻击");
        Destroy(gameObject);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HitLine"))
        {
            canBeHit = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HitLine"))
        {
            canBeHit = false;
        }
    }

}
