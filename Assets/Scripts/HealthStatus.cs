using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthStatus: MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public float fadeSpeed = 1;

    public AudioSource HappyMusic;
    public AudioSource TenseMusic;
    public AudioSource SadMusic;



    private string musicType = "";
    private bool tensePlayed = false;


    public Image gameOverScreen;
    public TMP_Text gameOverMessage;

    private void Start()
    {
        HappyMusic.volume = 100;
        TenseMusic.volume = 0;
        SadMusic.volume = 0;
        HappyMusic.Play();
        TenseMusic.Play();
        SadMusic.Play();

    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (health >= 35 && musicType != "Happy")
        {
            HappyMusic.volume = 100;
            TenseMusic.volume = 0;
            SadMusic.volume = 0;


            musicType = "Happy";
        }
        else if (health < 35 && health > 0 && musicType != "Tense")
        {
            HappyMusic.volume = 0;
            TenseMusic.volume = 100;
            SadMusic.volume = 0;
            musicType = "Tense";
        }
    }

    public void Die()
    {
        Debug.Log("You died!");
        // bar turns grey
        fill.color = Color.gray;
        slider.value = 100;
        // everything gets depressing
        // penguin can no longer jump
        // slowly fade into end screen
        StartCoroutine(ShowEndScreen());

    }

    // use math lerp over time
    // happen relatively fast compared to gme state

    public IEnumerator ShowEndScreen()
    {
        musicType = "Sad";
        HappyMusic.volume = 0;
        TenseMusic.volume = 0;
        SadMusic.volume = 100;
        Color objectColor = gameOverScreen.color;
        Color textColor = gameOverMessage.color;
        float fadeAmount;
        while (gameOverScreen.color.a < 1)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
            Debug.Log(fadeAmount);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);
            gameOverScreen.color = objectColor;
            gameOverMessage.color = textColor;
            yield return null;
        }
    }
}
