using System;
using Tutorials;
using UnityEngine;
using DarkLog;

namespace BalsaMMXDebug
{
    public class BalsaMMXDebugMain : MonoBehaviour
    {
        private ModLog log;
        private DebugTutorialWindow mainWindowFSM;
        private TutorialMMXPanel mainWindow;
        private int frameCountdown;
        private int updateCountdown;

        public void Start()
        {
            log = new ModLog("BalsaMMXDebug");
            log.Log("GameObject Start");
            GameEvents.Game.OnSessionStart.AddListener(DelayStart);
            DontDestroyOnLoad(this);
        }

        public void DelayStart(NetworkLogic.SessionMode mode)
        {
            log.Log("DelayStart countdown");
            frameCountdown = 250;
        }

        public void Update()
        {
            if (frameCountdown > 0)
            {
                frameCountdown--;
                if (frameCountdown == 0)
                {
                    log.Log("Tutorial window showing");
                    mainWindowFSM = new DebugTutorialWindow(log);
                    mainWindow = TutorialMMXPanel.Create(mainWindowFSM);
                    updateCountdown = 5;
                }
            }
            if (updateCountdown > 0)
            {
                updateCountdown--;
                if (updateCountdown == 0)
                {
                    updateCountdown = 5;
                    mainWindowFSM.UpdatePage();
                }
            }

        }
    }
}
