using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mothership : MonoBehaviour
{

    public GameObject explosionPrefab;
    public GameManager gameManager;
    public Text healthLeftText;

    private float lifeLeft = 2000;

    void Start() {
        DisplayLifeLeft();
    }

    internal void TakeDamage(float damage)
    {
        if (gameManager.gameIsOn) {
            if (lifeLeft > 0) {
                lifeLeft -= damage;
                if (lifeLeft <= 0) {
                    lifeLeft = 0;
                    Die();
                }
            }
            DisplayLifeLeft();
        }
    }

    private void DisplayLifeLeft() {
        healthLeftText.text = "Mothership: " + lifeLeft;
    }

    private void Die() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        FindObjectOfType<GameManager>().GameOver();
        Destroy(gameObject);

    }

}
