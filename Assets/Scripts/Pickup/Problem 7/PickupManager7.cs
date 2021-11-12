using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager7 : MonoBehaviour
{
    public GameObject pickupPrefabs;

    [SerializeField]
    public int pickupMax = 5;
    public int pickupMin = 1;

    public int pickupCurrentMax;

    [Header("Spawning Radius")]
    public Transform xPoint;
    public Transform yPoint;
    public float offset = 0f;

    private float _xRadius;
    private float _yRadius;

    private void Awake()
    {
        _xRadius = xPoint.position.x;
        _yRadius = yPoint.position.y;
    }

    private void Start()
    {
        pickupCurrentMax = Random.Range(pickupMin, pickupMax);
        for(int i = 0; i < pickupCurrentMax; i++)
            SpawnPickup(_xRadius, _yRadius);
    }

    private void SpawnPickup(float x, float y)
    {
        Instantiate(pickupPrefabs, RandomSpawnPosition(x, y), Quaternion.identity);
    }

    private Vector2 RandomSpawnPosition(float x, float y)
    {
        return new Vector2(Random.Range(-x - offset, x + offset), Random.Range(-y - offset, y + offset));
    }
}
