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

    private AudioSource myAudioSource;
    public AudioClip[] music;

    private string musicType = "";


    public Image gameOverScreen;
    public TMP_Text gameOverMessage;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
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
            myAudioSource.clip = music[0];
            myAudioSource.Play();
            musicType = "Happy";
        }
        else if (health < 35 && musicType == "Happy")
        {
            myAudioSource.clip = music[1];
            myAudioSource.Play();
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

    public IEnumerator ShowEndScreen()
    {
        musicType = "Sad";
        myAudioSource.clip = music[2];
        myAudioSource.Play();
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
