using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform ghostTransform;
    [SerializeField] private BeatManager beatManager;
    [SerializeField] private int followDistance = 3;

    private bool ghostSpawned = false;

    private Queue<Vector3> playerPositions = new Queue<Vector3>();

    void Update()
    {
        if (!ghostSpawned && beatManager.songPosInBeats > 2f)
        {
            SpawnGhost();
        }
        // Store the player's current position
        playerPositions.Enqueue(playerTransform.position);

//        if (beatManager.songPosInBeats % 1 == 0 && beatManager.songPosInBeats > 0)
//        {
//            ghostPositionIndex++;
//        }
        // If the queue has more positions than the follow distance, update the ghost's position
        if (playerPositions.Count > followDistance)
        {
            ghostTransform.position = playerPositions.Dequeue();
        }
    }
//    [SerializeField] private BeatManager beatManager;
//    [SerializeField] private GameObject player;
//    [SerializeField] private Transform ghostMovement;
//
//    private int ghostPositionIndex = 0;
//    private bool ghostSpawned = false;
//    private Vector3[] ghostTargetPosition = new Vector3[3];
//    // Start is called before the first frame update
//    void Start()
//    {
//
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        if (beatManager.songPosInBeats % 1 == 0 && beatManager.songPosInBeats > 0)
//        {
//            SavePlayerPositions();
//            ghostPositionIndex++;
//        }
//    }
//
//    public void SavePlayerPositions()
//    {
//        if (beatManager.songPosInBeats >= 2 && !ghostSpawned)
//        {
//            SpawnGhost();
//            ghostSpawned = true;
//        }
//        switch (ghostPositionIndex % 3)
//        {
//            case 0:
//                ghostTargetPosition[0] = player.transform.position;
//                break;
//            case 1:
//                ghostTargetPosition[1] = player.transform.position;
//                break;
//            case 2:
//                ghostTargetPosition[2] = player.transform.position;
//                ghostPositionIndex = 0;
//                break;
//        }
//        if (ghostSpawned)
//        {
//            MoveGhost(ghostTargetPosition[ghostPositionIndex]);
//        }
//    }
//
    void SpawnGhost()
    {
        ghostTransform.position = new Vector3(0f, 0f, 0f);
    }

}
