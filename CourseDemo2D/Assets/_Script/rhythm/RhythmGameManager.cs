using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    public AudioSource musicSource;
    public float bpm = 120f;

    public GameObject noteprefab;
    public Transform SpawnPoint;

    private float beatInteral;//time between notes
    private int nextBeatIndex = 0;
    private bool musicStart = false;
     
    // Start is called before the first frame update
    void Start()
    {
        beatInteral = 60f / bpm; //0.5
    }

    // Update is called once per frame
    void Update()
    {
        //start
        if (!musicStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartMusic();
            }
            return;
        }

        //which beat now
        float songPosition = musicSource.time;
        int currentBeatIndex = Mathf.FloorToInt(songPosition / beatInteral);

        //if spwan new note
        if(currentBeatIndex <= nextBeatIndex)
        {
            SpawnNote();
            nextBeatIndex++;
        }

    }

    void StartMusic()
    {
        Debug.Log("music start");
        musicSource.Play();
        musicStart = true;
        nextBeatIndex = 0;
    }

    void SpawnNote()
    {
        Instantiate(noteprefab, SpawnPoint.position, Quaternion.identity);
    }
}
