using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsSpawner : MonoBehaviour
{

    public List<GameObject> explosionEffects;
    public GameObject laserEmitterPrefab;

    public float effectMinDelay = 2f;
    public float effectMaxDelay = 7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnExplosionEffectLoop());
        StartCoroutine(SpawnExplosionEffectLoop());
        StartCoroutine(SpawnExplosionEffectLoop());
        StartCoroutine(SpawnLaserEmitterLoop());
        StartCoroutine(SpawnLaserEmitterLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnExplosionEffectLoop() {
        yield return new WaitForSeconds(Random.Range(effectMinDelay, effectMaxDelay));
        int randomX = Random.Range(1, Screen.width - 1);
        int randomY = Random.Range(1, Screen.height - 1);
        Vector3 pointAtCamera = Camera.main.ScreenToWorldPoint(new Vector2(randomX, randomY));
        Vector3 pointSomeWayDown = pointAtCamera + Camera.main.transform.forward * 10;
        Instantiate(explosionEffects[Random.Range(0, explosionEffects.Count)], pointSomeWayDown, Quaternion.identity);
        StartCoroutine(SpawnExplosionEffectLoop());
    }

    private IEnumerator SpawnLaserEmitterLoop() {
        yield return new WaitForSeconds(Random.Range(effectMinDelay, effectMaxDelay));
        float randomAngle = Random.Range(0, 2 * Mathf.PI);

        // Lazyest way ever of getting a position slightly outside screen view.
        float xStep = Mathf.Cos(randomAngle) * 10;
        float yStep = Mathf.Sin(randomAngle) * 10;
        float x = Screen.width / 2;
        float y = Screen.height / 2;
        for (int i = 0; i < 200; i += 1) {
            x += xStep;
            y += yStep;
            if (x < 0 || y < 0 || x > Screen.width || y > Screen.height) {
                break;
            }
        }

        Vector3 pointAtCamera = Camera.main.ScreenToWorldPoint(new Vector2(x, y));
        Vector3 pointSomeWayDown = pointAtCamera + Camera.main.transform.forward * 10;
        GameObject laserEmitter = Instantiate(laserEmitterPrefab, pointSomeWayDown, Quaternion.identity);
        laserEmitter.transform.forward = Vector3.zero - laserEmitter.transform.position; // TODO skewed?
        laserEmitter.transform.Rotate(new Vector3(0, Random.Range(-20, 20),0)); 
        StartCoroutine(SpawnLaserEmitterLoop());
    }


}
