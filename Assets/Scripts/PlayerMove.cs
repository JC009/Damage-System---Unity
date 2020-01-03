using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 3.0f;
    private Camera m_Camera;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Start()
    {
        m_Camera = Camera.main;
    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        // Destroy the bullet after 5 seconds
        Destroy(bullet, 5.0f);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }
        else
        {
            speed = 3.0f;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);
        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }

    }
}
