using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDistruct : MonoBehaviour
{
    private float time = 0f;
    public float outOfFocus;
    private float camDimX = 22f;
    private bool doDestroy = true;
    private void Start() {
        outOfFocus = camDimX / GetComponent<MoveBG>().speed;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(doDestroy && time > outOfFocus*2) {
            Destroy(this.gameObject);
        }
    }

    public void setDestroy(bool des) {
        doDestroy = des;
    }
}
