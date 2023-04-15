using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage => 26;
    public float speed;
    public string otherTeamTag;
    
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;    
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger enter");
        if (other.CompareTag(otherTeamTag)) {
            print("hit");
            other.GetComponent<Shield>().TakeDamage(damage);
        }
    }
}
