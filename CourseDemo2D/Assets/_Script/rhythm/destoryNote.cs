using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryNote : MonoBehaviour
{
    private bool isInHitZone = false;  // 是否在判定区域内
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
        
}

    // Update is called once per frame
    void Update()
    {
    if (isInHitZone && Input.GetKeyDown(KeyCode.Space))
    {
        Debug.Log("Perfect!");
        Destroy(gameObject); // 打中后销毁
    }
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HitLine"))
        {
           
            isInHitZone = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HitLine"))
        {
            isInHitZone = false;
        }
    }
}
