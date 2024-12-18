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
    [SerializeField] public Player playerScript;

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
        //how many ticks have passed since the song started
        dsptimesong,
        nextBeatHit,
        prevBeatHit,
        timeToWait;

    bool isReady = false;
    bool hadStarted = false;
    bool hasBeatTriggered = false;
    private float elapsedTime = 0f;
    private float songOffset = 0.284f;


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
            //calculate the song position in seconds
            songPosition = (float)(AudioSettings.dspTime - dsptimesong);
            if (!hadStarted)
            {
                //Add hihat in song
                StartSong();

                hadStarted = true;
                songPosition = 0;
                songPosInBeats = 0;
            }
//            Debug.Log(songPosition);
            songPosInBeats = songPosition / secPerBeat - songOffset;
            Debug.Log($"songPosInBeats: {songPosInBeats}");
            prevBeatHit = songPosInBeats % 1;
            nextBeatHit = 1 - prevBeatHit;
//            playerScript.MovePlayer(prevBeatHit, nextBeatHit);
            if (prevBeatHit < 0.05f || nextBeatHit < 0.05f)
            {
                if (!hasBeatTriggered)
                {
                    hasBeatTriggered = true;
                    Debug.Log("Beat");
//                    Debug.Log($"songPosInBeats: {songPosInBeats}");
                }
            }
            else
            {
                hasBeatTriggered = false;
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
