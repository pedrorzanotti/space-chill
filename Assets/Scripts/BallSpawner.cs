using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawns the balls the player throws.
public class BallSpawner : MonoBehaviour
{
    [SerializeField] Ball ballPrefab;
    Player player;

    //Prevents the spawner from spawning multiple balls.
    bool spawning = false;

    //Time to spawn a new ball after the player has thrown theirs.
    [SerializeField] float spawnDelayTime = 1.5f;

    void Start()
    {
        player = FindObjectOfType<Player>();

        //Spawn the first ball without delay.
        spawning = true;
        StartCoroutine(Spawn(0));
    }

    void Update()
    {
        //Spawns a ball if the player has none.
        if (!player.getBall() && !spawning)
        {
            spawning = true;
            StartCoroutine(Spawn(spawnDelayTime));
        }
    }

    //Spawns a ball after some time and sets the spawner as its parent.
    public IEnumerator Spawn(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Ball ball = Instantiate(ballPrefab, transform.position, transform.rotation) as Ball;
        ball.transform.parent = transform;
        player.SetBall(ball);
        spawning = false;
    }
}