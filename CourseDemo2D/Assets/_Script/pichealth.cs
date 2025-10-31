using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pichealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public Image[] cakes;
    public Sprite cakeFull;
    public Sprite cakeEmpty;
    public bool ishurting;
    // Start is called before the first frame update
    void Start()
    {
        ishurting = false;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 玩家碰到enemy
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy") && !ishurting)
        {
            ishurting = true;
            ChangeHealth(-1);
        }
        else if (other.CompareTag("Food"))
        {
            ChangeHealth(1);
            Destroy(other.gameObject); // 吃掉食物
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            ishurting = false;
        }
    }
    void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 限制范围

        UpdateCakesUI();

        if (currentHealth <= 0)
        {
            //游戏结束
        }
    }

    void UpdateCakesUI()
    {
        for (int i = 0; i < cakes.Length; i++)
        {
            if (i < currentHealth)
                cakes[i].sprite = cakeFull;
            else
                cakes[i].sprite = cakeEmpty;
        }
    }
}
