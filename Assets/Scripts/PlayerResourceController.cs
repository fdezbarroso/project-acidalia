using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class PlayerResourceController : MonoBehaviour
{
    private TMP_Text rationsText;
    private TMP_Text waterBottlesText;
    private TMP_Text moneyText;

    public int rations;
    public int waterBottles;
    public int money;

    StatusIndicators statusIndicators;

    private void Awake()
    {
        rationsText = GameObject.Find("/UI/ToolbarAmounts/RationsControl").GetComponent<TMP_Text>();
        waterBottlesText = GameObject.Find("/UI/ToolbarAmounts/WaterControl").GetComponent<TMP_Text>();
        moneyText = GameObject.Find("MoneyAmount").GetComponent<TMP_Text>();

        statusIndicators = gameObject.GetComponent<StatusIndicators>();

        rations = 1;
        waterBottles = 3;
        money = 20;

        rationsText.text = ((int)rations).ToString();
        waterBottlesText.text = ((int)waterBottles).ToString();
        moneyText.text = ((int)money).ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if ((rations > 0) && (statusIndicators.hunger < 100))
            {
                statusIndicators.hunger += 20;
                rations--;
                rationsText.text = ((int)rations).ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if ((waterBottles > 0) && (statusIndicators.thirst < 100))
            {
                statusIndicators.thirst += 20;
                waterBottles--;
                waterBottlesText.text = ((int)waterBottles).ToString();
            }
        }
    }

    public void UpdateFood()
    {
        rations++;
        rationsText.text = ((int)rations).ToString();
    }

    public void UpdateWater()
    {
        waterBottles++;
        waterBottlesText.text = ((int)waterBottles).ToString();
    }

    public void UpdateMoney(int value)
    {
        money += value;
        moneyText.text = ((int)money).ToString();
    }
}
