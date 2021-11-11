using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDrag : MonoBehaviour
{
    [SerializeField]
    public CircleCollider2D Collider;
    private Vector2 _startPos;

    [SerializeField]
    private float _radius = 0.75f;

    [SerializeField]
    private float _throwSpeed = 30f;

    private Rigidbody2D rigidbody2D;
    public LineRenderer Trajectory;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _startPos = transform.position;
    }

    void OnMouseDrag()
    {
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = p - _startPos;
        //if (dir.sqrMagnitude > _radius)
            //dir = dir.normalized * _radius;
        transform.position = _startPos + dir;
        //float distance = Vector2.Distance(_startPos, transform.position);
    }

    private void MoveCircle(Vector2 velocity, float distance, float speed)
    {
        rigidbody2D.velocity = velocity * speed * distance;
    }

 
}
