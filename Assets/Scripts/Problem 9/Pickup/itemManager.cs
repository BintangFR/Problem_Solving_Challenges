using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public GameObject goalPrefabs;

    [SerializeField]
    public int initialItem = 1;
    public int enemyCount = 1;

    public int goalCount = 1;


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
        for (int i = 0; i < initialItem; i++)
            Spawn(_xRadius, _yRadius, enemyPrefabs);
            Spawn(_xRadius, _yRadius, goalPrefabs);
    }

    private void Update()
    {
        if (goalCount < initialItem)
        {
            Spawn(_xRadius, _yRadius, enemyPrefabs);
            Spawn(_xRadius, _yRadius, goalPrefabs);
            goalCount = initialItem;
        }
        
    }



    private void Spawn(float x, float y, GameObject prefab)
    {
        Vector2 pos = RandomSpawnPosition(x, y);

        if (GameObject.FindGameObjectWithTag("AntiSpawn").GetComponent<CircleCollider2D>().bounds.Contains(pos))
        {
            Spawn(x, y, prefab);
            return;
        }
        Instantiate(prefab, pos, Quaternion.identity);
    }

    private Vector2 RandomSpawnPosition(float x, float y)
    {
        return new Vector2(Random.Range(-x - offset, x + offset), Random.Range(-y - offset, y + offset));
    }

    public void ReducePickup()
    {
        goalCount--;
    }
}
