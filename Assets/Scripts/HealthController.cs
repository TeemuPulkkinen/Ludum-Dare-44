using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Slider healthBarSlider;
    public float currentHealth;
    public float maxHealth;
    public float bloodloss;
    public float bloodgain;
    public Text healthText;
    public Player player;
    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = player.playerHealth;
        maxHealth = player.playerHealth;       
    }

    // Update is called once per frame
    void Update()
    {
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();

        if (currentHealth <= 0)
        {
            if (isDead)
            {
                return;
            }
            // Kuolema-animaatio
            Dead();
        }

        currentHealth -= bloodloss;

        if (currentHealth < maxHealth)
        {
            while (Input.anyKey)
            {
                currentHealth -= bloodloss;
                break;                
            }

            if (currentHealth < maxHealth && !Input.anyKey)
            {
                while (!Input.anyKey)
                {
                    currentHealth += bloodgain;
                    break;
                }

                if (currentHealth == maxHealth)
                {
                    return;
                }
            }

            currentHealth += bloodgain;

        }

        void Dead()
        {
            isDead = true;
        }
    }
}
