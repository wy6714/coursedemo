using UnityEngine;

public class ParkourPlayer : MonoBehaviour
{
    [Header("移动属性")]
    public float moveSpeed = 20f;     // 前进
    public float turnSpeed = 100f;    //转向

    [Header("Input")]
    public string verticalAxis;   
    public string horizontalAxis;

    private Rigidbody rb;
    private float moveInput;
    private float steerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 冻结 X 和 Z 轴旋转，防止角色碰撞时发生倾倒或不规则旋转
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

        // 3. 处理转向 (只有在有移动输入时才进行转向)
        if (Mathf.Abs(moveInput) > 0f)
        {
            float turnAmount = steerInput * turnSpeed * Time.fixedDeltaTime;
            // 倒车时的转向方向:反
            if (moveInput < 0) turnAmount = -turnAmount;

            Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

   
}
