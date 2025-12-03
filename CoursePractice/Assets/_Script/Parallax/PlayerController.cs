using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();   
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
}
