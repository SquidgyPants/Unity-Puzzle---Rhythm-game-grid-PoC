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
    private bool doorsOpened = false;

    public void Init()
    {
        closedDoor.enabled = true;
    }
    
    private void Update()
    {
        keyCount = playerScript.keyCount;
        if (keyCount == keysNeeded)
        {
            Open();
        }
    }


    public void Open()
    {
         if (!doorsOpened)
         {
            closedDoor.enabled = false;
            openDoor.enabled = true;
            doorsOpened = true;
         }
    }

    public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && !closedDoor.enabled && openDoor.enabled)
            {
                Debug.Log("You completed the level!");
                Application.Quit();
            }
        }
}
