using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] public float keysNeeded;
    [SerializeField] public Player playerScript;
    [SerializeField] public Door openDoor;
    [SerializeField] public Door closedDoor;
    [SerializeField] public SpriteRenderer openDoorRenderer;
    [SerializeField] public SpriteRenderer closedDoorRenderer;
    [SerializeField] private UnityEvent QuitGame;

    private float keyCount;
    private bool doorsOpened = false;

    public void Init()
    {
        closedDoorRenderer.enabled = true;
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
            closedDoorRenderer.enabled = false;
            openDoorRenderer.enabled = true;
            doorsOpened = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Door hit");
        if (collision.gameObject.CompareTag("Player") && !closedDoorRenderer.enabled && openDoorRenderer.enabled)
        {
            Debug.Log("You completed the level!");
            QuitGame.Invoke();
        }
    }
}
