using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    private float lerpTime;
    public Image frontHealth, backHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        updateHealthUI();
        // for testing
        if (Input.GetKeyDown(KeyCode.Q))
        {
            takeDamage(Random.Range(5, 10));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            restoreHealth(Random.Range(5, 10));
        }
    }

    public void updateHealthUI()
    {
        float fillFront = frontHealth.fillAmount;
        float fillBack = backHealth.fillAmount;
        float healthFraction = health / maxHealth;

        if (fillBack > healthFraction)
        {
            frontHealth.fillAmount = healthFraction;
            backHealth.color = Color.red;
            lerpTime += Time.deltaTime;
            float percentComplete = lerpTime / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealth.fillAmount = Mathf.Lerp(fillBack, healthFraction, percentComplete);
        }

        if (fillFront < healthFraction)
        {
            backHealth.color = Color.green;
            backHealth.fillAmount = healthFraction;
            lerpTime += Time.deltaTime;
            float percentComplete = lerpTime / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealth.fillAmount = Mathf.Lerp(fillFront, backHealth.fillAmount, percentComplete);
        }
    }

    public void takeDamage(float dmg)
    {
        health -= dmg;
        lerpTime = 0f;
    }

    public void restoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTime= 0f;
    }
}
