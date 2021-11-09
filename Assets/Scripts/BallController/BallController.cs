using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    public float initialSpeed = 30f;

    private Vector2 inputVector = Vector2.zero;
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        SetVelocity(initialSpeed);
    }
    
    void FixedUpdate()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        MoveCircle(inputVector, initialSpeed);
    }

    private void SetVelocity(float velocity)
    {
        rigidbody2D.velocity = Random.onUnitSphere * velocity;
    }

    private void MoveCircle(Vector2 input, float velocity)
    {
        rigidbody2D.velocity = inputVector * velocity;
    }
}
