using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickPuzzle : MonoBehaviour
{
    public Transform cameraTarget;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // 鼠标左键点击检测
        if (Input.GetMouseButtonDown(0))
        {
            // 从鼠标点击位置发射一条射线
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 检测是否碰到物体
            if (Physics.Raycast(ray, out hit))
            {
                // 如果点击到自己这个 Sprite 对象
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    MoveCameraToTarget();
                }
            }
        }
    }

    private void MoveCameraToTarget()
    {
        if (cameraTarget != null)
        {
            // 直接把摄像机位置设置到目标位置
            mainCamera.transform.position = cameraTarget.position;

            // 让摄像机看向目标（如果需要旋转）
            //mainCamera.transform.LookAt(cameraTarget);
        }
        else
        {
            Debug.LogWarning("Camera target not assigned!");
        }
    }
}
