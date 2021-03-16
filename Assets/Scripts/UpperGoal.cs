using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Monitors the top of the rim and stores the last ball that passed through it.
public class UpperGoal : MonoBehaviour
{
    Ball ball = null;

    void OnTriggerEnter(Collider other)
    {
        ball = other.GetComponent<Ball>();
    }

    public Ball GetBall()
    {
        return ball;
    }
}