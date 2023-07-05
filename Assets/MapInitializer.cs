using UnityEngine;

public class MapInitializer : MonoBehaviour
{
    public GameObject defaultMap; 

    void Start()
    {
        if (MapChooser.choosenMapPrefab != null) {
            Instantiate(MapChooser.choosenMapPrefab, transform);
        } else {
            Instantiate(defaultMap, transform); // If starting from editor
        }
    }
}
