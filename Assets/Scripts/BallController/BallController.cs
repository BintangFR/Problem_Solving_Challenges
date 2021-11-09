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
    }
    
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inputVector = GetCursorDirection();
            MoveCircle(inputVector, initialSpeed);
        }
    }

    private void MoveCircle(Vector2 input, float velocity)
    {
        rigidbody2D.velocity = inputVector * velocity;
    }

    public Vector2 GetCursorDirection()
    {
        //Debug.Log("Clicked");
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z));
        Vector3 direction = worldMousePosition - this.transform.position;
        direction.Normalize();
        return (Vector2)direction;
    }
}
