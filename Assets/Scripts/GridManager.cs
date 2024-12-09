using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    //[SerializeField] private GameObject gridManager;
    [SerializeField] private Transform camera;
    [SerializeField] private Player playerPrefab;
    [SerializeField] private Key keyPrefab;
    [SerializeField] private Door doorPrefab;
    [SerializeField] private Door openDoorPrefab;
    [SerializeField] private Door closedDoorPrefab;

//    [SerializeField] private UnityEvent generateGrid;
//    [SerializeField] private UnityEvent startSong;

    private Vector3 keyPosition;
    private Vector3 previousKeyPosition;
    private float elapsedTime;
    private bool songStarted = false;
    Door closedDoor;
    Door openDoor;
    Door spawnDoor;
    Key spawnedKey;
    Player spawnedPlayer;



    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        SpawnPlayer();
        //        SpawnDoor();
        SpawnClosedDoor();
        SpawnOpenDoor();
        SpawnKeys();
    }

    void Update()
    {
//        elapsedTime += Time.deltaTime;
//        if (elapsedTime >= 2f && !songStarted)
//        {
//            startSong.Invoke();
//            songStarted = true;
//        }
    }

    public void GenerateGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(i, j), Quaternion.identity);
                spawnedTile.name = $"Tile {i} {j}";

                var isOffSet = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0);
                spawnedTile.init(isOffSet);
            }
        }


        camera.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }

    public void SpawnPlayer()
    {
        spawnedPlayer = Instantiate(playerPrefab, new Vector3(0f, 8f, 0f), Quaternion.identity);
        spawnedPlayer.name = "Player";
        spawnedPlayer.beatManager = FindObjectOfType<BeatManager>();
        spawnedPlayer.keyCount = 0;
        spawnedPlayer.Init();
    }

    public void SpawnKeys()
    {
        for (int i = 0; i < closedDoor.keysNeeded; i++)
        //for (int i = 0; i < spawnDoor.keysNeeded; i++)
        {
            keyPosition = new Vector3(Random.Range(1, 15), Random.Range(1, 8), 0f);
            while (keyPosition == previousKeyPosition)
            {
                keyPosition = new Vector3(Random.Range(1, 15), Random.Range(1, 8), 0f);
            }
            spawnedKey = Instantiate(keyPrefab, keyPosition, Quaternion.identity);
            spawnedKey.name = "Key " + (i + 1);
            spawnedKey.playerScript = spawnedPlayer;
            spawnedKey.Init();
            previousKeyPosition = keyPosition;
        }
    }

    public void SpawnDoor()
    {
        spawnDoor = Instantiate(doorPrefab, new Vector3(15f, 0f, 0f), Quaternion.identity);
    //  spawnDoor.transform.parent = gridManager.transform;
        spawnDoor.name = "Door";
        spawnDoor.playerScript = spawnedPlayer;
        spawnDoor.closedDoor = closedDoor;
        spawnDoor.openDoor = openDoor;
        spawnDoor.closedDoor.playerScript = spawnedPlayer;
        spawnDoor.openDoor.playerScript = spawnedPlayer;
        spawnDoor.Init();
    }

    public void SpawnClosedDoor()
    {
        closedDoor = Instantiate(closedDoorPrefab, new Vector3(15f, 0f, 0f), Quaternion.identity);
        //        spawnDoor.transform.parent = gridManager.transform;
        closedDoor.name = "Closed Door";
        closedDoor.playerScript = spawnedPlayer;
        closedDoor.closedDoorRenderer = closedDoor.GetComponent<SpriteRenderer>();
        closedDoor.Init();
    }

    public void SpawnOpenDoor()
    {
        openDoor = Instantiate(openDoorPrefab, new Vector3(15f, 0f, 0f), Quaternion.identity);
        //  spawnDoor.transform.parent = gridManager.transform;
        openDoor.name = "Closed Door";
        openDoor.playerScript = spawnedPlayer;
        openDoor.openDoorRenderer = openDoor.GetComponent<SpriteRenderer>();
        openDoor.openDoorRenderer.enabled = false;
        openDoor.closedDoorRenderer = closedDoor.GetComponent<SpriteRenderer>();
        openDoor.Init();
    }
}
