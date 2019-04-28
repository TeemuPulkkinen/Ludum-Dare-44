using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    // Elämämuuttujat
    public Slider healthBarSlider;
    public float currentHealth;
    public float maxHealth;
    public float bloodloss;
    public float bloodgain;
    bool isDead;

    public Text healthText; // elämäpalkin teksti
    public Player player; // Player-olio
    public GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        // Haetaan pelaajan tiedoista currentHealth ja maxHealth
        currentHealth = player.playerHealth;
        maxHealth = player.playerHealth;
        player.playerAnimator = player.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        /*Seuraavassa haetaan ensin elämäpalkin maksimiksi max>Health ja arvoksi nykyarvo kerran framessa.
         * Sitten asetetaan tiedot tekstiksi palkin päälle.
         * Tämän jälkeen tarkistetaan onko pelaaja kuollut vai ei.
         * Jos ei olla kuolleita, pelaajalta vähennetään bloodlossin verran elämäpisteitä
         * mistä käynnistyy ehtoketju jossa jos pelaaja painaa mitä tahansa nappia, elämäpisteet
         * kuluvat alaspäin. Mutta taas jos nappia ei paineta, palautuvat elämäpisteet yksitellen.
         */
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
            SceneManager.LoadScene("DeathMenu");
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

        // kuolemametodi
        void Dead()
        {
            isDead = true;
            Destroy(player.gameObject, 1f);
        }

    }

    
}
