using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private Joystick rotationJoystick;

    [SerializeField] private Transform objectToRotate;

    [SerializeField] private float objectDistance;

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
        UpdateObjectPositionAndPlayerOrientation();
    }

    private void FixedUpdate()
    {
        Move();
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

    private void UpdateObjectPositionAndPlayerOrientation()
    {
        if (rotationDirection.sqrMagnitude > 0.01)
        {
            // Calcule l'angle du joystick par rapport à l'origine et ajuste pour que la pointe du triangle soit orientée à l'opposé du joueur
            float angle = Mathf.Atan2(rotationDirection.y, rotationDirection.x) * Mathf.Rad2Deg;

            // Calcule la position du triangle autour du joueur en utilisant la distance et l'angle du joystick
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
            Vector3 trianglePosition = transform.position + direction * objectDistance + new Vector3(0, 0, -transform.position.z);

            objectToRotate.position = trianglePosition;

            // Oriente le joueur en fonction de la position du triangle
            if (Mathf.Abs(rotationDirection.y) > Mathf.Abs(rotationDirection.x))
            {
                // Le triangle est principalement au-dessus ou en dessous du joueur
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (rotationDirection.x > 0)
            {
                // Le triangle est à droite du joueur
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
            else
            {
                // Le triangle est à gauche du joueur
                transform.eulerAngles = new Vector3(0, 90, 0);
            }

            // Ajuste l'orientation du triangle pour que sa pointe soit toujours à l'opposé du joueur
            Vector3 relativePos = transform.position - objectToRotate.position;
            objectToRotate.up = -relativePos.normalized;
        }
    }
}