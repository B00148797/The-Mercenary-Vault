using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject room;
    public GameObject creditsScreen;
    public GameObject player;
    public GameObject enemy;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public TextMeshProUGUI healthText;

    private PlayerController mainPlayer;

    // Position of the spawn of the player when pressing start
    private readonly Vector3 startPosition = new Vector3(0, 0.75f, 0);

    // Is Game Over
    private bool isGameOver = false;

    // Button Start Pressed
    public void StartGame()
    {
        titleScreen.SetActive(false);
        room.SetActive(true);
        Instantiate(player, startPosition, player.transform.rotation);
        mainPlayer = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
        healthText.text = "Health Remaining: " + mainPlayer.health;
        StartCoroutine(Timer());
    }

    // Button Credits Pressed
    public void ShowCredits()
    {
        titleScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    // Button ExitCredits Pressed
    public void ExitCredits()
    {
        creditsScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

    // Routine To Avoid Projectiles Spam
    private IEnumerator Timer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(0.3f);

            if(mainPlayer.health <= 0)
            {
                GameOver();
            }
            else if (mainPlayer.win)
            {
                Win();
            } 
            // Change the health displayed if needed and make projectiles throwable
            else
            {
                healthText.text = "Health Remaining: " + mainPlayer.health;
                mainPlayer.throwableProjectiles = true;
            }
        }
    }

    // Display the GameOver sreen
    private void GameOver()
    {
        isGameOver = true;
        room.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    // Display the win screen
    private void Win()
    {
        isGameOver = true;
        room.SetActive(false);
        winScreen.SetActive(true);
    }
}
