using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private BeatManager beatManager;

    private float Offset = 0.150f;

    public void Start()
    {
        playerTransform.position = new Vector3(0, 8, 0);
    }

    public void Update()
    {
//        var watch = System.Diagnostics.Stopwatch.StartNew();
        MovePlayer();
//        watch.Stop();
//        float elapsedMs = watch.ElapsedMilliseconds;
//        Debug.Log(elapsedMs);
    }

    public void MovePlayer(/*float prevBeatHit, float nextBeatHit*/)
    {
        if (beatManager.songPosInBeats % 1 < Offset || 1 - (beatManager.songPosInBeats % 1) < Offset)
        {
            renderer.color = Color.green;
            if (Input.GetKeyDown(KeyCode.W) && playerTransform.position.y < 8)
            {
                playerTransform.Translate(0f, 1f, 0);
                Debug.Log($"Song position in beats: {beatManager.songPosInBeats}, Song position in seconds:  {beatManager.songPosition}");
            }
            if (Input.GetKeyDown(KeyCode.A) && playerTransform.position.x > 0)
            {
                playerTransform.Translate(-1f, 0f, 0);
                Debug.Log($"Song position in beats: {beatManager.songPosInBeats}, Song position in seconds:  {beatManager.songPosition}");
            }
            if (Input.GetKeyDown(KeyCode.S) && playerTransform.position.y > 0)
            {
                playerTransform.Translate(0f, -1f, 0);
                Debug.Log($"Song position in beats: {beatManager.songPosInBeats}, Song position in seconds:  {beatManager.songPosition}");
            }
            if (Input.GetKeyDown(KeyCode.D) && playerTransform.position.x < 15)
            {
                playerTransform.Translate(1f, 0f, 0);
                Debug.Log($"Song position in beats: {beatManager.songPosInBeats}, Song position in seconds:  {beatManager.songPosition}");
            }
        }
        renderer.color = Color.red;
//        yield return new WaitForSeconds(0f);
    }
}
