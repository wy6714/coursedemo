using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class createNote : MonoBehaviour
{
    public GameObject notePrefab;
    public Vector2 xRange = new Vector2(-5f, 5f);
    public Vector2 yRange = new Vector2(-2f, 2f);


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNoteRoutine());
    }
    IEnumerator SpawnNoteRoutine()
    {
        while (true)
        {
            SpawnNote();
            yield return new WaitForSeconds(1f); // 等待1秒再继续
        }
    }

    // Update is called once per frame
    void Update()
    {
        //InvokeRepeating(nameof(SpawnNote), 0f, 10f);
    }

    void SpawnNote()
    {
        // 在给定范围内随机生成坐标
        float randomX = Random.Range(xRange.x, xRange.y);
        float randomY = Random.Range(yRange.x, yRange.y);

        Vector2 spawnPos = new Vector2(randomX, randomY);
        GameObject note = Instantiate(notePrefab, spawnPos, Quaternion.identity);

        // 如果预制体有 SpriteRenderer，则随机改变颜色
        SpriteRenderer sr = note.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = Random.ColorHSV();
            // ↑ ColorHSV() 会生成亮度和饱和度都不错的随机颜色
        }
    }

   
}
