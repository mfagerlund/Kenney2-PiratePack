using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int livesLeft;
    public GameObject playerPrefab;
    public GameObject gameWonPanel;
    public GameObject gameLostPanel;

    public void Start()
    {
        Instance = this;
        livesLeft = 3;
    }

    public void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            if (livesLeft > 0)
            {
                Instantiate(playerPrefab);
            }
            else
            {
                gameLostPanel.SetActive(true);
            }
        }
        if (!GameObject.FindGameObjectsWithTag("Enemy").Any())
        {
            gameWonPanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
