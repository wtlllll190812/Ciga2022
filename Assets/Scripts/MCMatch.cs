using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MCMatch : Match
{
    public RectTransform rtr1;
    public RectTransform rtr2;
    public RectTransform target1;
    public RectTransform target2;
    public bool b1;
    public bool b2;
    public float minDis;

    public override IEnumerator MatchPass()
    {
        while(!(b1&&b2))
        {
            float dis1 = Mathf.Min(Vector3.Distance(rtr1.position,target2.position),Vector3.Distance(rtr1.position,target1.position));
            float dis2 = Mathf.Min(Vector3.Distance(rtr2.position,target2.position),Vector3.Distance(rtr2.position,target1.position));
            b1 = Mathf.Abs(dis1) < minDis;
            b2 = Mathf.Abs(dis2) < minDis;
            Debug.Log(dis1);
            Debug.Log(dis2);
            yield return null;
        }
        OnMatch?.Invoke();
        yield return null;
    }
}
