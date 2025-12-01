using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class example : MonoBehaviour
{
    public float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        
    }
}
