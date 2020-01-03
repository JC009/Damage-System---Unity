using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_47 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private int select = 1;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private AudioSource source;
    public AudioClip shot;
    public AudioClip przeladowanie;
    public AudioClip pusty;
    public float rpm; // szybkostrzelność
    public float bulletSpeed; // prędkość pocisku
    private float ammo = 30; // ilość amunicji
    private float waitToFire; // taka blokada, nie przejmuj się tym, działa    

    void Fire1()
    {
        if (waitToFire <= 0)
        {
            // tworzy pocisk z prefaba
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            // samo strzelanie tutaj
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

            // dźwięk strzelani
            source.PlayOneShot(shot,0.2f);

            // niszczy pocisk
            Destroy(bullet, 2.0f);
            waitToFire = 1;

            ammo--;
        }

    }

    void Zmiana()
    {
        switch(select)
        {
            case 1:
                select = 2;
                break;
            case 2:
                select = 1;
                break;
        }
    }

    void Reload()
    {
        source.PlayOneShot(przeladowanie,0.5f);
        ammo = 30;
        waitToFire = 18;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.Mouse0) && Input.GetKeyDown(KeyCode.X))
        {
            Zmiana();
        }

        if (select == 1)
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammo > 0) //strzelanie pojedyncze
        {
            Fire1();
        }

        if (select == 2)
        if (Input.GetKey(KeyCode.Mouse0) && ammo > 0) // strzelanie automatyczne
        {
            Fire1();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && ammo <= 0) //strzelanie bez pocisków w magazynku
        {
            source.PlayOneShot(pusty,1);
        }

        if (Input.GetKeyDown(KeyCode.R) && ammo < 30)
        {
            Reload();
        }

        waitToFire -= rpm * Time.deltaTime;

    }
}
