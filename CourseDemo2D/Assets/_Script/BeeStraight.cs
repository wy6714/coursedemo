using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeStraight : MonoBehaviour
{
    /*
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
        if (collision.CompareTag("BeeXPoint"))
        {
            moveX = moveX * -1;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.flipX = !sr.flipX;
        }

        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    */


    //use distance
    public Transform Left;
    public Transform Right;

    public float speed = 2f;
    public bool moveR = true;

    private SpriteRenderer sr;
    

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        //move
        if (moveR)
        {
            transform.Translate(Vector2.right *speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        //check boundary
        if(transform.position.x > Right.position.x)
        {
            sr.flipX = true;
            moveR = !moveR;
        }
        else if(transform.position.x < Left.position.x)
        {
            sr.flipX = false;
            moveR = !moveR;
        }
        
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Left.transform.position, 0.5f);
        Gizmos.DrawWireSphere(Right.transform.position, 0.5f);
    }


}
