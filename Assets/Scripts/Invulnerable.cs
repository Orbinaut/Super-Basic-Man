﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour
{
    private CollectStuff collectScript;

    Renderer rend;
    Color color;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            collectScript = player.GetComponent<CollectStuff>();
        }
        if (collectScript == null)
        {
            Debug.Log("Can't find the 'CollectStuff' script");
        }

        rend = GetComponent<Renderer>();
        color = rend.material.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && collectScript.healthPoints > 0)
            StartCoroutine("GetInvulnerable");
    }

    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(8, 10, true);
        color.a = 0.5f;
        rend.material.color = color;
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(8, 10, false);
        color.a = 1f;
        rend.material.color = color;
    }
}