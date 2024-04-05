using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private Joystick rotationJoystick;

    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private Vector2 moveDirection;
    private Vector2 rotationDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
        RotateTowardsMovementDirection();
    }

    private void ProcessInputs()
    {
        // Utilise la position du movementJoystick pour définir la direction du mouvement
        float moveX = movementJoystick.Horizontal;
        float moveY = movementJoystick.Vertical;
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Utilise la position du rotationJoystick pour définir la direction de la rotation
        float rotateX = rotationJoystick.Horizontal;
        float rotateY = rotationJoystick.Vertical;
        rotationDirection = new Vector2(rotateX, rotateY).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    private void RotateTowardsMovementDirection()
    {
        if (rotationDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(-rotationDirection.y, rotationDirection.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, angle - 90, 0));

            transform.rotation = rotation;
        }
    }
}