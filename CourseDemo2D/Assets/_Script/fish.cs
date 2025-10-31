using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    public Transform LeftBoundary;
    public Transform RightBoundary;

    public float speed = 2f;
    public bool moveR = true;

    public SpriteRenderer sr;

    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveR)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if(transform.position.x > RightBoundary.position.x)
        {
            moveR = !moveR;
            sr.flipX = true;
        }
        else if(transform.position.x < LeftBoundary.position.x)
        {
            moveR = !moveR;

        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(LeftBoundary.position, 0.5f);
        Gizmos.DrawWireSphere(RightBoundary.position, 0.5f);

    }


}
