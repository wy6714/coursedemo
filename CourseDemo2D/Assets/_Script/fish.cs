using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    public Transform LeftBoundary;
    public Transform RightBoundary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(LeftBoundary.position, 0.5f);
        Gizmos.DrawSphere(RightBoundary.position, 0.5f);

    }


}
