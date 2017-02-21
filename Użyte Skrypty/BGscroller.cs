using UnityEngine;
using System.Collections;

public class BGscroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizez;

    private Vector3 startposition;
	// Use this for initialization
	void Start () {
        startposition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time*scrollSpeed,tileSizez);
        transform.position = startposition + Vector3.forward * newPosition;
	}
}
