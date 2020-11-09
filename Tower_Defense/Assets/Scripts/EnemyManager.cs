using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//Went Over in Class
public struct Group
{
    public GameObject enemyType;
    [Range(0,50)] public int amountOfEnemies;
    [Range(0,5)] public float timeDelayBetweenEnemies;

    public Group(GameObject enemyType, int amountOfEnemies, float timeDelayBetweenEnemies)
    {
        this.enemyType = enemyType;
        this.amountOfEnemies = amountOfEnemies;
        this.timeDelayBetweenEnemies = timeDelayBetweenEnemies;
    }
}

[System.Serializable]
public struct Wave
{
    public Group[] enemyGroups;
}

public class EnemyManager : MonoBehaviour
{
    //Pass navigational path
    public Waypoints[] navPoints;
    public Wave enemyWave;

    //Enemy Objects
    
    //public GameObject easyEnemy;
    //public GameObject hardEnemy;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
    }

    private void SpawnWave()
    {
        foreach (Group group in enemyWave.enemyGroups)
        {
            StartCoroutine(SpawnGroup(group));
           //Spawn Easy Enemy
           //GameObject spawnedEnemy = Instantiate(group.enemyType);
           //spawnedEnemy.GetComponent<Enemy>().StartEnemy(navPoints);
        } 

    }

    IEnumerator SpawnGroup(Group enemyGroup)
    {
        int i = 0;
        while (enemyGroup.amountOfEnemies > 0)
        {
            GameObject spawnedEnemy = Instantiate(enemyGroup.enemyType);
            spawnedEnemy.GetComponent<Enemy>().StartEnemy(navPoints);
            spawnedEnemy.name = $"{enemyGroup.enemyType.ToString()} {i}";
            enemyGroup.amountOfEnemies--;
            i++;
            yield return new WaitForSeconds(enemyGroup.timeDelayBetweenEnemies);
            
        }
    }
}
