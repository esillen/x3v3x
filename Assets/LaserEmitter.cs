using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmitter : MonoBehaviour
{
    public List<GameObject> laserTypes;
    public float offsetAmount = 7;
    public int stopEmittingPercent = 10; // % chance that the emitter is removed.
    private GameObject laserPrefab;
    private bool laserSide;

    void Start()
    {
        laserPrefab = laserTypes[Random.Range(0, laserTypes.Count)];
        laserSide = Random.Range(0, 2) == 1;
        StartCoroutine(SpawnLaser());
    }

  private IEnumerator SpawnLaser()
  {
    yield return new WaitForSeconds(Random.Range(0.08f, 0.13f)); 
    Vector3 offset = transform.right * offsetAmount * (laserSide ? 1 : -1);
    laserSide = !laserSide;
    GameObject laserInstance = Instantiate(laserPrefab, transform.position + offset, Quaternion.identity);
    Destroy(laserInstance.GetComponent<Collider>()); // Don't get collissions
    laserInstance.transform.forward = transform.forward;
    if (Random.Range(0, 100) < stopEmittingPercent) {
        Destroy(gameObject);
    } else {
        StartCoroutine(SpawnLaser());
    }
  }

}
