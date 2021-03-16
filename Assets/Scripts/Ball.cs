using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the physics and despawning of the ball.
public class Ball : MonoBehaviour
{
    Collider _collider;
    Rigidbody _rigidbody;
    [SerializeField] AudioClip whooshSFX;
    [SerializeField] AudioClip bounceSFX;
    
    //Signals the moment the ball is being thrown.
    bool beingThrown = false;

    //Prevents the ball from scoring multiple times or scoring upwards.
    bool qualifiedToScore = true;
    
    //Time to self-destruct after being thrown.
    [SerializeField] float destructionDelayTime = 7.5f;

    void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();

        //Ignores physics while being held by the player.
        TogglePhysics(false);
    }

    void Update()
    {
        if(beingThrown)
        {
            TogglePhysics(true);
            FindObjectOfType<AudioSource>().PlayOneShot(whooshSFX);
            beingThrown = false;

            //Self-destructs after some time.
            Destroy(this.gameObject, destructionDelayTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<AudioSource>().PlayOneShot(bounceSFX); 
    }

    public void SetBeingThrown(bool beingThrown)
    {
        this.beingThrown = beingThrown;
    }

    public bool isQualifiedToScore()
    {
        return qualifiedToScore;
    }

    public void SetQualifiedToScore(bool qualifiedToScore)
    {
        this.qualifiedToScore = qualifiedToScore;
    }

    //Enables or disables physics on the ball.
    public void TogglePhysics(bool enabled)
    {
        _collider.enabled = enabled;
        _rigidbody.useGravity = enabled;
    }
}