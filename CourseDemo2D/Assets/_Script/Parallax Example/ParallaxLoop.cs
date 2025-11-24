using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLoop : MonoBehaviour
{
    public float speed = 0.5f; // 背景移动速度
    private float startX;      // 初始位置
    private float width;       // 图像宽度
    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;

        // 记录初始 X
        startX = transform.position.x;

        // 获取 sprite 宽度
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
    }

    void Update()
    {
        float dist = cam.position.x * speed;
        transform.position = new Vector3(startX + dist, transform.position.y, transform.position.z);

        // 判断是否超出一张图宽度，超出就重置，让图循环
        float temp = cam.position.x * (1 - speed);

        if (temp > startX + width) startX += width;
        else if (temp < startX - width) startX -= width;
    }
}
