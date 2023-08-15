using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public DragDropController dragDropController;
    [HideInInspector]
    public DayNightController dayNightController;
    [HideInInspector]
    public GameOverController gameOverController;

    public ItemContainer inventory;

    private void Awake()
    {
        Instance = this;

        player = GameObject.Find("Player");

        dragDropController = GetComponent<DragDropController>();
        dayNightController = GetComponent<DayNightController>();

        gameOverController = GameObject.Find("GameOver").GetComponent<GameOverController>();

        gameOverController.gameObject.SetActive(false);
    }
}
