using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointTuple
{
    public Vector3 p1;
    public Vector3 p2;
}

public class knobPatternId : MonoBehaviour {
    private pointTuple minSide;
    private Vector3 midPoint;
    private Vector3 topPoint;
    private int topPointUId;
    private float minLength;
    private float distMidTop;
    private bool DEBUG;

    public float token_angle;

    public int findTokenId(Vector3 pa, int paFid, Vector3 pb, int pbFid, Vector3 pc, int pcFid)
    {
        findMinLegth(pa, paFid, pb, pbFid, pc, pcFid);
        float angle = findAngle(minSide.p2, minSide.p1);
        token_angle = angle;
        //Debug.Log(token_angle);

        if (angle < 0){angle = angle + 360;}
        //Rotate to determine Id
        Vector3 nmin = rotate(minSide.p2, minSide.p1, (360 - angle) * Mathf.Deg2Rad);
        minSide.p1 = nmin; //minSide.p2 = minSide.p2;
        topPoint = rotate(minSide.p2, topPoint, (360 - angle) * Mathf.Deg2Rad);
        if (topPoint.y < nmin.y)
        {
            nmin = rotate(minSide.p2, minSide.p1, (180) * Mathf.Deg2Rad);
            minSide.p1 = nmin; //minSide.p2 = minSide.p2;
            topPoint = rotate(minSide.p2, topPoint, (180) * Mathf.Deg2Rad);
        }

        midPoint = findMidPoint(minSide.p1, minSide.p2);
        distMidTop = findLength(midPoint, topPoint);
        //Find length between midPoint and topPoint
        float idAngle = findAngle(midPoint, topPoint);
        int tokenId = findId(idAngle, distMidTop);
        return tokenId;
    }

    public float getTokenAngle()
    {
        return token_angle;
    }

    private void findMinLegth(Vector3 pa, int paFid, Vector3 pb, int pbFid, Vector3 pc, int pcFid)
    {
        // Finds the side of minium length given three points (triangle)
        //Debug.Log(pa);
        //Debug.Log(pb);
        //Debug.Log(pc);

        minSide = new pointTuple();

        float l1 = findLength(pa, pb);
        float l2 = findLength(pb, pc);
        float l3 = findLength(pc, pa);

        if (l1<l2 && l1<l3)
        {
            minSide.p1 = pa;
            minSide.p2 = pb;
            topPoint = pc;
            topPointUId = pcFid;
            minLength = l1;
        } else if(l2<l1 && l2<l3)
        {
            minSide.p1 = pb;
            minSide.p2 = pc;
            topPoint = pa;
            topPointUId = paFid;
            minLength = l2;
        } else 
        {
            minSide.p1 = pc;
            minSide.p2 = pa;
            topPoint = pb;
            topPointUId = pbFid;
            minLength = l3;
        }
    }

    private float findLength(Vector3 pi, Vector3 pj)
    {
        //finds distance between two points
        float x = Mathf.Abs(pi.x - pj.x);
        float y = Mathf.Abs(pi.y - pj.y);
        float length = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        //convert length from pixels to mm
        float length_mm = (length * 25.4f) / Screen.dpi;
        //Debug.Log(length);
        return length_mm;
    }

    private float findAngle(Vector3 p1, Vector3 p2)
    {
        //finds distance between two points
        float x = p2.x - p1.x;
        float y = p2.y - p1.y;
        return Mathf.Atan2(y, x) * Mathf.Rad2Deg;
    }

    private Vector3 rotate (Vector3 origin, Vector3 point, float angle)
    {
        //Rotates a point counterCloackwise by a given angle around a given origin. 
        //Angle shall be given in radians.
        Vector3 Result = new Vector3(0.0f, 0.0f, 0.0f);

        Result.x = origin.x + Mathf.Cos(angle) * (point.x - origin.x) - Mathf.Sin(angle) * (point.y - origin.y);
        Result.y = origin.y + Mathf.Sin(angle) * (point.x - origin.x) + Mathf.Cos(angle) * (point.y - origin.y);
        return Result;
    }

    private Vector3 findMidPoint(Vector3 pa, Vector3 pb)
    {
        //Finds the mid-point between two points
        Vector3 Result = new Vector3(0.0f, 0.0f, 0.0f);

        Result.x = (pa.x + pb.x) / 2;
        Result.y = (pa.y + pb.y) / 2;

        return Result;
    }

    private int findId(float idAngle, float distMidTop)
    {
        DEBUG = true;
        //Compares angles and distances to determine the id of a token
        // if a n id cannot be determined it returs zero
        if (DEBUG == true)
        {
            Debug.Log("idAngle:");
            Debug.Log(idAngle);
            Debug.Log("distMidTop:");
            Debug.Log(distMidTop);
            Debug.Log("-----------------------------------");
        }
        int tokenId = 0;
        if (idAngle <= 99 && idAngle >= 94)
        {
            if (distMidTop >= 0) { tokenId = 1; }
            if (DEBUG == true) { Debug.Log(tokenId); }
        }

        if (idAngle <= 86 && idAngle >= 82)
        {
            if (distMidTop >= 0) { tokenId = 2; }
            if (DEBUG == true) { Debug.Log(tokenId); }
        }

        if (idAngle <= 112 && idAngle >= 106)
        {
            if (distMidTop >= 0) { tokenId = 3; }
            if (DEBUG == true) { Debug.Log(tokenId); }
        }

        if (idAngle <= 76.71 && idAngle >= 62.92)
        {
            if (distMidTop >= 0) { tokenId = 4; }
            if (DEBUG == true) { Debug.Log(tokenId); }
        }

        if (idAngle <= 57.79 && idAngle >= 41.51)
        {
            if (distMidTop >= 0) { tokenId = 5; }
            if (DEBUG == true) { Debug.Log(tokenId); }
        }

        if (idAngle <= 124.82 && idAngle >= 107.14)
        {
            if (distMidTop >= 0) { tokenId = 6; }
            if (DEBUG == true) { Debug.Log(tokenId); }
        }

        if (idAngle <= 95.74 && idAngle >= 81.00)
        {
            if (distMidTop >= 0 ) { tokenId = 7; }
            if (DEBUG == true) { Debug.Log(tokenId); }
        }

        if (idAngle <= 73.6 && idAngle >= 55.02)
        {
            if (distMidTop >= 0) { tokenId = 8; }
            if (DEBUG == true) { Debug.Log(tokenId); }
        }
        Debug.Log(tokenId);
        Debug.Log("--------------");
        return tokenId;
    }

 
}
