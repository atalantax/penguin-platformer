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

    public Image gameOverScreen;
    public TMP_Text gameOverMessage;

    //private void Start()
    //{
    //    gameOverScreen.enabled = false;
    //    gameOverMessage.enabled = false;
    //}

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
    }

    public void Die()
    {
        Debug.Log("You died!");
        // bar turns grey
        fill.color = Color.gray;
        // everything gets depressing
        // penguin can no longer jump
        // slowly fade into end screen
        StartCoroutine(ShowEndScreen());

    }

    public IEnumerator ShowEndScreen()
    {
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
