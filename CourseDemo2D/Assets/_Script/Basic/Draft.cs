using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draft : MonoBehaviour
{
    public Vector3 scaleUp;
    public KeyCode TriggerKey;
    private Vector3 TempScale = new Vector3(0f, 0f, 0f);
    private Material mat;
    public Color OriginalColor;
    public Color TargetColor;

    // Start is called before the first frame update
    void Start()
    {
        TempScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(TriggerKey))
        {
            transform.localScale = scaleUp;
            mat = GetComponent<Renderer>().material;
            mat.color = TargetColor;

        }

        if(Input.GetKeyUp(TriggerKey))
        {
            transform.localScale = TempScale;
            mat.color = OriginalColor;
        }

    }
}
