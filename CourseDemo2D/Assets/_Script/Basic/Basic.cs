using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour
{
    public GameObject cubeObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cubeObj.transform.Translate(Vector2.left * 5f * Time.deltaTime);
    }
}
