using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] public Transform playerTransform;
    [SerializeField] public Transform ghostTransform;
    [SerializeField] public BeatManager beatManager;
    [SerializeField] public int followDistance = 3;

    private int ghostPositionIndex = 0;
    private Vector3[] ghostTargetPosition = new Vector3[3];
    private bool ghostHasMoved = false;

    void Update()
    {

        if (beatManager.prevBeatHit < .02f || beatManager.nextBeatHit < .02f)
        {
            SavePlayerPositions();
            if (!ghostHasMoved)
            {
                MoveGhost();
                ghostPositionIndex++;
                ghostHasMoved = true;
            }
        }
        else
        {
            ghostHasMoved = false;
        }
    }

    public void SavePlayerPositions()
    {
        switch (ghostPositionIndex % 3)
        {
            case 0:
                ghostTargetPosition[0] = playerTransform.position;
                break;
            case 1:
                ghostTargetPosition[1] = playerTransform.position;
                break;
            case 2:
                ghostTargetPosition[2] = playerTransform.position;
                ghostPositionIndex = 0;
                break;
        }
    }

    public void MoveGhost()
    {
        ghostTransform.position = ghostTargetPosition[ghostPositionIndex];
    }
}
