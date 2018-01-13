using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    //Rigidbody2D rigidbody;
    GameObject gunGO;
    GameObject playerGo;
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;
    float angle;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;
    public GameObject ShotgunBullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    // Use this for initialization
    void Start () {
       // rigidbody = GetComponent<Rigidbody2D>();
        playerGo = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(transform.localScale.x == 0.5 || transform.localScale.y == 0.5)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (angle > 90 || angle < -90)
        {
            //BroadcastMessage("Angle is: " + angle.ToString());
            transform.localScale = new Vector3(-1, 1, 1);
            angle += 180;
        }
        else if (transform.localScale.x == -1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
      //  Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition,
      //                      Vector3.forward); // For Animating
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if ((-44 > angle && angle > -136 )|| (44 < angle && angle < 90 && GetComponent<Transform>().localScale.x==-1))
        {
            GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 9;
        }
        transform.position = playerGo.transform.position;

        if (Input.GetButtonDown("Fire1"))
        {
            //The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 180);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody2D Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce((transform.right* transform.localScale.x) * Bullet_Forward_Force);
            //Temporary_RigidBody.AddForce(transform.right * Bullet_Forward_Force);
            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(Temporary_Bullet_Handler, 3.0f);
        }
        if (Input.GetButtonDown("Fire2")){

            for (int i = -4; i < 4; i++)
            {
                //The Bullet instantiation happens here.
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(ShotgunBullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
                Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 180);

                //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                Rigidbody2D Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
                Temporary_RigidBody.AddForce((transform.up * (transform.localScale.y+i)) * Bullet_Forward_Force/15);
                //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                Temporary_RigidBody.AddForce((transform.right * (transform.localScale.x)) * (Bullet_Forward_Force*.75f));

                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                Destroy(Temporary_Bullet_Handler, 0.5f);
            }

        }
    }
}
