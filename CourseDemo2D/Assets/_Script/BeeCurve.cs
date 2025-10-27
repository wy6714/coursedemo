using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCurve : MonoBehaviour
{
    public Transform Top;
    public Transform Bottom;
    public Transform Right;
    public Transform Left;


    public float moveX;
    public float moveY;
    public float speed;
    //public Vector2 moveDirection;

    private void Start()
    {
        moveX = 1;
        moveY = Random.Range(0f, 1f);
        //moveDirection = new Vector2(moveX, moveY);
    }

    private void Update()
    {

        transform.Translate(new Vector2(moveX,moveY) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BeeXPoint"))
        {
            moveX = -moveX;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.flipX = !sr.flipX;
        }
        if (collision.CompareTag("BeeYPoint"))
        {
            if (moveY > 0)
            {
                moveY = -moveY;
                Debug.Log(">0" + moveY);
            }
            else
            {
                moveY = Random.Range(0f, 1f);
                Debug.Log("<0" + moveY);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Right.transform.position, new Vector3(1, 3, 1));
        Gizmos.DrawWireCube(Left.transform.position, new Vector3(1, 3, 1));

        Gizmos.DrawWireCube(Top.transform.position, new Vector3(6,1,1));
        Gizmos.DrawWireCube(Bottom.transform.position, new Vector3(6,1,1));
    }

}