using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECS_PlayGround
{
    //Taken From
    //https://blog.unity.com/engine-platform/detecting-performance-bottlenecks-with-unity-frame-timing-manager
    public class FrameTimingsHUDDisplay : MonoBehaviour
    {
        GUIStyle m_Style;
        readonly FrameTiming[] m_FrameTimings = new FrameTiming[1];

        void Awake()
        {
            m_Style = new GUIStyle();
            m_Style.fontSize = 15;
            m_Style.normal.textColor = Color.white;
        }

        void OnGUI()
        {
            CaptureTimings();

            var reportMsg = 
                $"\nCPU: {m_FrameTimings[0].cpuFrameTime :00.00}" +
                $"\nMain Thread: {m_FrameTimings[0].cpuMainThreadFrameTime:00.00}" +
                $"\nRender Thread: {m_FrameTimings[0].cpuRenderThreadFrameTime:00.00}" +
                $"\nGPU: {m_FrameTimings[0].gpuFrameTime:00.00}";
            
            var oldColor = GUI.color;
            GUI.color = new Color(1, 1, 1, 1);
            float w = 300, h = 210;

            GUILayout.BeginArea(new Rect(32, 50, w, h), "Frame Stats", GUI.skin.window);
            GUILayout.Label(reportMsg, m_Style);
            GUILayout.EndArea();

            GUI.color = oldColor;
        }

        private void CaptureTimings()
        {
            FrameTimingManager.CaptureFrameTimings();
            FrameTimingManager.GetLatestTimings((uint)m_FrameTimings.Length, m_FrameTimings);
        }
    }
}
