using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public AudioSource pickupAudio;
    // Start is called before the first frame update
    void Start()
    {
        pickupAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
