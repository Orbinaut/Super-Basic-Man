using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject arrowPrefab;
    public AudioSource shotSound;
    public AudioSource arrowSound;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }

        if (Input.GetButtonDown("Arrow"))
        {
            Arrow();
        }
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        shotSound.Play();
    }

    void Arrow()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        arrowSound.Play();
    }
}
