using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystemS1 : MonoBehaviour
{
    [Header("UI Text Component")]
    public TMP_Text DialogueText;

    [Header("Dialogue Content")]
    public string[] dialogues;
    private int currentIndex = 0;

    [Header("Typing Effect")]
    public float typingSpeed = 0.03f;  // 每个字显示的间隔时间
    private Coroutine typingCoroutine;
    private bool isTyping = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // 如果还在打字，直接显示完整文字
                StopCoroutine(typingCoroutine);
                DialogueText.text = dialogues[currentIndex];
                isTyping = false;
            }
            else
            {
                ShowNextDialogue();
            }
        }
    }

    void showDialogue(int index)
    {
        if (DialogueText != null && index < dialogues.Length)
        {
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeText(dialogues[index]));
        }
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        DialogueText.text = "";
        foreach (char c in text.ToCharArray())
        {
            DialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void ShowNextDialogue()
    {
        currentIndex++;
        if (currentIndex >= dialogues.Length)
        {
            currentIndex = 0; // 循环显示，可改成不循环
        }

        showDialogue(currentIndex);
    }
}