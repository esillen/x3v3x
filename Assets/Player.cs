using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{

    public int playerNumber;
    public GameObject spaceshipPrefab;
    public Spaceship spaceship;


    private float spawnTime = 5;


    void Start() {
        spaceship.player = this;
    }


    void Update()
    {
        if (spaceship != null) {
            if (Input.GetAxisRaw($"p{playerNumber} left") > 0)
            {
                spaceship.LeftThrusterOn();
            }
            else { 
                spaceship.LeftThrusterOff();
            }
            if (Input.GetAxisRaw($"p{playerNumber} right") > 0)
            {
                spaceship.RightThrusterOn();
            }
            else
            {
                spaceship.RightThrusterOff();
            }
            if (Input.GetAxisRaw($"p{playerNumber} shoot") > 0)
            {
                spaceship.Shoot();
            }
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
