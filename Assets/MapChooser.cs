using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChooser : MonoBehaviour
{
    public static GameObject choosenMapPrefab;
    public List<GameObject> mapPrefabs;
    private int currentMapIndex = 0;

    public GameObject currentMapInstance;

    void Start() {
        ShowMapAtCurrentIndex();
    }

    public static int Wraparound(int input, int divisor)
    {
        return (input % divisor + divisor) % divisor;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { // TODO: add control map stuff
            currentMapIndex = Wraparound(currentMapIndex + 1, mapPrefabs.Count);
            ShowMapAtCurrentIndex();
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) { // TODO: add control map stuff
            currentMapIndex = Wraparound(currentMapIndex - 1, mapPrefabs.Count);
            ShowMapAtCurrentIndex();
        }

    }


    private void ShowMapAtCurrentIndex() {
        if (currentMapInstance != null) {
            Destroy(currentMapInstance);
        }
        choosenMapPrefab = mapPrefabs[currentMapIndex];
        currentMapInstance = Instantiate(choosenMapPrefab, transform.position, transform.rotation);
        currentMapInstance.transform.localScale = Vector3.one * 0.35f;
        foreach(SpawnPoint spawnPoint in currentMapInstance.transform.GetComponentsInChildren<SpawnPoint>()) {
            Destroy(spawnPoint); // Stop logic
        }
        foreach(MothershipSpawnPoint spawnPoint in currentMapInstance.transform.GetComponentsInChildren<MothershipSpawnPoint>()) {
            Destroy(spawnPoint); // Stop logic
        }

    }
    
}
