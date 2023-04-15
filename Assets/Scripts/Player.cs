using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float g = -9.8f;
    public float strength = 5f;
    private Vector3 direction;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex = 0;
    private bool takeInput = false;

    //For Audio effects
    public AudioSource AudSrc;
    public AudioClip wings_swoosh;
    public AudioClip hitObstacle;
    public AudioClip scorePoint;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        direction.y = 0f;
        g = 0f;
    }

    private void Update() {
        if (takeInput) {
            if (Input.GetMouseButtonDown(0)) {
                direction = Vector3.up * strength;
                AudSrc.PlayOneShot(wings_swoosh);
            }

            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began) {
                    direction = Vector3.up * strength;
                    AudSrc.PlayOneShot(wings_swoosh);
                }
            }
        }

        direction.y += g * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Obstacle") {
            //Debug.Log("its an obstacle");
            AudSrc.PlayOneShot(hitObstacle);
            GameObject.FindWithTag("gameManager").GetComponent<GameManager>().gameOver();
        } else if(collision.gameObject.tag == "Scorebox") {
            //Debug.Log("u Scored a point");
            AudSrc.PlayOneShot(scorePoint);
            GameObject.FindWithTag("gameManager").GetComponent<GameManager>().incScore();
        }
    }

    private void AnimateBird() {
        spriteIndex++;
        if(spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    public void stopBird() {
        Debug.Log("stopping bird");
        CancelInvoke(nameof(AnimateBird));
        takeInput = false;
        direction.y = 0;
        g = 0;
    }

    public void resetBird() {
        Debug.Log("resetting bird");
        InvokeRepeating(nameof(AnimateBird), 0.1f, 0.1f);
        transform.position = new Vector3(0f, 0f, 0f);
        direction.y = 0;
        g = -9.8f;
        takeInput = true;
    }
}
