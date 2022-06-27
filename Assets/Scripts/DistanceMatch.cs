using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DistanceMatch : Match
{
    public RectTransform start;
    public RectTransform end;
    public Scrollbar bar;
    public float minDis;

    public GameObject high;
    public GameObject low;
    public bool isHigh=false;

    public void SetHigh(bool h)
    {
        isHigh = h;
    }
    public override IEnumerator MatchPass()
    {
        while (bar.value<minDis)
        {
            float dis = Vector3.Distance(start.position, end.position);
            bar.value = 1-(dis-0.5f)/10;
            yield return null;
        }
        OnMatch?.Invoke();
        Success();
        yield return null;
    }

    public void Success()
    {
        if(isHigh)
        {
            low.SetActive(true);
            high.SetActive(true);
        }
        else
            low.SetActive(true);
    }
}
