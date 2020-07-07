using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    public int maxX;
    public GameObject[] Candies;
    public float spawnInterval;
    public static CandySpawner instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCandy()
    {
        //choose a random candy
        int rand = Random.Range(0, Candies.Length);
        int randX = Random.Range(-maxX, maxX);
        Vector3 randomPos = new Vector3(randX, transform.position.y, transform.position.z);
        Instantiate(Candies[rand], randomPos, transform.rotation);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawn()
    {
        StartCoroutine("SpawnCandies");
    }
    

    public void StopSpawn()
    {
        StopCoroutine("SpawnCandies");
    }
}
