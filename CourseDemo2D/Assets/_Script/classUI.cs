using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class classUI : MonoBehaviour
{
    public TMP_Text healthText;
    public int healthnum = 3;

    public GameObject listpanel;

    public GameObject checkmark;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = healthnum.ToString();
        checkmark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeButton()
    {
        listpanel.SetActive(false);
    }



}
