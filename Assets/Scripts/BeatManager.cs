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
        songPosInBeats = 0,
        //the duration of a beat
        secPerBeat,
        //how much time (in seconds) has passed since the song started
        dsptimesong,
        nextBeatHit,
        prevBeatHit,
        timeToWait;

    bool isReady = false;
    bool hadStarted = false;
    private float elapsedTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        secPerBeat = 60f / bpm;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady)
        {
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
            if (elapsedTime >= 2f)
            {
                isReady = true;
            }
        }

//        if (isReady)
//            {
//                if (!hadStarted)
//                {
//                    StartSong();
//                    hadStarted = true;
//                    songPosition = 0;
//                    songPosInBeats = 0;
//                }
//
//                songPosition = (float)(AudioSettings.dspTime) - dsptimesong;
//                songPosInBeats = songPosition / secPerBeat;
//                Debug.Log($"songPosInBeats: {songPosInBeats}");
//                prevBeatHit = songPosInBeats % 1;
//                nextBeatHit = 1 - prevBeatHit;
//                Debug.Log($"prevBeatHit: {prevBeatHit}, nextBeatHit: {nextBeatHit}");
//            }
        if (isReady)
        {
            songPosition = song.time;
//            songPosition = (float)(AudioSettings.dspTime) - dsptimesong;
            if (!hadStarted)
            {
                //calculate how many seconds is one beat
                //we will see the declaration of bpm later

                //Add hihat in song
                StartSong();
                //record the time when the song starts
                hadStarted = true;
                songPosition = 0;
                songPosInBeats = 0;
            }
            //calculate the position in seconds


            //calculate the position in beats
            songPosInBeats = songPosition / secPerBeat;
            Debug.Log($"songPosInBeats: {songPosInBeats}");
            prevBeatHit = songPosInBeats % 1;
            nextBeatHit = 1 - prevBeatHit;
            if (prevBeatHit < 0.1f && nextBeatHit < 0.1f)
            {
                Debug.Log("Beat");
            }
        }
    }



    void StartSong()
    {
        if (song != null)
        {
//            dsptimesong = (float)AudioSettings.dspTime;
            song.Play();
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
