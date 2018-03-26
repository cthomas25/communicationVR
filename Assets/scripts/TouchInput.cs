using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchPointListElement
{
    public Vector3 point;
    public Vector3 hitPoint;
    public int fingerId;

}

public class touchPerRecipient
{
    public GameObject recipient;
    public int touchCount;
    public List<touchPointListElement> touchList;
    public Vector3 triangleCenter;
}

public class TouchInput : MonoBehaviour {

    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private List<touchPerRecipient> touchPerRecList = new List<touchPerRecipient>();
    private GameObject[] touchesOld;
    private RaycastHit hit;

    private bool containsRecipient;
    private bool containsFingerId;
    private touchPerRecipient touchRecipient;
    private touchPointListElement touchPointListItem;

    void Update () {
        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();
            touchPerRecList.Clear();
            
            foreach (Touch touch in Input.touches)
            {
                //Debug.Log(touch.fingerId);
                //Debug.Log(touch.position);
                //Debug.Log("raw");
                //Debug.Log(touch.rawPosition);
                //Debug.Log(Input.mousePosition);
                
                containsRecipient = false;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);
                    foreach (touchPerRecipient t in touchPerRecList)
                    {
                        //Debug.Log("Entered here!1");
                        if (t.recipient == recipient)
                        {
                            //Debug.Log("Entered here!2");
                            containsFingerId = false;
                            foreach (touchPointListElement i in t.touchList)
                            {
                                //Debug.Log(i.fingerId);
                                //Debug.Log(touch.fingerId);
                                if (i.fingerId == touch.fingerId)
                                {
                                    containsFingerId = true;
                                }
                             }
                            
                            if (containsFingerId == false)
                            {
                                //Debug.Log("Entered here!3 - listing touches before insert");
                                touchPointListItem = new touchPointListElement();
                                touchPointListItem.point = touch.position;
                               // touchPointListItem.point = hit.point;
                                touchPointListItem.hitPoint = hit.point;
                                touchPointListItem.fingerId = touch.fingerId;
                                t.recipient = recipient;
                                t.touchList.Add(touchPointListItem);
                                t.touchCount++;
                                containsRecipient = true;
                                touchRecipient = t;
                                if (t.touchCount == 3)
                                {
                                    t.triangleCenter = findTriangleCenter(t.touchList[0].hitPoint, t.touchList[1].hitPoint, t.touchList[2].hitPoint);
                                }
                            }
                        }
                    }
                    //Debug.Log("Entered here!4");
                    if (containsRecipient == false)
                    {
                        touchRecipient = new touchPerRecipient();
                        touchPointListItem = new touchPointListElement();
                        touchRecipient.touchList = new List<touchPointListElement>();
                        touchRecipient.recipient = recipient;
                        touchRecipient.touchCount = 1;
                        touchPointListItem.point = touch.position;
                        //touchPointListItem.point = hit.point;
                        touchPointListItem.hitPoint = hit.point;
                        touchPointListItem.fingerId = touch.fingerId;
                        touchRecipient.recipient = recipient;
                        touchRecipient.touchList.Add(touchPointListItem);
                        touchPerRecList.Add(touchRecipient);
                    }
                    if (touch.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("OnTouchDown", touchRecipient, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchUp", touchRecipient, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("OnTouchStay", touchRecipient, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("OnTouchExit", touchRecipient, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
	}

    private Vector3 findTriangleCenter(Vector3 vertice1, Vector3 vertice2, Vector3 vertice3)
    {
        Vector3 center = new Vector3(0.0f, 0.0f, 0.0f);
        try
        {
            center.x = (vertice1.x + vertice2.x + vertice3.x) / 3;
            center.y = (vertice1.y + vertice2.y + vertice3.y) / 3;
            //center.z = (vertice1.z + vertice2.z + vertice3.z) / 3;
        } catch { Debug.Log("TouchInput::Failed to calculate triangle center."); }
        return center;
    }
}
