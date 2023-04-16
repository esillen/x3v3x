using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{

    public int playerNumber;
    public GameObject spaceshipPrefab;
    public Spaceship spaceship;
    public float spawnTime = 8;


    void Start() {
        spaceship.player = this;
    }


    void Update()
    {
        if (spaceship != null) { 
            // Do stuff with controls
        }
    }

    public void Die()
    {
        spaceship = null;
        StartCoroutine(RespawnAfterSomeTime());
    }

    private IEnumerator RespawnAfterSomeTime() {
        yield return new WaitForSeconds(spawnTime);
        GameObject newSpaceshipGameObject = Instantiate(spaceshipPrefab);
        spaceship = newSpaceshipGameObject.GetComponent<Spaceship>();
        spaceship.player = this;
    }



}
