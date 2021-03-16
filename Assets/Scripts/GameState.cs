using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stores the information displayed as text on the HUD.
public class GameState : MonoBehaviour
{
    //Refers to all challenges.
    int score = 0;

    //Refers to the current challenge.
    int throws;
    float startTime;
    float time;

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }

    public void IncrementScore()
    {
        score++;
    }

    public int GetThrows()
    {
        return throws;
    }

    public void SetThrows(int throws)
    {
        this.throws = throws;
    }

    public void IncrementThrows()
    {
        throws++;
    }

    public float GetStartTime()
    {
        return startTime;
    }

    public void SetStartTime(float startTime)
    {
        this.startTime = startTime;
    }

    public float GetTime()
    {
        return time;
    }

    public void SetTime(float time)
    {
        this.time = time;
    }
}