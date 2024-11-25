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
        //song position in ticks
        songPositionInTicks,
        //how many ticks have passed since the song started
        dsptimesong,
        nextBeatHit,
        prevBeatHit,
        timeToWait;

    bool isReady = false;
    bool hadStarted = false;
    private float sampleRate = 1f / 48000f;
    private float elapsedTime = 0f;
    private float songOffset = 0.034f;


    // Start is called before the first frame update
    void Start()
    {
        //calculate how many seconds is one beat
        secPerBeat = 60f / bpm;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 2f)
            {
                isReady = true;
            }
        }
        if (isReady)
        {
            //songPosition = song.time;
            songPositionInTicks = (float)(AudioSettings.dspTime - dsptimesong);
            //calculate the position in seconds
            songPosition = songPositionInTicks / sampleRate;
            if (!hadStarted)
            {
                //Add hihat in song
                StartSong();

                hadStarted = true;
                songPosition = 0;
                songPosInBeats = 0;
            }
            Debug.Log(songPosition);
            songPosInBeats = songPosition / secPerBeat - songOffset;
//            Debug.Log($"songPosInBeats: {songPosInBeats}");
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
            dsptimesong = (float)AudioSettings.dspTime;
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
