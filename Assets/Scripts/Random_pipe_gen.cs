using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_pipe_gen : MonoBehaviour
{
    public GameObject dbl_pipes;
    private float camDimY = 10f;
    private void Start() {
        // find a random Vector3 for dbl_pipes for the game to be random.

        GameObject pipes = Instantiate(dbl_pipes, new Vector3(transform.position.x + Random.Range(-9f,-2f), transform.position.y + Random.Range(-3f, 3f), transform.position.z), transform.rotation, transform);
        pipes.transform.localScale = new Vector3(0.4f, 1f, 1f);
        pipes = Instantiate(dbl_pipes, new Vector3(transform.position.x + Random.Range(2f, 9f), transform.position.y + Random.Range(-3f, 3f), transform.position.z), transform.rotation, transform);
        pipes.transform.localScale = new Vector3(0.4f, 1f, 1f);
    }
}
