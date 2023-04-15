using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // All operations related to stopping game and all goes here

    Image ones,tens,huns;

    public Sprite[] numbers = new Sprite[10];
    public GameObject gameEnd;
    public GameObject restart;
    public GameObject quit;
    private int score = 0;
    private GameObject canvas;
    private GameObject conductor;
    private GameObject player;

    private void Start() {
        canvas = GameObject.FindWithTag("UI");
        player = GameObject.FindWithTag("Player");
    }

    public void gameOver() {
        Instantiate(gameEnd, canvas.transform);
        Instantiate(restart, canvas.transform);
        Instantiate(quit, canvas.transform);
        player.GetComponent<Player>().stopBird();
        this.gameObject.GetComponent<Spawner>().stopSpawner();
        //Time.timeScale = 0;
    }

    public void incScore() {
        score++;
        ones = canvas.transform.GetChild(0).gameObject.GetComponent<Image>();
        tens = canvas.transform.GetChild(1).gameObject.GetComponent<Image>();
        huns = canvas.transform.GetChild(2).gameObject.GetComponent<Image>();
        ones.sprite = numbers[score % 10];
        tens.sprite = numbers[(score / 10) % 10];
        huns.sprite = numbers[(score / 100) % 10];
    }

    public void resetScore() {
        ones = canvas.transform.GetChild(0).gameObject.GetComponent<Image>();
        tens = canvas.transform.GetChild(1).gameObject.GetComponent<Image>();
        huns = canvas.transform.GetChild(2).gameObject.GetComponent<Image>();
        ones.sprite = numbers[0];
        tens.sprite = numbers[0];
        huns.sprite = numbers[0];
    }
}
