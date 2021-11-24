using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject room;
    public GameObject creditsScreen;
    public GameObject player;
    public GameObject enemy;

    // Position of the spawn of the player when pressing start
    private readonly Vector3 startPosition = new Vector3(0, 0.75f, 0);

    // Button Start Pressed
    public void StartGame()
    {
        titleScreen.SetActive(false);
        room.SetActive(true);
        Instantiate(player, startPosition, player.transform.rotation);
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
        // TODO : Define a game over and make is as a condition of the while loop
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            GameObject.Find("Player(Clone)").GetComponent<PlayerController>().throwableProjectiles = true;
        }
    }
}
