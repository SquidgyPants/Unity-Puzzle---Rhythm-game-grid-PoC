using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private BeatManager beatManager;

    private float Offset = 0.140f;
    //Add variables for early and late timings

    public void Init()
    {
        renderer.color = Color.red;
    }

    public void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (beatManager.prevBeatHit < Offset &&  beatManager.nextBeatHit > Offset)
        {
            if (Input.GetKeyDown(KeyCode.W) && playerTransform.position.y < 8)
            { playerTransform.Translate(0f, 1f, 0); }
            if (Input.GetKeyDown(KeyCode.A) && playerTransform.position.x > 0)
            { playerTransform.Translate(-1f, 0f, 0); }
            if (Input.GetKeyDown(KeyCode.S) && playerTransform.position.y > 0)
            { playerTransform.Translate(0f, -1f, 0); }
            if (Input.GetKeyDown(KeyCode.D) && playerTransform.position.x < 15)
            { playerTransform.Translate(1f, 0f, 0); }
        }
    }
}
