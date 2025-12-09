using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ParkourPlayer : MonoBehaviour
{
    public float forwardSpeed;
    public float horizontalSpeed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;    
    }

    // Update is called once per frame
    void Update()
    {

        // 自动向前
        Vector3 velocity = transform.forward * forwardSpeed;

        // 左右移动
        float horizontalInput = Input.GetAxis("Horizontal"); // -1 ~ 1
        velocity += transform.right * horizontalInput * horizontalSpeed;

        // 保留角色自身原本的 y 方向速度（例如重力）
        velocity.y = rb.velocity.y;

        // 给刚体设置速度
        rb.velocity = velocity;
    }
}
