using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    private PlayerController playerController;
    private class Boundary
    {
        public float xMin=-5f, xMax=5f, zMin=-4f, zMax=8f;
    }
    private Boundary boundary;

    void Start()
    {
        boundary = new Boundary();
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
        if (playerController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        
    }

    
	void Update ()
    {
        transform.position = new Vector3(playerController.rb.position.x, playerController.rb.position.y, playerController.rb.position.z);
        transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
             );
    }
}
