using UnityEngine;
using System.Collections;

public class Rotator2 : MonoBehaviour {

    public float tumble;


    void Update()
    {
        transform.Rotate(0, Time.deltaTime * tumble, 0);
    }
}
