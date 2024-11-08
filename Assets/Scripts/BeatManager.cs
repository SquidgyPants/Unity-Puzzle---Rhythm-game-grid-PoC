using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float bpm;
    [SerializeField] private AudioSource song;

    [SerializeField] private GameObject player;
    //keep all the position-in-beats of notes in the song
    [SerializeField] float[] notes;
    //the index of the next note to be spawned
    [SerializeField] int nextIndex = 0;
    [SerializeField]
    //the current position of the song (in seconds)
    float songPosition,
    //the current position of the song (in beats)
    songPosInBeats,
    //the duration of a beat
    secPerBeat,
    //how much time (in seconds) has passed since the song started
    dsptimesong;

    // Start is called before the first frame update
    void Start()
    {
        //calculate how many seconds is one beat
        //we will see the declaration of bpm later
        secPerBeat = 60f / bpm;

        //Add hihat in song
        song.Play();
        //record the time when the song starts
        dsptimesong = (float)AudioSettings.dspTime;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate the position in seconds
        songPosition = (float)(AudioSettings.dspTime - dsptimesong);

        //calculate the position in beats
        songPosInBeats = songPosition / secPerBeat;

        MovePlayer();
    }

    void MovePlayer()
    {
        if (songPosInBeats - Math.Round(songPosInBeats) < 0.100f && songPosInBeats - Math.Round(songPosInBeats) > -0.100f)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {player.transform.Translate(0f, 1f, 0); }
        if (Input.GetKeyDown(KeyCode.A)) 
            {player.transform.Translate(-1f, 0f, 0); }
        if (Input.GetKeyDown(KeyCode.S)) 
            {player.transform.Translate(0f, -1f, 0); }
        if (Input.GetKeyDown(KeyCode.D)) 
            {player.transform.Translate(1f, 0f, 0); }
        }
    }

    //void CountdownEvent()
    //{
    //    switch (songPosInBeats)   
    //    {
    //        case 1:
    //            countdown.text = "3";
    //            break;
    //        case 2:
    //            countdown.text = "2";
    //            break;
    //        case 3:
    //            countdown.text = "1";
    //            break;
    //        case 4:
    //            countdown.text = "GO!";
    //            break;
    //    }
    //}
}
