using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform Left;
    public Transform Right;

    public float speed = 2f;
    public bool moveR = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move
        if (moveR)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        //check boundary
        if (transform.position.x > Right.position.x)
        {
            
            moveR = !moveR;
        }
        else if (transform.position.x < Left.position.x)
        {
            
            moveR = !moveR;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Left.transform.position, 0.5f);
        Gizmos.DrawWireSphere(Right.transform.position, 0.5f);
    }
}
