using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject room;
    public GameObject creditsScreen;
    public GameObject player;
    public GameObject enemy;

    private readonly Vector3 startPosition = new Vector3(0, 0.75f, 0);

    public void StartGame()
    {
        titleScreen.SetActive(false);
        room.SetActive(true);
        Instantiate(player, startPosition, player.transform.rotation);
        StartCoroutine(Timer());
    }

    public void ShowCredits()
    {
        titleScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void ExitCredits()
    {
        creditsScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            GameObject.Find("Player(Clone)").GetComponent<PlayerController>().throwableProjectiles = true;
        }
    }
}
