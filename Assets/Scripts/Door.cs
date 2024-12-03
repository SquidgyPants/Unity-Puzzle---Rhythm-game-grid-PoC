using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] public float keysNeeded;
    [SerializeField] public Player playerScript;
    [SerializeField] private SpriteRenderer openDoor;
    [SerializeField] private SpriteRenderer closedDoor;

    private float keyCount;

    public void Init()
    {
        openDoor.enabled = true;
    }
    
    private void Update()
    {
        keyCount = playerScript.keyCount;
    }


    public void Open()
    {
        if (keyCount == keysNeeded)
        {
            closedDoor.enabled = false;
            openDoor.enabled = true;
        }
    }
}
