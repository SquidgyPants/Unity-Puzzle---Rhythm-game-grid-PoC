using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;

    public void Init()
    {
        renderer.color = Color.red;
    }
}
