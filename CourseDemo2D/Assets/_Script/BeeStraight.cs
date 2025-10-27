using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeStraight : MonoBehaviour
{
    
    //直飞
    public GameObject Left;
    public GameObject Right;

    public float speed;
    public float moveX = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(moveX, 0) * speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Left.transform.position, 0.5f);
        Gizmos.DrawWireSphere(Right.transform.position, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BeeMove"))
        {
            moveX = moveX * -1;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.flipX = !sr.flipX;
        }
    }
    

}
