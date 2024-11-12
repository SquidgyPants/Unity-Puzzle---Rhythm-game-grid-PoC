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

    [SerializeField] private Player player;

    [SerializeField] private GameObject ghost;
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

    bool isReady = false;
    bool hadStarted = false;
    private float elapsedTime = 0f;
    float ghostPositionIndex = 0;
    Vector3[] ghostTargetPosition = new Vector3[3];

    // Start is called before the first frame update
    void Start()
    {

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
                dsptimesong = (float)AudioSettings.dspTime;
                SpawnGhost();
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
            songPosition = (float)(AudioSettings.dspTime);

            //calculate the position in beats
            songPosInBeats = songPosition / secPerBeat;
            MovePlayer();
            if (songPosInBeats % 1 == 0)
            {
                MoveGhost();
                ghostPositionIndex++;
            }
        }
    }

    void MovePlayer()
    {
        if (Mathf.Round(songPosInBeats) - songPosInBeats < 0.140f && Mathf.Round(songPosInBeats) - songPosInBeats > -0.060f)
        {
            Debug.Log(songPosInBeats);
            if (Input.GetKeyDown(KeyCode.W) && player.transform.position.y < 8)
            { player.transform.Translate(0f, 1f, 0); }
            if (Input.GetKeyDown(KeyCode.A) && player.transform.position.x > 0)
            { player.transform.Translate(-1f, 0f, 0); }
            if (Input.GetKeyDown(KeyCode.S) && player.transform.position.y > 0)
            { player.transform.Translate(0f, -1f, 0); }
            if (Input.GetKeyDown(KeyCode.D) && player.transform.position.x < 15)
            { player.transform.Translate(1f, 0f, 0); }
        }

    }

    public void MoveGhost()
    {
        if (ghostPositionIndex > 2)
        {
            switch (ghostPositionIndex % 3)
            {
                case 0:
                    ghostTargetPosition[0] = player.transform.position;
                    break;
                case 1:
                    ghostTargetPosition[1] = player.transform.position;
                    break;
                case 2:
                    ghostTargetPosition[2] = player.transform.position;
                    break;
            }
        }
    }

    void StartSong()
    {
        song.Play();
    }

    void SpawnGhost()
    {
        ghost.transform.position = new Vector3(0f, 8f, 0f);
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
