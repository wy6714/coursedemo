using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Crab : MonoBehaviour
{

    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;//计时
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 2f * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fish"))
        {
            float solve1Time = Time.time - startTime;

            RecordTime(solve1Time);
            Debug.Log(solve1Time.ToString());
            
        }
    }

    void RecordTime(float time)
    {
        string filepath = "Assets/TestTimeLog.csv";

        if (!File.Exists(filepath))
        {
            File.WriteAllText(filepath,"time/s ，level, death \n");   
        }

        File.AppendAllText(filepath, time.ToString() + "\n");
        
            

        
    }
}
