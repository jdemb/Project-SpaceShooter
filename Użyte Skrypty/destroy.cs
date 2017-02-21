using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

	void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
