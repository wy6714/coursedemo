using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 direction = new Vector2(1, 1);
    public int healthnum;
    public TMP_Text healthtext;

    public bool ishurting;

    void Start()
    {
        ishurting = false;
        healthnum = 3;
        healthtext.text = healthnum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * 2f * Time.deltaTime);
        //transform.Translate(new Vector2(1, 1) * 2f * Time.deltaTime);
        //transform.Translate(direction * 2f * Time.deltaTime);

        float moveX = Input.GetAxis("Horizontal");

        Vector2 Movement = new Vector2(moveX, 0);

        transform.Translate(Movement * 2f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy")&& ishurting == false)
        {
            ishurting = true;
            healthnum -= 1;
            healthtext.text = healthnum.ToString();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy") && ishurting == true)
        {
            ishurting = false;
        }
    }


}
