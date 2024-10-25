using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;
    private float timer;
    private int spawnIndex;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, spawnPoints[0].transform.position, Quaternion.identity);
        timer = Time.time + 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < Time.time)
        {
            spawnIndex = Random.Range(0, 4);
            Instantiate(enemyPrefab, spawnPoints[spawnIndex].transform.position, Quaternion.identity);
            timer = Time.time + 20.0f;
        }
    }
}
