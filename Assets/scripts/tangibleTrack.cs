using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tangibleTrack : MonoBehaviour
{
    public int tangibleId;

    private knobPatternId kPatternId;
    private int tokenId;
    private float baseAngle = 0.0f;
    private Vector3 point;

    void Start()
    {
        kPatternId = new knobPatternId();
    }

    void OnTouchDown(touchPerRecipient touchValues)
    {
            tokenId = 0;
        if (touchValues.touchCount >= 3)
        {
            tokenId = checkTokenPlaced(touchValues);
            point = touchValues.touchList[0].point;
            if (tokenId == tangibleId)
            {
                MyOnMouseDown();
            }
        }

    }

    void OnTouchUp()
    {
        //Debug.Log("tangibleTrack:OnTouchUp");
    }

    void OnTouchStay(touchPerRecipient touchValues)
    {
        if (tokenId == tangibleId)
        {
            point = touchValues.touchList[0].point;
            MyOnMouseDrag();
        }
    }

    void OnTouchExit()
    {
        //Debug.Log("tangibleTrack:OnTouchExit");

    }

    private int checkTokenPlaced(touchPerRecipient touchValues)
    {
       //Debug.Log("tangibleTrack:checkTokenPlaced");
       return kPatternId.findTokenId(
            touchValues.touchList[0].point,
            touchValues.touchList[0].fingerId,
            touchValues.touchList[1].point,
            touchValues.touchList[1].fingerId,
            touchValues.touchList[2].point,
            touchValues.touchList[2].fingerId);
    }

    void MyOnMouseDown()
    {
            Vector3 pos = point;
            baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
            baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
    }

    void MyOnMouseDrag()
    {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            pos = point - pos;
            float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
            transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
        Globals.OscAngle = (float)transform.rotation.eulerAngles.z;
    }
}