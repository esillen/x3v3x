using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int playerNumber;
    public GameObject spaceshipPrefab;
    public Spaceship spaceship;
    public GameManager gameManager;
    public SpawnPoint spawnPoint;


    private float spawnTime = 5;
    private ControlMap controlMap;



    void Awake() {
        spaceship.player = this;
        controlMap = GetComponent<ControlMap>();
    }


    void Update()
    {
        if (spaceship != null && gameManager.gameIsOn) {
            if (controlMap.LeftKeyPressed)
            {
                spaceship.LeftThrusterOn();
            }
            else { 
                spaceship.LeftThrusterOff();
            }
            if (controlMap.RightKeyPressed)
            {
                spaceship.RightThrusterOn();
            }
            else
            {
                spaceship.RightThrusterOff();
            }
            if (controlMap.CenterKeyPressed)
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
        GameObject newSpaceshipGameObject = Instantiate(spaceshipPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        spaceship = newSpaceshipGameObject.GetComponent<Spaceship>();
        spaceship.player = this;
    }



}
