using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ParkourPlayer : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 20f;     // 前进速度
    public float turnSpeed = 100f;    // 转向速度

    [Header("输入设置")]
    public string verticalAxis;   // 填入 Input Manager 里的名称
    public string horizontalAxis;

    private Rigidbody rb;
    private float moveInput;
    private float steerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 冻结旋转，防止卡丁车像球一样乱滚，转向由代码控制
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // 1. 获取输入
        moveInput = Input.GetAxis(verticalAxis);
        steerInput = Input.GetAxis(horizontalAxis);
    }

    void FixedUpdate()
    {
        // 2. 处理前进/后退
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // 3. 处理转向 (只有在移动时才能转向)
        if (Mathf.Abs(moveInput) > 0f)
        {
            float turnAmount = steerInput * turnSpeed * Time.fixedDeltaTime;
            // 如果是在倒车，转向反向
            if (moveInput < 0) turnAmount = -turnAmount;

            Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

    /*
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
    */
}
