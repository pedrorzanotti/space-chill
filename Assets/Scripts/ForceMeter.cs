using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Updates the HUD slider according to the ball's throwing force.
public class ForceMeter : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = FindObjectOfType<Player>().GetThrowingForce();
    }
}