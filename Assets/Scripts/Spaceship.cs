using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spaceship : MonoBehaviour
{
    public Thruster leftThruster;
    public Thruster rightThruster;
    public Cannons cannons;
    public GameObject explosionEffectPrefab;



    public void Update()
    {
        // Controls
        if (Input.GetKey(KeyCode.D))
        {
            leftThruster.ThrusterOn();
        }
        else
        {
            leftThruster.ThrusterOff();
        }
        if (Input.GetKey(KeyCode.A))
        {
            rightThruster.ThrusterOn();
        }
        else
        {
            rightThruster.ThrusterOff();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            cannons.Shoot();
        }

    }


    public void Die()
    {
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
 
    }


}
