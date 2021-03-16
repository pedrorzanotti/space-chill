using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Updates the text displayed on the HUD.
public class HUDText : MonoBehaviour
{
    GameState gameManager;
    TMP_Text text;
    [SerializeField] string highlightColor = "90AFDE";

    void Start()
    {
        gameManager = FindObjectOfType<GameState>();
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        Display();
    }

    //Formats the text displayed on the HUD.
    public void Display()
    {
        string scoreText = "Score:<color=#" + highlightColor + ">" + gameManager.GetScore().ToString() + "</color>";
        string throwsText = "Throws:<color=#" + highlightColor + ">" + gameManager.GetThrows().ToString() + "</color>";
        string timeText = "Time:<color=#" + highlightColor + ">" + FormatTime(gameManager.GetTime());
        text.text = scoreText + ' ' + throwsText + ' ' + timeText;
    }

    //Formats a time value to "00:00".
    public string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time - (minutes * 60));
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}