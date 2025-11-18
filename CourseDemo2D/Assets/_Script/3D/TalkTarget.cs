using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTarget : MonoBehaviour
{
    public GameObject dialogueUI;
    // Start is called before the first frame update
    void Start()
    {
        //close dialogue panel
        dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // if collide with talk target, show dialogue
        if (other.CompareTag("Player"))
        {
            dialogueUI.SetActive(true);
        }
    }
}
