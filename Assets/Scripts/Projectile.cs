using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage => 26;
    public float speed;
    public string otherTeamTag;
    public List<GameObject> hitPrefabs;
    
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
            AfterHit(other);
        }
        else if (other.CompareTag("Obstacle")) {
            AfterHit(other);
        }
    }

    private void AfterHit(Collider other) {
        GameObject randomHitPrefab = hitPrefabs[Random.Range(0, hitPrefabs.Count)];
        Vector3 impactPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position); 
        GameObject instance = Instantiate(randomHitPrefab, impactPoint, Quaternion.identity);
        instance.transform.localScale = Vector3.one * 5; // Scale up so you see it
        Destroy(gameObject);
    }

}
