using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public Spaceship spaceship;

    public float maxShieldRadius => 50;
    public float minShieldRadius => 20;
    public float shieldRechargeRate => 20;
    public float shieldRechargeCooldown => 2;
    public float maxShieldLeft => 100;


    private float shieldLeft;
    private float shieldCurrentRechargeCooldown = 0;


    void Start()
    {
        shieldLeft = maxShieldLeft;
    }

    void Update()
    {
        // Shield recharge
        shieldCurrentRechargeCooldown -= Time.deltaTime;
        if (shieldCurrentRechargeCooldown <= 0)
        {
            shieldCurrentRechargeCooldown = 0;
            shieldLeft += shieldRechargeRate * Time.deltaTime;
        }

        // Shield on or off (an capping it at max)
        if (shieldLeft >= maxShieldLeft)
        {
            shieldLeft = maxShieldLeft;
            GetComponent<MeshRenderer>().enabled = false;
        } else
        {
            GetComponent<MeshRenderer>().enabled = true;
        }

        // Shield scale
        transform.localScale = new Vector3(1, 1, 1) * (minShieldRadius + ((shieldLeft / maxShieldLeft) * (maxShieldRadius - minShieldRadius)));

    }

    public void TakeDamage(float damage)
    {
        shieldCurrentRechargeCooldown = shieldRechargeCooldown;
        shieldLeft -= damage;
        if (shieldLeft <= 0)
        {
            spaceship.Die();
        }
    }

}
