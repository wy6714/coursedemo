using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 5f;

    [Header("鼠标视角设置")]
    public float mouseSensitivity = 100f;
    public Transform playerCamera;
    private float xRotation = 0f;

    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // 锁定鼠标
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        LookAround();
    }
    void MovePlayer()
    {
        // 获取输入
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 将方向转换为世界坐标
        Vector3 move = transform.right * x + transform.forward * z;

        // 移动角色
        controller.Move(move * moveSpeed * Time.deltaTime);
     

    }
    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 旋转摄像机
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // 旋转玩家身体
        transform.Rotate(Vector3.up * mouseX);
    }
}
