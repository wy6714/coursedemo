using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleWeapon : MonoBehaviour
{
    public GameObject circleWeaponObj;

  
    // Start is called before the first frame update
    void Start()
    {
        // turn off as default
        circleWeaponObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if enemy touched this weapon, destroy enemy
        if (collision.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator circleWeaponFunction()
    {
        while (true)
        {
            circleWeaponObj.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            circleWeaponObj.SetActive(false);
            yield return new WaitForSeconds(3f);
        }
    }

    public void UnlockCircleWeapon()
    {
        StartCoroutine(circleWeaponFunction());
    }
}
