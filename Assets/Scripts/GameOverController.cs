using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void GameOver()
    {
        GameManager.Instance.player.GetComponent<PlayerController>().enabled = false;
        GameManager.Instance.player.GetComponent<PlayerInteractController>().enabled = false;
        GameManager.Instance.player.GetComponent<PlayerToolController>().enabled = false;
        GameManager.Instance.player.GetComponent<InventoryController>().enabled = false;
        GameManager.Instance.player.GetComponent<StatusIndicators>().enabled = false;
        GameManager.Instance.player.GetComponent<PlayerResourceController>().enabled = false;
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
