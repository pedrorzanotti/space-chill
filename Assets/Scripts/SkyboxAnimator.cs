using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Animates the skybox by rotating it.
public class SkyboxAnimator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1.5f;

    void Update()
    {
        //Updates the skybox rotation based on the elapsed time.
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }

    void OnApplicationQuit()
    {
        //Resets the skybox rotation when the game is closed.
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }
}