using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDrag : MonoBehaviour
{
    [SerializeField]
    private Vector2 _startPos;

    [SerializeField]

    private Rigidbody2D rigidbody2D;
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
