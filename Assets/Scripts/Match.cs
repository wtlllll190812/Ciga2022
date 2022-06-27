using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class Match : MonoBehaviour
{
    public UnityEvent OnMatch;

    public void Start()
    {
        StartCoroutine(MatchPass());
    }

    public virtual IEnumerator MatchPass()
    {
        yield return null;
    }
}
