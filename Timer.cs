using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    enum Count { Down = -1, Up = 1 }

    [SerializeField] Count _count = Count.Up;
    [SerializeField, Min(0)] float _startSecs = 0f;
    [SerializeField] bool _playOnStart = true;

    public float Secs      { get; private set; } = 0f;
    public bool  IsRunning { get; private set; } 

    void Start()
    {
        Secs      = _startSecs;
        IsRunning = _playOnStart;
    }

    void Update()
    {
        if (IsRunning) 
            Secs += Time.deltaTime * (float)_count;
    }

    public void Play() => IsRunning = true;
    public void Stop() => IsRunning = false;

    public string FmtMinutes()
        => $"{Mathf.FloorToInt(Secs / 60):00}:{Mathf.FloorToInt(Secs % 60):00}";
}
