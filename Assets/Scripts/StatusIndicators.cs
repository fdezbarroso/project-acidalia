using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusIndicators : MonoBehaviour
{
    private TMP_Text hungerValueText;
    private TMP_Text thirstValueText;
    private TMP_Text healthValueText;
    private TMP_Text temperatureValueText;

    [Header("Player Status")]
    [Range(0f, 120f)]
    public float hunger;
    [Range(0f, 120f)]
    public float thirst;
    [Range(0f, 100f)]
    public float health;
    [Range(0f, 36.5f)]
    public float temperature;

    private float defLoss;

    private float saturationMax;
    private float showChange;

    private bool outside;

    private void Awake()
    {
        /* Check if UI reworked */
        hungerValueText = GameObject.Find("HungerValue").GetComponent<TMP_Text>();
        thirstValueText = GameObject.Find("ThirstValue").GetComponent<TMP_Text>();
        healthValueText = GameObject.Find("HealthValue").GetComponent<TMP_Text>();
        temperatureValueText = GameObject.Find("TemperatureValue").GetComponent<TMP_Text>();

        saturationMax = 120;
        showChange = 100;
        defLoss = 0.5f;

        outside = false;

        hunger = saturationMax;
        thirst = saturationMax;
        health = 100;
        temperature = 36.5f;

        hungerValueText.text = ((int)hunger).ToString();
        thirstValueText.text = ((int)thirst).ToString();
        healthValueText.text = ((int)health).ToString();
        temperatureValueText.text = temperature.ToString("00.0");
    }

    private void Update()
    {
        if (hunger > 0)
        {
            hunger -= (defLoss / 2) * Time.deltaTime;
        }
        if (thirst > 0)
        {
            thirst -= defLoss * Time.deltaTime;
        }
        if (outside)
        {
            temperature -= (defLoss / 5) * Time.deltaTime;
        }
        else if (!outside && temperature < 36.5f)
        {
            temperature += (defLoss / 2) * Time.deltaTime;
        }

        if (hunger < showChange)
        {
            hungerValueText.text = ((int)hunger).ToString();
        }
        else
        {
            hungerValueText.text = ((int)showChange).ToString();
        }
        if (thirst < showChange)
        {
            thirstValueText.text = ((int)thirst).ToString();
        }
        else
        {
            thirstValueText.text = ((int)showChange).ToString();
        }
        temperatureValueText.text = temperature.ToString();

        if (health > 0)
        {
            if (thirst < 1 || hunger < 1)
            {
                health -= (defLoss * 5) * Time.deltaTime;
                healthValueText.text = ((int)health).ToString();
            }
            else if (thirst < 1 && hunger < 1)
            {
                health -= (defLoss * 10) * Time.deltaTime;
                healthValueText.text = ((int)health).ToString();
            }

            if (temperature < 35)
            {
                health -= (defLoss * 2) * Time.deltaTime;
                healthValueText.text = ((int)health).ToString();
            }
            else if (temperature < 33)
            {
                health -= (defLoss * 5) * Time.deltaTime;
                healthValueText.text = ((int)health).ToString();
            }
            else if (temperature < 30)
            {
                health -= (defLoss * 10) * Time.deltaTime;
                healthValueText.text = ((int)health).ToString();
            }
        }
        else if (health <= 0.5f)
        {
            GameManager.Instance.gameOverController.GameOver();
        }
    }
}
