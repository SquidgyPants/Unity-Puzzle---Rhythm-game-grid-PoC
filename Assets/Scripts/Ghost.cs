using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] public Transform playerTransform;
    [SerializeField] public Transform ghostTransform;
    [SerializeField] public Player playerObject;
    [SerializeField] public BeatManager beatManager;
    [SerializeField] public int followDistance = 3;

    private int ghostPositionIndex = 0;


    void Update()
    {
        if (beatManager.songPosInBeats % 1 < .025f || 1 - (beatManager.songPosInBeats % 1) < .025f)
        {
            ghostPositionIndex = playerObject.playerMoveCount - followDistance;
        }
    }

    public void MoveGhost()
    {
        if (ghostPositionIndex >= 0)
        {
            ghostTransform.position = playerObject.playerPositions[ghostPositionIndex];
        }
    }
}
