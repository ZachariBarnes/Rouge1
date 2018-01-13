using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FiringPattern : MonoBehaviour {

    protected WeaponController myWeaponController;
    protected GameObject Bullet;
    protected GameObject Bullet_Emitter;
    protected float Bullet_Forward_Force;
    public AudioClip ShotSound;
    protected AudioSource Audio;

    public virtual void Fire()
    {

    }
	// Use this for initialization
	public void Start () {
        myWeaponController = GetComponent<WeaponController>();
        Bullet_Forward_Force = myWeaponController.Bullet_Forward_Force;
        Bullet = myWeaponController.Bullet;
        Bullet_Emitter = myWeaponController.Bullet_Emitter;
        AudioSource Audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
