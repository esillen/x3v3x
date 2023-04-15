using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spaceship : MonoBehaviour
{
    public Thruster leftThruster;
    public Thruster rightThruster;
    public Cannons cannons;


    public void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            leftThruster.ThrusterOn();
        } else
        {
            leftThruster.ThrusterOff();
        }
        if (Input.GetKey(KeyCode.A))
        {
            rightThruster.ThrusterOn();
        } else
        {
            rightThruster.ThrusterOff();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            cannons.Shoot();
        }


    }


}
