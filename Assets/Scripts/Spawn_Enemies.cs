using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemies : MonoBehaviour {
    public GameObject enemyType;
    public GameObject spawner;
    public GameObject[] enemies;
    public int minRange;
    public int maxRange;
    public int delay = 120;
    int count = 0;
    public bool SpawnEnemies = true;
    // Use this for initialization
    void Start() {
        if (minRange == 0 || minRange<0)
        {
            minRange = 8;
        }
        if (maxRange == 0 || maxRange < 0)
        {
            maxRange = 18;
        }

    }

    // Update is called once per frame
    void FixedUpdate() {

        if (SpawnEnemies)
        {
            if (count >= delay)
            {
                GameObject tempObject;
                tempObject = Instantiate(enemyType, spawner.transform.position, spawner.transform.rotation) as GameObject;
                tempObject.GetComponent<EnemyScript>().speed = Random.Range(8, 18);
                count = 0;
            }
            count++;

        }
    }

}
