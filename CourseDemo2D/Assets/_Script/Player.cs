using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 direction = new Vector2(1, 1);
    void Start()
    {
        
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
    }

    
}
