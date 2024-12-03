using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private GameObject gridManager;
    [SerializeField] private Transform camera;
    [SerializeField] private Player playerScript;
    [SerializeField] private Key keyScript;
    [SerializeField] private Door doorScript;
    [SerializeField] private UnityEvent startSong;

    private Vector3 keyPosition;
    private Vector3 previousKeyPosition;
    private float elapsedTime;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        SpawnPlayer();
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 2f)
        {
            startSong.Invoke();
        }
        SpawnKeys();
        SpawnDoor();
    }

    void GenerateGrid()
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
    void SpawnPlayer()
    {
        var spawnPlayer = Instantiate(playerScript, new Vector3(0f, 8f, 0f), Quaternion.identity);
        spawnPlayer.name = "Player";
        spawnPlayer.transform.parent = gridManager.transform;
        spawnPlayer.Init();
    }

    void SpawnKeys()
    {
        for (int i = 0; i >= doorScript.keysNeeded; i++)
        {
            keyPosition = new Vector3(Random.Range(1, 15), Random.Range(1, 8), 0f);
            while (keyPosition == previousKeyPosition)
            {
                keyPosition = new Vector3(Random.Range(1, 15), Random.Range(1, 8), 0f);
            }
            var spawnKey = Instantiate(keyScript, keyPosition, Quaternion.identity);
            spawnKey.name = "Key " + (i + 1);
            spawnKey.transform.parent = gridManager.transform;
            spawnKey.Init();
            previousKeyPosition = keyPosition;
        }
    }

    void SpawnDoor()
    {
        var spawnDoor = Instantiate(doorScript, new Vector3(15f, 0f, 0f), Quaternion.identity);
        spawnDoor.transform.parent = gridManager.transform;
        spawnDoor.name = "Door";
        spawnDoor.Init();
    }
}
