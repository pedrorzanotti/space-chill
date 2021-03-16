using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages the game state, the UI elements and the player.
public class GameManager : MonoBehaviour
{
    GameState gameState;
    [SerializeField] GameObject titleScreenCanvas;
    [SerializeField] GameObject HUDCanvas;
    [SerializeField] GameObject player;

    //Dimensions of the area where the player can spawn.
    [SerializeField] float playableAreaWidth = 5f;
    [SerializeField] float playableAreaLength = 5f;

    void Awake()
    {
        gameState = GetComponent<GameState>();

        //Disables the HUD and the player controls on the title screen.
        HUDCanvas.SetActive(false);
        TogglePlayerControls(false);
    }

    void Update()
    {
        gameState.SetTime(Time.time - gameState.GetStartTime());
    }

    //Takes the player from the title screen into the game.
    public void StartGame()
    {
        titleScreenCanvas.SetActive(false);
        HUDCanvas.SetActive(true);
        FindObjectOfType<Camera>().transform.localPosition = Vector3.zero;
        StartCoroutine(StartChallenge(0f));
    }

    //Generates a new challenge after some time.
    public IEnumerator StartChallenge(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        //Clears the information from the previous challenge.
        gameState.SetThrows(0);
        gameState.SetStartTime(Time.time);
        gameState.SetTime(0);
        
        MovePlayerToRandomPosition();
        TogglePlayerControls(true);
    }

    //Enables or disables the player controls.
    public void TogglePlayerControls(bool enabled)
    {
        player.GetComponent<FirstPersonController>().enabled = enabled;
        player.GetComponent<Player>().enabled = enabled;
    }

    //Moves the player to a random position within the playable area.
    public void MovePlayerToRandomPosition()
    {
        float x = Random.Range(-playableAreaWidth, playableAreaWidth);
        float z = Random.Range(-playableAreaLength, playableAreaLength);
        player.transform.position = new Vector3(x, player.transform.position.y, z);
    }
}