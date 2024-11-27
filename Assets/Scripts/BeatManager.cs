using System;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private AudioSource song;
    [SerializeField] private float bpm;
    [SerializeField] private Intervals[] intervals;

    private void Update()
    {
        foreach (Intervals interval in intervals)
        {
            float sampledTime = song.timeSamples / (song.clip.frequency * interval.GetIntervalLength(bpm));
            interval.CheckForNewInterval(sampledTime);
        }
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float steps;
    [SerializeField] private UnityEvent trigger;
    private int lastInterval = -1;

    public float GetIntervalLength(float bpm)
    {
        return 60f / bpm * steps;
    }

    public void CheckForNewInterval(float interval)
    {
        if (Mathf.FloorToInt(interval) != lastInterval)
        {
            lastInterval = Mathf.FloorToInt(interval);
            trigger.Invoke();
        }
    }
}
