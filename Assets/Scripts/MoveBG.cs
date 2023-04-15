using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 direction;

    private void Update() {
        direction = Vector3.left * speed;
        transform.position += direction * Time.deltaTime;
    }
}
