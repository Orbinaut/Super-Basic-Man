using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public GameObject arrow;
    public GameObject bouncer;
    public AudioSource shotSound;
    public AudioSource arrowSound;

    public float shootingInaccuracy = 5.0f;

    private CollectStuff collectScript;
    private CharacterController2D controllerScript;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            collectScript = player.GetComponent<CollectStuff>();
            controllerScript = player.GetComponent<CharacterController2D>();
        }
        if (collectScript == null)
        {
            Debug.Log("Can't find the 'CollectStuff' script");
        }
        if (controllerScript == null)
        {
            Debug.Log("Can't find the 'CharacterController2D' script");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Shoot") && collectScript.ammo > 0 && collectScript.weaponLevel >= 1)
        {
            Shoot();
        }
        if (Input.GetButtonDown("Bouncer") && collectScript.ammo > 0 && controllerScript.m_Grounded && collectScript.weaponLevel >= 2)
        {
            Bouncer();
        }

        if (Input.GetButtonDown("Arrow") && collectScript.ammo > 0 && collectScript.weaponLevel >= 3)
        {
            Arrow();
        }
    }

    void Shoot(){
        //Instantiate(bullet, firePoint.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(-shootingInaccuracy, shootingInaccuracy)));
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        shotSound.Play();
        collectScript.ShootAmmo();
    }

    void Arrow()
    {
        Instantiate(arrow, firePoint.position, firePoint.rotation);
        arrowSound.Play();
        collectScript.ShootAmmo();
    }

    void Bouncer()
    {
        Instantiate(bouncer, firePoint.position, firePoint.rotation);
        shotSound.Play();
        collectScript.ShootAmmo();
    }
}