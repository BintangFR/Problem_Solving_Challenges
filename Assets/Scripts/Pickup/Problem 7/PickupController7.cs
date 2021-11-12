using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController7 : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    public int score = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            gameManager.IncreaseScore(increase: score);
            Destroy(gameObject);
            Debug.Log("Nabrak");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
