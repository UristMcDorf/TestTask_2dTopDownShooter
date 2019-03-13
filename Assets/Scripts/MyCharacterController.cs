using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    [SerializeField]
    float characterSpeed = 0f;
    Rigidbody2D rigidbody2d = null;
    Vector2 movementInput = Vector2.zero;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovementInput();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovementInput()
    {
        movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void HandleMovement()
    {
        rigidbody2d.AddForce(movementInput.normalized * characterSpeed);
    }
}
