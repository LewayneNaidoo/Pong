using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundController : MonoBehaviour
{
    public AudioSource bounce;
    public AudioSource gameMusic;

    void Start()
    {
        this.gameMusic.Play();
    }

    public void Bounce()
    {
        this.bounce.Play();
        Debug.Log("BOUNCE");
    }
}
