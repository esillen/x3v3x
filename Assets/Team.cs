using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public void TeammateDied(Spaceship spaceship) {
        StartCoroutine(RespawnAfterSomeTime(spaceship.gameObject));
    }


    private IEnumerator RespawnAfterSomeTime(GameObject spaceshipGameObject) {
        yield return new WaitForSeconds(5);

        Instantiate(spaceshipGameObject);
    }

}
