using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private Vector2 moveInput;

    [Header("Bullet Attack")]
    public GameObject BulletPrefab;
    public float bulletSpeed = 8f;
    public float fireRate = 0.5f;
    public float upgradefireRate = 0.2f;

    private Vector2 lookDirection = Vector2.down;
    private float nextFireTime = 0f;

    public static event Action<GameObject> upgrade1;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //获取player移动input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //更新面朝方向（决定攻击方向）
        //if(moveInput != Vector2.zero)

        if (moveInput.sqrMagnitude > 0.01f)
        {
            lookDirection = moveInput.normalized;
        }

        //发射时间
        if(Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        
    }

    void UpdateSpriteDirection()
    {
        if (moveInput.x > 0)
        {
            spriteRenderer.sprite = spriteRight;
        }
        else if (moveInput.x < 0)
        {
            spriteRenderer.sprite = spriteLeft;
        }
        else if (moveInput.y > 0)
        {
            spriteRenderer.sprite = spriteUp;
        }
        else if (moveInput.y < 0)
        {
            spriteRenderer.sprite = spriteDown;
        }
    }

    void FixedUpdate()
    {
        
        transform.Translate(moveInput * moveSpeed * Time.deltaTime);

      
        UpdateSpriteDirection();
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

        //根据当前方向发射
        rbBullet.velocity = lookDirection * bulletSpeed;

        //子弹旋转朝向
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        //一段时间自动销毁
        Destroy(bullet, 2f);
    }

   
    public void UpgradeBullet()
    {
        fireRate -= upgradefireRate;
        upgrade1?.Invoke(gameObject);

    }





    


}
