using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannons : MonoBehaviour
{
    public Cannon leftCannon;
    public Cannon rightCannon;
    public GameObject display;
    public float maxY = 20;
    public float powerPerShot = 5;
    public float powerRechargeRate = 5;
    public float maxPower = 50;

    private float powerLeft;
    private Cannon lastCannon;
    private float cooldownLeft = 0;

    void Start()
    {
        display.transform.localScale = new Vector3(1, maxY, 1);
        powerLeft = maxPower;
        lastCannon = leftCannon;
    }

    void Update()
    {
        // Recharge
        powerLeft += powerRechargeRate * Time.deltaTime;
        if (powerLeft > maxPower)
        {
            powerLeft = maxPower;
            display.SetActive(false);
        }
        else { 
            display.SetActive(true);
        }
        cooldownLeft = Mathf.Max(cooldownLeft - Time.deltaTime, 0);
        // Display
        display.transform.localScale = new Vector3(1, 2.5f * maxY * ((powerLeft / maxPower) - 0.4f), 1);
    }

    public void Shoot()
    {
        if (powerLeft >= powerPerShot && cooldownLeft <= 0)
        {
            powerLeft -= powerPerShot;
            lastCannon = lastCannon == rightCannon ? leftCannon : rightCannon;
            cooldownLeft = CalcCooldown();
            lastCannon.Shoot();

        }
    }

    private float CalcCooldown()
    {
        float cutoff = 0.25f;
        float powerLeftFraction = powerLeft / maxPower;
        if (powerLeftFraction < cutoff) { 
            powerLeftFraction = cutoff;
        }
        return Mathf.Exp(-powerLeftFraction * 3);
    }
}
