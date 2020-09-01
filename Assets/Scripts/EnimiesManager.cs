//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimiesManager : MonoBehaviour
{
    public GameObject[] TypesOfEnemies;
    public int MaximumNumberOfEnemies;
    public int NumberOfEnemy;
    public int MinimumNumberOfEnemies;
    public List<GameObject> SpawnedEnemies;
    public GameObject SpawnedEnemy;
    public Vector3 RandomEnemyPosition;
    public int RandomIndex;
    public bool RandomizeNumberOfEnemies;
    private void Start()
    {
        for (int i = 0; i < NumberOfEnemy; i++)
        {
            SpawnEnemy();
        }



    }
    private void Update()
    {
        for (int i = 0; i < SpawnedEnemies.Count; i++)
        {

            if (SpawnedEnemies[i] == null)
            {
                SpawnedEnemies.Remove(SpawnedEnemies[i]);
                SpawnEnemy();
            }
        }

    }

    void SpawnEnemy()
    {
        StartCoroutine(GenerateRandom());

        GenerateRandomVector3();

        SpawnedEnemy = Instantiate(TypesOfEnemies[0], transform);
        SpawnedEnemy.transform.position += RandomEnemyPosition;
        SpawnedEnemies.Add(SpawnedEnemy);

    }

    void GenerateRandomVector3()
    {
        RandomEnemyPosition = new Vector3(Random.Range(-250, 250), 0, Random.Range(-250, 250));

    }
    public IEnumerator GenerateRandom()
    {
        RandomIndex =  Random.Range(0, TypesOfEnemies.Length);
        if(RandomizeNumberOfEnemies)
        {
            NumberOfEnemy = Random.Range(MinimumNumberOfEnemies,MaximumNumberOfEnemies);

        }

        yield return new WaitForSecondsRealtime(15);
       


    }






}
