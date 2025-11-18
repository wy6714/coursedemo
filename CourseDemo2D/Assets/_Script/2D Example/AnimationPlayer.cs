using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public SpriteRenderer sr;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 direction =new Vector2(moveX, moveY);
        
        transform.Translate(direction * speed *Time .deltaTime);

        if(moveX < 0)
        {
            sr.flipX = true;
        }else if(moveX > 0)
        {
            sr.flipX = false;
        }
    }
}
