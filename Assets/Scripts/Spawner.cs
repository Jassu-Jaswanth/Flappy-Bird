using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnee;
    public GameObject initspawnee;
    private float spawnInterval;
    public int difficult;
    private bool stopSpawn;

    private void Start() {
        spawnInterval = GameObject.FindWithTag("Background").GetComponent<SelfDistruct>().outOfFocus;
    }

    private void SpawnBG() {
        Instantiate(spawnee, transform.position, transform.rotation,transform);
    }

    public void setSpawn(bool b) {
        stopSpawn = !b;
    }

    public void resetSpawn() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        GameObject.Instantiate(initspawnee, new Vector3(0f, 0f, 0f), transform.rotation, transform);
        stopSpawn = false;
        InvokeRepeating(nameof(SpawnBG), 0, spawnInterval);
    }

    public void stopSpawner() {
        Debug.Log("stopping spawner");
        CancelInvoke(nameof(SpawnBG));
        foreach (Transform child in transform) {
            child.gameObject.GetComponent<MoveBG>().speed = 0;
            child.gameObject.GetComponent<SelfDistruct>().setDestroy(false);
        }
    }

    public void startSpawner() {

        Debug.Log("starting spawner");
        GameObject.Instantiate(initspawnee, new Vector3(0f, 0f, 0f), transform.rotation, transform);
        InvokeRepeating(nameof(SpawnBG), 0, spawnInterval);
    }
}
