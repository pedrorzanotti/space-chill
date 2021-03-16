using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the player interaction's with the ball.
public class Player : MonoBehaviour
{
    Ball ball;

    //Distance between the player and the ball.
    [SerializeField] float yBallOffset = -0.5f;
    [SerializeField] float zBallOffset = 2.5f;

    //Prevents the player from applying force to a ball that has not yet been spawned.
    bool holdingMouse = false;

    float startTime = 0f;
    [SerializeField] float maxHoldingTime = 1f;
    float throwingForce = 0f;
    [SerializeField] float maxThrowingForce = 1000f;

    void Update()
    {
        if (ball)
        {
            Hold();

            //Records the moment the left mouse button is pressed.
            if (Input.GetMouseButtonDown(0))
            {
                startTime = Time.time;
                holdingMouse = true;
            }

            //Calculates the throwing force based on the elapsed time.
            if (Input.GetMouseButton(0) && holdingMouse)
            {
                float elapsedTime = Time.time - startTime;
                throwingForce = maxThrowingForce * Mathf.Clamp01(elapsedTime / maxHoldingTime);
            }

            //Throws the ball when the left mouse button is released.
            if (Input.GetMouseButtonUp(0) && holdingMouse)
            {
                holdingMouse = false;
                Throw();
                ball = null;
            }
        }
    }

    public Ball getBall()
    {
        return ball;
    }

    public void SetBall(Ball ball)
    {
        this.ball = ball;
    }

    public float GetThrowingForce()
    {
        return throwingForce;
    }

    public float GetMaxThrowingForce()
    {
        return maxThrowingForce;
    }

    //Keeps the ball in the proper place when the player looks around.
    public void Hold()
    {
        ball.transform.position = transform.position + (transform.up * yBallOffset) + (transform.forward * zBallOffset);
        ball.transform.rotation = transform.rotation;
    }

    //Applies the accumulated force to the ball, throwing it forward and increasing the number of throws by 1.
    public void Throw()
    {
        ball.SetBeingThrown(true);
        ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * throwingForce);
        throwingForce = 0f;
        FindObjectOfType<GameState>().IncrementThrows();
    }
}