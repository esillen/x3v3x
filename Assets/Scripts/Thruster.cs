using CartoonFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{

    public int power;
    public ParticleSystem fireParticleSystem;


    public void ThrusterOn()
    {
        transform.parent.parent.GetComponent<Rigidbody>().AddForceAtPosition(transform.forward * Time.deltaTime * power, transform.position);
        if (!fireParticleSystem.isPlaying)
        {
            fireParticleSystem.Play();
        }
    }

    public void ThrusterOff()
    {
        if (fireParticleSystem.isPlaying)
        {
            fireParticleSystem.Stop();
        }
    }
}
