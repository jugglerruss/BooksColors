using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] 

public class ColorControl : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public Color GetColor()
    {
        return _spriteRenderer.color;
    }
    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
