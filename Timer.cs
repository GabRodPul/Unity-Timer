using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP.Unity
{
    public class Timer : MonoBehaviour
    {
        public enum Count { Down = -1, Up = 1 }

        public Count CountMode = Count.Up;
        [SerializeField, Min(0)] float _startSecs = 0f;
        public bool PlayOnStart    = true;
        public bool PauseOnDisable = false;
        public bool ResumeOnEnable = false;

        [HideInInspector] public float Secs      { get; private set; } = 0f;
        [HideInInspector] public bool  IsRunning { get; private set; } 

        void Start()
        {
            Secs      = _startSecs;
            IsRunning = PlayOnStart;
        }

        void Update()
        {
            if (IsRunning) 
                Secs += Time.deltaTime * (float)CountMode;
        }

        public void Resume() => IsRunning = true;
        public void Pause()  => IsRunning = false;
        void OnDisable() => IsRunning = !PauseOnDisable || IsRunning;
        void OnEnable()  => IsRunning =  ResumeOnEnable || IsRunning;

        public void ResetToZero()  => Secs = 0;
        public void ResetToStart() => Secs = _startSecs;

        public string FmtMinutes()
            => $"{Mathf.FloorToInt(Secs / 60):00}:{Mathf.FloorToInt(Secs % 60):00}";
    }
}
