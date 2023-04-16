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
        if (other.CompareTag(otherTeamTag))
        {
            if (other.GetComponentInChildren<Shield>() != null)
            {
                other.GetComponentInChildren<Shield>().TakeDamage(damage);
            } else if (other.GetComponent<Mothership>() != null) {
                other.GetComponent<Mothership>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }

}
