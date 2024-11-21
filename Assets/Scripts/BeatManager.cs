using System;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float bpm;
    [SerializeField] private AudioSource song;
    [SerializeField] public TextMeshProUGUI countdown;

    //keep all the position-in-beats of notes in the song
    [SerializeField] float[] notes;
    //the index of the next note to be spawned
    [SerializeField] int nextIndex = 0;

    //the current position of the song (in seconds)
    public float songPosition,
        //the current position of the song (in beats)
        songPosInBeats,
        //the duration of a beat
        secPerBeat,
        //how much time (in seconds) has passed since the song started
        dsptimesong,
        nextBeatHit,
        prevBeatHit;

    bool isReady = false;
    bool hadStarted = false;
    private float elapsedTime = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (!isReady)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 2f)
            {
                //SpawnGhost();
                dsptimesong = (float)AudioSettings.dspTime;
                isReady = true;
            }
        }

        if (isReady)
        {
            if (!hadStarted)
            {
                //calculate how many seconds is one beat
                //we will see the declaration of bpm later
                secPerBeat = 60f / bpm;

                //Add hihat in song
                StartSong();
                //record the time when the song starts
                hadStarted = true;
            }
            //calculate the position in seconds
            songPosition = (float)(AudioSettings.dspTime) - dsptimesong;
            
            //calculate the position in beats
            songPosInBeats = songPosition / secPerBeat;
            prevBeatHit = songPosInBeats % 1;
            nextBeatHit = 1 - prevBeatHit;
            
        }
    }

   

    void StartSong()
    {
        song.Play();
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
