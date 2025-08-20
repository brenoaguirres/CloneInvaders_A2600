using UnityEngine;
using System.Collections.Generic;

namespace AlienInvaders.Tools.LogManager
{
    public class LogManager : MonoBehaviour
    {
        #region CONSTANTS
        private readonly Color infoColor = Color.white;
        private readonly Color warningColor = Color.yellow;
        private readonly Color errorColor = Color.red;
        #endregion

        #region SINGLETON PATTERN
        public static LogManager Instance { get; private set; }
        #endregion

        #region FIELDS
        [Header("Settings")]
        [SerializeField] public bool debugMode = true;

        private List<LogEntry> logMessages = new List<LogEntry>();

        // message format
        private const float messageDuration = 1f;
        private const int maxMessages = 20;
        private const int fontSize = 18;
        #endregion

        #region SUBCLASSES
        private class LogEntry
        {
            public string Message;
            public float TimeToLive;
            public Color Color;

            public LogEntry(string message, float timeToLive, Color color)
            {
                Message = message;
                TimeToLive = timeToLive;
                Color = color;
            }
        }
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (debugMode)
            {
                logMessages.RemoveAll(entry => Time.time > entry.TimeToLive);
            }
        }

        private void OnGUI()
        {
            if (debugMode)
            {
                GUIStyle style = new GUIStyle
                {
                    normal = { textColor = infoColor },
                    fontSize = fontSize
                };

                float yOffset = 10f;
                foreach (var logEntry in logMessages)
                {
                    style.normal.textColor = logEntry.Color;
                    GUI.Label(new Rect(10, yOffset, 500, 20), logEntry.Message, style);
                    yOffset += 20f;
                }
            }
        }
        #endregion


        #region PUBLIC METHODS
        public void LogMessage(string message)
        {
            if (debugMode)
            {
                if (logMessages.Count >= maxMessages)
                {
                    logMessages.RemoveAt(0);
                }
                logMessages.Add(new LogEntry(message, Time.time + messageDuration, infoColor));
            }
        }
        public void LogWarning(string message)
        {
            if (debugMode)
            {
                if (logMessages.Count >= maxMessages)
                {
                    logMessages.RemoveAt(0);
                }
                logMessages.Add(new LogEntry(message, Time.time + messageDuration, warningColor));
            }
        }
        public void LogError(string message)
        {
            if (debugMode)
            {
                if (logMessages.Count >= maxMessages)
                {
                    logMessages.RemoveAt(0);
                }
                logMessages.Add(new LogEntry(message, Time.time + messageDuration, errorColor));
            }
        }
        #endregion
    }
}