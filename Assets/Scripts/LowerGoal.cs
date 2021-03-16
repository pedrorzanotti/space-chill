using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Monitors the bottom of the rim and triggers the events related to scoring a point.
public class LowerGoal : MonoBehaviour
{
    [SerializeField] UpperGoal upperGoal;
    [SerializeField] GameObject confettiPrefab;
    [SerializeField] AudioClip successSFX;

    //Time to generate a new challenge after scoring a point.
    [SerializeField] float challengeDelayTime = 1.5f;

    void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball)
        {
            //Scores the point only if the ball that passed through it is the same as the one that passed through the upper part of the rim.
            if (ball.isQualifiedToScore() && Object.ReferenceEquals(ball, upperGoal.GetBall()))
            {
                ScorePoint();

                //Generates a new challenge after scoring a point.
                StartCoroutine(FindObjectOfType<GameManager>().StartChallenge(challengeDelayTime));
            }
            ball.SetQualifiedToScore(false);
        }
    }

    //Increases the score by 1 and triggers some VFX/SFX.
    public void ScorePoint()
    {
        FindObjectOfType<AudioSource>().PlayOneShot(successSFX);
        GameObject confetti = Instantiate(confettiPrefab, confettiPrefab.transform.position, Quaternion.identity);
        Destroy(confetti, challengeDelayTime);
        FindObjectOfType<GameState>().IncrementScore();
    }
}