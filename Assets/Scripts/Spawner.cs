
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject[] possibleDrops;
    private int length;
    public int armor;
    public int hitPoints;

    public int HitPoints
    {
        get
        {
            return hitPoints;
        }

        set
        {
            hitPoints = value;
        }
    }
    public void TakeDamage(int damage)
    {
        if (damage > armor) {
            hitPoints = (hitPoints - (damage - armor));
        }
        if(hitPoints <= 0)
        {
            DestroySpawner();
        }
    }

    private void DestroySpawner()
    {
        DropItems();
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        length = possibleDrops.Length;
    }

    public void DropItems()
    {
        if (Random.Range(0, 100) < 0)
        {
            GameObject.Instantiate(possibleDrops[Random.Range(0, length)],
                GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        }
    }
    
    public void Update()
    {

    }

}
