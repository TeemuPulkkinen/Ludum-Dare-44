using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Slider healthBarSlider;
    public float currentHealth;
    public float maxHealth;
    private Vector3 playerPosition;
    public Text healthText;
    public Player player;
    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = player.playerHealth;
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
            Dead();
        }
        if (currentHealth < maxHealth && )
        {
            while (player.playerBody.velocity.x == 0)
            {
                currentHealth += 1;
                break;
            }
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }
        currentHealth -= 1;
    }

    void Dead()
    {
        isDead = true;
    }
}
