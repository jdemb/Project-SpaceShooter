using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public float tumble;
    

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * tumble);
    }
}
