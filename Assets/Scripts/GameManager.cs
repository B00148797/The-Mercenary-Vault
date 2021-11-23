using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject room;
    public GameObject creditsScreen;

    public void StartGame()
    {
        titleScreen.SetActive(false);
        room.SetActive(true);
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
}
