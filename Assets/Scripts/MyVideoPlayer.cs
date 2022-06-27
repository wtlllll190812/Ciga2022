using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class MyVideoPlayer : MonoBehaviour
{
    private VideoPlayer player;
    public UnityEvent OnplayerStart;
    public UnityEvent OnplayerEnd;
    private SpriteRenderer rend;
    public int order;

    public void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        player = GetComponent<VideoPlayer>();

    }

    private void Start()
    {
        
        StartCoroutine(Check());
    }

    private IEnumerator Check()
    {
        while (!player.isPlaying) 
            yield return null;

        order = rend.sortingOrder;
        rend.sortingOrder = 1;
        OnplayerStart?.Invoke();

        while (player.isPlaying)
            yield return null;
        
        GetComponent<SpriteRenderer>().sortingOrder = order;
        OnplayerEnd?.Invoke();
    }

    public void StartPlaying()
    {
        player.Play();
        StartCoroutine(Check());
    }
}
