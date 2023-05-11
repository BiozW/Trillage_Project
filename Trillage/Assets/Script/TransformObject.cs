using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformObject : MonoBehaviour
{
    public float moveSpeed = 0f;
    public Vector2 moveDirection = Vector2.right;
    public float rotationSpeed = 180f;
    public Vector3 scale = Vector3.one;
    public float min = 0f;
    public float max = 30f;

    private void Update()
    {
        // Move the object
        transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;

        // Rotate the object
        transform.Rotate(Vector3.forward, Random.Range(min,max) * Time.deltaTime);

        // Set the scale of the object
        transform.localScale = scale * Random.Range(1,1);
    }
}

