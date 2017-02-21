using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchMe : MonoBehaviour {

    private Vector3 deltaPosition;
    private Vector3 position;
    public Vector3 touchpos;
    public bool fire;
	// Subscribe to events
	void OnEnable(){
		EasyTouch.On_TouchStart += On_TouchStart;
		EasyTouch.On_TouchDown += On_TouchDown;
		EasyTouch.On_TouchUp += On_TouchUp;
	}

	void OnDisable(){
		UnsubscribeEvent();
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}
	
	void UnsubscribeEvent(){
		EasyTouch.On_TouchStart -= On_TouchStart;
		EasyTouch.On_TouchDown -= On_TouchDown;
		EasyTouch.On_TouchUp -= On_TouchUp;
	}
	
	void Start () {
        fire = false;
	}
	
	// At the touch beginning 
	private void On_TouchStart(Gesture gesture){
		if (gesture.pickedObject == gameObject){
            fire = true;
        }
	}
	
	// During the touch is down
	private void On_TouchDown(Gesture gesture){
		
		// Verification that the action on the object
		if (gesture.pickedObject == gameObject){
            position = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
            transform.position = position - deltaPosition + touchpos;
        }

	}
	
	// At the touch end
	private void On_TouchUp(Gesture gesture){
		
		// Verification that the action on the object
		if (gesture.pickedObject == gameObject){
            fire = false; 
			
		}
	}
    public Vector3 getPosition()
    {
        return position;
    }
    public bool fireCheck()
    {
        return fire;
    }

}
