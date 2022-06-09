using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float currentTime;

    private bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            currentTime = currentTime += Time.deltaTime;
            timerText.text = Mathf.Floor(currentTime).ToString();
        }
        
    }

    public void StopTimer()
    {
        gameOver = true;
    }
}
