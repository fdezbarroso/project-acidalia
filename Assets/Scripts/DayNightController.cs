using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayNightController : MonoBehaviour
{
    /* Format: 00:00 - 23:50 */
    private TMP_Text dayNightIndicator;

    [Header("General Time Attributes")]
    public int day;
    [SerializeField]
    private int hour;
    [SerializeField]
    private int minute;

    [Header("Internal Time Attributes")]
    [SerializeField]
    private int totalTime;
    [SerializeField]
    private int currentTime;
    public bool isDay;

    [HideInInspector]
    public bool sleeping;
    [HideInInspector]
    public float decimalTime;

    private void Awake()
    {
        dayNightIndicator = GameObject.Find("TimeIndicator").GetComponent<TMP_Text>();
        // 180, 06:00
        totalTime = 720;
        currentTime = 180;
        decimalTime = currentTime;
        dayNightIndicator.text = "06:00";
        isDay = false;
        sleeping = false;

        day = 0;
        hour = 0;
        minute = 0;
    }

    private void Update()
    {
        if (!sleeping)
        {
            decimalTime += Time.deltaTime;
            currentTime = (int)decimalTime;

            if (!isDay && hour >= 6)
            {
                isDay = true;
            }
            else if (isDay && hour >= 20)
            {
                isDay = false;
            }

            if (currentTime >= totalTime)
            {
                decimalTime = 0;
                day++;
            }

            hour = currentTime / 30;
            minute = currentTime % 30 / 5;

            dayNightIndicator.text = "DAY " + day.ToString() + "\n" +
                hour.ToString("00") + ":" + minute.ToString() + "0";
        }
    }
}