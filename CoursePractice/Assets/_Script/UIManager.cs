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
    public GameObject BuffButton;
    public bool isupgrade3;

    [Header("Upgrade")]
    public float unlockbulletNum = 10;
    public float unlockcircleNum = 3;
    public float unlockbuffNum = 15;

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

        BuffButton.SetActive(false);
        isupgrade3 = false;
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

        if(killNum >= unlockbuffNum && !isupgrade3)
        {
            bulletButton.SetActive(true);
            circleWeaponButton.SetActive(true);
            BuffButton.SetActive(true);
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
        if (killNum >= unlockcircleNum)
        {
            isupgrade2 = true;
            circleWeaponButton.SetActive(true);
        }
        if(killNum >= unlockbuffNum)
        {
            isupgrade3 = true;
            BuffButton.SetActive(false);
        }
    }

    public void closeCircleButton()
    {
        circleWeaponButton.SetActive(false);
        isupgrade2 = true;
       
        if (killNum >= unlockbuffNum)
        {
            isupgrade3 = true;
        }
    }

    public void closeBuffButton()
    {
        BuffButton.SetActive(false);
        isupgrade3 = true;
    }

    public void closeAllButton()
    {
        bulletButton.SetActive(false);
        isupgrade1 = true;
        //circleWeaponButton.SetActive(false);
        //bulletButton.SetActive(false);
        //BuffButton.SetActive(false);
        //isupgrade1 = true;

        if (killNum >= unlockcircleNum)
        {
            isupgrade2 = true;
            circleWeaponButton.SetActive(false);
        }

        if(killNum >= unlockbuffNum)
        {
            isupgrade3 = true;
            BuffButton.SetActive(false);
        }

    }

}
