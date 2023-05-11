using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMeshColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Get a reference to the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Change the color of the sprite to red when the 'R' key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            spriteRenderer.color = Color.red;
        }

        // Change the color of the sprite to blue when the 'B' key is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            spriteRenderer.color = Color.blue;
        }

        // Change the color of the sprite to green when the 'G' key is pressed
        if (Input.GetKeyDown(KeyCode.G))
        {
            spriteRenderer.color = Color.green;
        }
    }
}

