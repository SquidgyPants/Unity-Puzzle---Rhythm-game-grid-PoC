using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    [SerializeField] Collider2D keyCollider;
    [SerializeField] SpriteRenderer keySprite;
    [SerializeField] UnityEvent keyPickup;

    public void Init()
    {
        keySprite.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            keyPickup.Invoke();
        }
    }
}
