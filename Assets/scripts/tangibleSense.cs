using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tangibleSense : MonoBehaviour
{
    public GameObject tangible1;
    public int id1;
    public GameObject tangible2;
    public int id2;
    public GameObject tangible3;
    public int id3;

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
            if (tokenId == id1)
            {
                Debug.Log("id1");
                Debug.Log(touchValues.triangleCenter);
                tangible1.transform.position = touchValues.triangleCenter;
            }
            else if (tokenId == id2)
            {
                Debug.Log("id2");
                Debug.Log(touchValues.triangleCenter);
                tangible2.transform.position = touchValues.triangleCenter;
            }
        }
    }

    void OnTouchUp()
    {
        //Debug.Log("tangibleTrack:OnTouchUp");
    }

    void OnTouchStay(touchPerRecipient touchValues)
    {
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
             touchValues.touchList[2].fingerId); // needs to be adjusted....
    }
}