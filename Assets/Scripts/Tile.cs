using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offSetColor;
    [SerializeField] private SpriteRenderer renderer;

    public void init(bool isOffset)
    {
        renderer.color = isOffset ? offSetColor : baseColor;
    }
}
