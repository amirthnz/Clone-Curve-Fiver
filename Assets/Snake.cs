using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    public float speed = 5f;
    public float rotSpeed = 200f;

    float horizontal = 0f;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * -1;
    }

    private void FixedUpdate()
    {
        // Move the game object in one direction... forever
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        // But we rotate it based on the input taken in Update
        transform.Rotate(Vector3.forward * rotSpeed * horizontal * Time.fixedDeltaTime);
    }

    // If we touch anything, we lose
    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed = 0;
    }

}
