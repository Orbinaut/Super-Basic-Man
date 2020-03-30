using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeColor : MonoBehaviour
{
    public Color A = Color.magenta;
    public Color B = Color.blue;
    public float speed = 1.0f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        spriteRenderer.color = Color.Lerp(A, B, Mathf.PingPong(Time.timeSinceLevelLoad * speed, 1.0f));
    }
}