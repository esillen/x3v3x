using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipSpawnPoint : MonoBehaviour
{
    public int teamNumber;
    
    void Start()
    {
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<Collider>());
        foreach (Mothership mothership in FindObjectsOfType<Mothership>()) {
            if (mothership.gameObject.CompareTag("Team " + teamNumber)) { // ugly af
                mothership.gameObject.transform.position = transform.position;
                mothership.gameObject.transform.rotation = transform.rotation;
            }
        }
        Destroy(transform.GetChild(0).gameObject);
    }
}
