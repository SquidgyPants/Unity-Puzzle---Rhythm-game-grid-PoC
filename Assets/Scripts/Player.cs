using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Transform playerTransform;
    [SerializeField] public BeatManager beatManager;
    [SerializeField] public int keyCount;

    private float Offset = 0.150f;


    public void Init()
    {
        renderer.color = Color.red;
    }

    public void Update()
    {
        MovePlayer();
    }

    public void MovePlayer(/*float prevBeatHit, float nextBeatHit*/)
    {
        if (beatManager.songPosInBeats % 1 < Offset || 1 - (beatManager.songPosInBeats % 1) < Offset)
        {
            if (Input.GetKeyDown(KeyCode.W) && playerTransform.position.y < 8)
            {
                playerTransform.Translate(0f, 1f, 0);
            }
            if (Input.GetKeyDown(KeyCode.A) && playerTransform.position.x > 0)
            {
                playerTransform.Translate(-1f, 0f, 0);
            }
            if (Input.GetKeyDown(KeyCode.S) && playerTransform.position.y > 0)
            {
                playerTransform.Translate(0f, -1f, 0);
            }
            if (Input.GetKeyDown(KeyCode.D) && playerTransform.position.x < 15)
            {
                playerTransform.Translate(1f, 0f, 0);
            }
        }
    }

    public void KeyPickedUp()
    {
        keyCount++;
        Debug.Log($"Key count: {keyCount}");
    }
}
