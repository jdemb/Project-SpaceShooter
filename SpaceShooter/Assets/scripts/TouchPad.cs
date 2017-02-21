using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

    private Vector2 origin;
    private Vector2 direction;
    public float smoothing;
    private Vector2 smoothDirection;
    private bool touched;
    private int pointerID;

    void Awake ()
    {
        direction = Vector2.zero;
        touched = false;
    }

    public void OnPointerDown(PointerEventData data)
    {
        //set our start point
        if (!touched)
        {
            touched = true;
            pointerID = data.pointerId;
            origin = data.position;
        }
    }
    public void OnDrag (PointerEventData data)
    {
        //compare the diffrence between our start and current pointer pos
        if (data.pointerId == pointerID)
        {
            Vector2 currentPosition = data.position;
            Vector2 directionRaw = currentPosition - origin;
            direction = directionRaw.normalized;
            Debug.Log(direction);
        }
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (data.pointerId == pointerID)
        {
            direction = Vector2.zero;
            touched = false;
        }
    }
	
    public Vector2 GetDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection,direction,smoothing);
        return smoothDirection;
    }

}
