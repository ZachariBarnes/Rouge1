using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
    private static Collider2D player;
    public GameObject thisWeapon;
    public GameObject[] possibleDrops;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        player = other;
        if (other.tag.Equals("Player"))
        {
               
            thisWeapon = possibleDrops[(int)Random.Range(0, possibleDrops.Length)];
            player.transform.Find("WeaponManager").GetComponent<WeaponManager>().UpdateWeapon(thisWeapon);
            Destroy(this.gameObject, 0.25f);
        }
    }
}
