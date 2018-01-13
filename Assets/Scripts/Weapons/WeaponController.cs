using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponController : MonoBehaviour
{

    private FiringPattern FireScript;
    private AltFiringPattern AltFireScript;
    GameObject playerGo;
    float angle;
    public int MaxAmmoClip = 10;
    public int currentClip;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;
    public GameObject AltBullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    //Drag in the Bullet Emitter from the Component Inspector.
    private GameObject bullet_Emitter;
    private float reloadTime = 2;
    private bool reloading;

    public GameObject Bullet_Emitter
    {
        get
        {
            return bullet_Emitter;
        }

        set
        {
            bullet_Emitter = value;
        }
    }

    private void Awake()
    {
        // rigidbody = GetComponent<Rigidbody2D>();
        playerGo = GameObject.FindGameObjectWithTag("Player");
        FireScript = GetComponent<FiringPattern>();
        AltFireScript = GetComponent<AltFiringPattern>();
        Bullet_Emitter = transform.Find("BulletEmitter").gameObject;
        currentClip = MaxAmmoClip;
    }


    // Use this for initialization
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if ((transform.localScale.x != 1 || transform.localScale.y != 1) &&(transform.localScale.x != -1 || transform.localScale.y != -1))
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
        if ((-44 > angle && angle > -136) || (44 < angle && angle < 90 && GetComponent<Transform>().localScale.x == -1))
        {
            GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 9;
        }
        transform.position = playerGo.transform.position;

        if (Input.GetButtonDown("Fire1") && currentClip > 0)
        {
            currentClip = currentClip - 1;
            FireScript.Fire();
            
        }
        else if(currentClip <= 0)
        {
            Reload();
        }
        if (Input.GetButtonDown("Fire2") && currentClip > 0)
        {
            currentClip = currentClip - 5;
            AltFireScript.Fire();
            
        }
        else if(currentClip <= 0)
        {
            if (!reloading)
            {
                Reload();
            }
        }
        if (Input.GetButtonDown("Reload"))
        {
            if (!reloading)
            { Reload(); }
        }
    }

    private void Reload()
    {
        //anim.setBool("Reloading", true);//For Animating the Reload
        reloading = true;
        StartCoroutine(ReloadOneRound());
    }
    IEnumerator ReloadOneRound()
    {
        yield return new WaitForSeconds(reloadTime);
        currentClip = MaxAmmoClip;
        reloading = false;
        //anim.setBool("Reloading", false);//For Animating the Reload
    }

}
