using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public float killNum;
    public TMP_Text killNumText;

    [Header("UI")]
    public GameObject bulletButton;
    public bool isupgrade1;
    public GameObject circleWeaponButton;
    public bool isupgrade2;

    [Header("Upgrade")]
    public float unlockbulletNum = 10;
    public float unlockcircleNum = 3;

    private void OnEnable()
    {
        
        enemy.EnemyKilled += killNumAdded;
        PlayerMovement.upgrade1 += closeBulletButton;
    }
    private void OnDisable()
    {

        enemy.EnemyKilled -= killNumAdded;
        PlayerMovement.upgrade1 -= closeBulletButton;
    }

    void Start()
    {
        //upgrade button default setting
        bulletButton.SetActive(false);
        isupgrade1 = false;

        circleWeaponButton.SetActive(false);
        isupgrade2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        killNumText.text = killNum.ToString();


        //bullet upgrade
        if (killNum >= unlockbulletNum && !isupgrade1)
        {
            bulletButton.SetActive(true);
        }

        //circle waepon upgrade button
        if(killNum >= unlockcircleNum && !isupgrade2)
        {
            bulletButton.SetActive(true);
            circleWeaponButton.SetActive(true);
        }

    }

    private void killNumAdded(GameObject enemy)
    {
        killNum++;
    }

    public void closeBulletButton(GameObject gameobject)
    {
        bulletButton.SetActive(false);
        isupgrade1 = true;
    }

    public void closeAllButton()
    {
        circleWeaponButton.SetActive(false);
        bulletButton.SetActive(false);
        isupgrade1 = true;

        if(killNum >= unlockcircleNum)
        {
            isupgrade2 = true;
        }
        
        
    }

}
