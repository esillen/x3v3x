using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mothership : MonoBehaviour
{

    public Text healthLeftText;

    private float lifeLeft = 5000;

    internal void TakeDamage(float damage)
    {
        lifeLeft -= damage;
        healthLeftText.text = "Mothership: " + lifeLeft;
    }

}
