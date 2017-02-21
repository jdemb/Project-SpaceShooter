using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary2
{
    public float xMin, xMax, zMin, zMax;
}

public class DragMe : MonoBehaviour {

    public Vector3 position;
	private TextMesh textMesh;
	private Vector3 deltaPosition;
	private int fingerIndex;
    public Vector3 touchpos;
    private bool fire;
    public Boundary2 boundary;

	// Subscribe to events
	void OnEnable(){
		EasyTouch.On_Drag += On_Drag;
		EasyTouch.On_DragStart += On_DragStart;
		EasyTouch.On_DragEnd += On_DragEnd;
	}

	void OnDisable(){
		UnsubscribeEvent();
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}
	
	void UnsubscribeEvent(){
		EasyTouch.On_Drag -= On_Drag;
		EasyTouch.On_DragStart -= On_DragStart;
		EasyTouch.On_DragEnd -= On_DragEnd;
	}	
	
	
	void Start(){
		textMesh =(TextMesh) GetComponentInChildren<TextMesh>();
        fire = false;
	}
	
	// At the drag beginning 
	void On_DragStart( Gesture gesture){
		
		// Verification that the action on the object
		if (gesture.pickedObject == gameObject){
			fingerIndex = gesture.fingerIndex;

            fire = true;
			// the world coordinate from touch
			position = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
			deltaPosition = position - transform.position;

		}	
	}
	
	// During the drag
	void On_Drag(Gesture gesture){
	
		// Verification that the action on the object
		if (gesture.pickedObject == gameObject && fingerIndex == gesture.fingerIndex){

			// the world coordinate from touch
			Vector3 position = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
			transform.position = position - deltaPosition + touchpos;
            transform.position = new Vector3
             (
                 Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
                 0.0f,
                 Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
              );

            // Get the drag angle
            float angle = gesture.GetSwipeOrDragAngle();
			
		}
	}
	
	// At the drag end
	void On_DragEnd(Gesture gesture){
        fire = false; 
	}

	public bool checkFire()
    {
        return fire;
    }

    public Vector3 getPosition()
    {
        return position;
    }
}
