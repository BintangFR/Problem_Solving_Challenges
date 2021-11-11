using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController1 : MonoBehaviour
{
    [SerializeField]
    public float initialSpeed = 30f;

    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        SetVelocity(initialSpeed);
    }

    private void SetVelocity(float velocity)
    {
        rigidbody2D.velocity = Random.onUnitSphere * velocity;
    }
}
