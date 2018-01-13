using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    GameObject oldGun;
    GameObject Player;
    public GameObject activeWeapon;
    public GameObject ActiveWeapon
    {
        get
        {
            return activeWeapon;
        }

        set
        {
            activeWeapon = value;
        }
    }


    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateWeapon(GameObject newWeapon)
    {
        oldGun = activeWeapon;//GameObject.FindGameObjectWithTag("CurrentWeapon");
        // get a reference to the instantiated object:
        GameObject newGun = GameObject.Instantiate(newWeapon, Player.transform) as GameObject;
        // copy parent (maybe you should copy the position and rotation as well)
        newGun.transform.position = Player.transform.position;
        newGun.transform.parent = Player.transform;
        newGun.transform.rotation = oldGun.transform.rotation;
        newGun.tag = "CurrentWeapon";
        activeWeapon = newGun;
        Destroy(oldGun, 0.01f);
        
    }
}
