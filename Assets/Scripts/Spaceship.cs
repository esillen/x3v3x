using System;
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
    public Player player;


    public void Die()
    {
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        player.Die();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
 
    }

    internal void LeftThrusterOn()
    {
        leftThruster.ThrusterOn();
    }

    internal void RightThrusterOn()
    {
        rightThruster.ThrusterOn();
    }

    internal void LeftThrusterOff()
    {
        leftThruster.ThrusterOff();
    }

    internal void RightThrusterOff()
    {
        rightThruster.ThrusterOff();
    }

    internal void Shoot()
    {
        cannons.Shoot();
    }
}
