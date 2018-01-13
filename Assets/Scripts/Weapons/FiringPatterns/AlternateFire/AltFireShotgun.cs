using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltFireShotgun : AltFiringPattern
{

    public override void Fire()
    {
        AudioSource Audio = GetComponent<AudioSource>();
        Audio.PlayOneShot(ShotSound, 0.25f);
        for (int i = -4; i < 4; i++)
        {
            //The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(AltBullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 180);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody2D Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
            Temporary_RigidBody.AddForce((transform.up * (transform.localScale.y + i)) * Bullet_Forward_Force / 15);
            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce((transform.right * (transform.localScale.x)) * (Bullet_Forward_Force * .75f));

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            float lifetime = (Bullet_Forward_Force * 10);
            if (lifetime > 0.5)
            {
                lifetime = lifetime / 2;
            }
            Destroy(Temporary_Bullet_Handler, lifetime);
        }
    }
}
