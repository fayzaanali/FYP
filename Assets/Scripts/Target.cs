using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Target : MonoBehaviour
{
    public float health, maxHealth;
    public Image healthBar;
    public Canvas targetCanvas;
    public GameObject enemy;
    public TextMeshProUGUI displayTargetAmount;

    int targetKilled;
    //public TextMeshProUGUI displayFeed;
    //public List<TextMeshProUGUI> displayList;

    public void takeDmg(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            //Invoke("DisplayFeed", 0.2f);
            Die();
        }
    }

    //void DisplayFeed()
    //{
    //    displayList[0].text = "Player killed " + enemy.name;
    //    displayList[1].text = "Player killed " + enemy.name;
    //    displayList[2].text = "Player killed " + enemy.name;
    //}

    void Die()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        //healthBar.transform.LookAt(healthBar.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        targetCanvas.transform.LookAt(targetCanvas.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);

        float fillHealth = healthBar.fillAmount;
        float healthFraction = health / maxHealth;
        if (fillHealth > healthFraction)
        {
            healthBar.fillAmount = healthFraction;
        }
    }
}
