using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonExample : MonoBehaviour
{
    public float Speed = 5f;
    public GameObject howtoPanel;
    public string instruction = "here is how to player this game, Hope you enjoy!";
    public TMP_Text InstructionText;
    // Start is called before the first frame update
    void Start()
    {
        howtoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExampleButton()//移动目标物体功能
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    public void StratButton()//Strat Button功能：切换到游戏场景
    {
        SceneManager.LoadScene("Basic");
    }

    public void openHowtoPanel()//打开玩法介绍panel button功能
    {
        howtoPanel.SetActive(true);
        InstructionText.text = instruction;
    }
}
