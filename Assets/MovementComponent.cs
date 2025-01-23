using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // zamrożenie obracania, by fizyka unity nie miotała naszym szopem
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0) // obrót jedynie w ruchu
        {
            RotatePlayer();
        }
    }

    private void FixedUpdate()
    {
        // ruch
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void RotatePlayer()
    {
        // obrót zależny od kierunku ruchu
        if (movement.x > 0) // right
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (movement.x < 0) // left
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movement.y > 0) // up
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (movement.y < 0) // down
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
