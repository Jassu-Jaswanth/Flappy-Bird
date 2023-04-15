using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private AudioSource AudSrc;
    private GameObject player;
    private GameObject conductor;
    private GameObject canvas;

    private void Start() {
        AudSrc = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        player = GameObject.Find("player");
        conductor = GameObject.Find("Conductor");
        canvas = GameObject.Find("Canvas");
    }
    public void resetGame() {
        player.GetComponent<Player>().resetBird();
        conductor.GetComponent<Spawner>().resetSpawn();
        conductor.GetComponent<GameManager>().resetScore();

        Destroy(canvas.transform.GetChild(3).gameObject);
        Destroy(canvas.transform.GetChild(4).gameObject);
        Destroy(canvas.transform.GetChild(5).gameObject);
    }

    public void quitGame() {  
        Application.Quit();
    }

    public void startGame() {
        //manually start bird and spawner inside conductor.
        if(player != null) {
            player.GetComponent<Player>().resetBird();
        }
        if(conductor != null) {
            conductor.GetComponent<Spawner>().startSpawner();
        }
        Destroy(canvas.transform.GetChild(3).gameObject);
        //Destroy(this.gameObject);
    }

    public void buttonSound(AudioClip clip) {
        AudSrc.PlayOneShot(clip);
    }
}
