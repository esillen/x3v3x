using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelfAfterTime : MonoBehaviour
{

    public float seconds = 5;

    void Start()
    {
        StartCoroutine(DeleteSelfAfterSeconds(seconds));
    }


    private IEnumerator DeleteSelfAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    
}
