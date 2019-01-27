using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CinematicController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    // Update is called once per frame
    void Update()
    {
        if(videoPlayer.frame >= (long)videoPlayer.frameCount)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
