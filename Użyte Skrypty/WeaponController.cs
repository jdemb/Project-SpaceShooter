using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    private AudioSource audioSource;
    public GameObject shot;
    public Transform shotSpawn;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public Transform shotSpawn4;
    public Transform shotSpawn5;
    public Transform shotSpawn6;
    public float fireRate;
    public float delay;
    

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
	}
	
	
	void Fire () {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        if(shotSpawn2 != null)
            Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
        if (shotSpawn3 != null)
            Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
        if (shotSpawn4 != null)
            Instantiate(shot, shotSpawn4.position, shotSpawn4.rotation);
        if (shotSpawn5 != null)
            Instantiate(shot, shotSpawn5.position, shotSpawn5.rotation);
        if (shotSpawn6 != null)
            Instantiate(shot, shotSpawn6.position, shotSpawn6.rotation);
        audioSource.Play();
	}
}
