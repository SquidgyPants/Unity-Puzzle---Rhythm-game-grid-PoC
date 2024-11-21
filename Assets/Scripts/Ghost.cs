using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private BeatManager beatManager;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform ghostMovement;

    private int ghostPositionIndex = 0;
    private bool ghostSpawned = false;
    private Vector3[] ghostTargetPosition = new Vector3[3];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (beatManager.songPosInBeats % 1 == 0)
        {
            SavePlayerPositions();
            ghostPositionIndex++;
        }
    }

    public void SavePlayerPositions()
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
                ghostPositionIndex = 0;
                break;
        }
        if (ghostPositionIndex > 2 && !ghostSpawned)
        {
            SpawnGhost();
            ghostSpawned = true;
        }
        if (ghostSpawned && ghostPositionIndex % 1 == 0)
        {
            MoveGhost(ghostTargetPosition[ghostPositionIndex]);
        }
    }

    public void MoveGhost(Vector3 ghostPosition)
    {
        ghostMovement.position = ghostPosition;
    }

    void SpawnGhost()
    {
        MoveGhost(new Vector3(0f, 8f, 0f));
    }
}
