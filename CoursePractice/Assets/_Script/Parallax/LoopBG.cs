using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoopBG : MonoBehaviour
{
    private float startPos, length;
    public GameObject Cam;
    public float parallaxEffect;// move width relative to cam
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate bg move based on cam move
        float distance = Cam.transform.position.x * parallaxEffect;// 0 = move with cam || 1 = won't move || 0.5 = move half
        float movement = Cam.transform.position.x * (1 - parallaxEffect);
        //float movement = Cam.transform.position.x;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        //if bg has reached the end of its length adjust its position for infinite scrolling
        if (movement > startPos + length)
        {
            startPos += length;
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
