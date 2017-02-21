using UnityEngine;
using System.Collections;

public class RocketSpam : MonoBehaviour {

    public Transform shotSpawn;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public Transform shotSpawn4;
    public Transform shotSpawn5;
    
    public GameObject rocket;
    // Use this for initialization
    void Start () {
        InvokeRepeating("RocketSpamFunction", 1, 1);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void RocketSpamFunction()
    {
        Instantiate(rocket, shotSpawn.position, shotSpawn.rotation);

        Instantiate(rocket, shotSpawn2.position, shotSpawn2.rotation);

        Instantiate(rocket, shotSpawn3.position, shotSpawn3.rotation);

        Instantiate(rocket, shotSpawn4.position, shotSpawn4.rotation);

        Instantiate(rocket, shotSpawn5.position, shotSpawn5.rotation);
    }
}
