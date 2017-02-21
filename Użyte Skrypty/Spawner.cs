using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject hazard;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int hazardCount;

    void Start () {
        StartCoroutine(SpawnWaves());
    }
	
	
	void Update () {
	
	}
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Instantiate(hazard, transform.position, transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
