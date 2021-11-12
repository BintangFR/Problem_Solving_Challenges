using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public GameObject pickupPrefabs;

    [SerializeField]
    public int pickupMax = 5;
    public int pickupMin = 5;

    public int pickupCurrentMax;
    public int pickupCurrent;

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
        pickupCurrent = pickupCurrentMax;
        for (int i = 0; i < pickupCurrentMax; i++)
            SpawnPickup(_xRadius, _yRadius);
    }

    private void Update()
    {
        if (pickupCurrent < pickupCurrentMax)
        {
            SpawnDelay();
            pickupCurrent++;
        }
        
    }

    private void SpawnPickup()
    {
        SpawnPickup(_xRadius, _yRadius);
    }

    private void SpawnPickup(float x, float y)
    {
        Vector2 pos = RandomSpawnPosition(x, y);

        if (GameObject.FindGameObjectWithTag("Ball").GetComponent<CircleCollider2D>().bounds.Contains(pos))
        {
            SpawnPickup(x, y);
            return;
        }
        Instantiate(pickupPrefabs, pos, Quaternion.identity);
    }

    private Vector2 RandomSpawnPosition(float x, float y)
    {
        return new Vector2(Random.Range(-x - offset, x + offset), Random.Range(-y - offset, y + offset));
    }

    public void SpawnDelay()
    {
        Invoke("SpawnPickup", 3f);
    }

    public void ReducePickup()
    {
        pickupCurrent--;
    }
}
