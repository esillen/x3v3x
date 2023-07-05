using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int playerNumber;
    
    void Start()
    {
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<Collider>());
        foreach (Spaceship spaceship in FindObjectsOfType<Spaceship>()) {
            if (spaceship.player.playerNumber == playerNumber) {
                spaceship.gameObject.transform.position = transform.position;
                spaceship.gameObject.transform.rotation = transform.rotation;
                spaceship.player.spawnPoint = this;
            }
        }
        Destroy(transform.GetChild(0).gameObject);
    }

}
