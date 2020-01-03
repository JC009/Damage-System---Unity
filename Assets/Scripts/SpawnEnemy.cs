using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public Transform enemy;
    public float WaitTime = 10.0f;

    void Start()
    {
        Instantiate(enemy, new Vector3(0, 0.4f, 0), Quaternion.identity);
        StartCoroutine("Spawn", WaitTime);
    }

    IEnumerator Spawn(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        Instantiate(enemy, new Vector3(0, 0.4f, 0), Quaternion.identity);
        yield return null;
    }
}
