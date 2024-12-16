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
    int lastTriggeredBeat = 0;

    void Start()
    {

    }


    void Update()
    {

    }

    public void MoveGhost()
    {
        ghostPositionIndex++;
        if (ghostPositionIndex >= 0)
        {
            ghostTransform.position = playerObject.playerPositions[ghostPositionIndex];
        }
    }
}
