using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxSingle : MonoBehaviour
{
    public float scrollSpeed;  // 背景滚动速度
    private float width;            // 图片宽度
    private Vector3 startPos;       // 初始位置

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
        startPos = transform.position;
    }

    void Update()
    {
        // 每帧移动背景
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // 如果移动超过一张图的宽度，把它拉回初始位置
        if (transform.position.x <= startPos.x - width)
        {
            transform.position = startPos;
        }
    }
}
