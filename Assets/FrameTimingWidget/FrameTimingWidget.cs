using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;

namespace Ica.Utils.Profiling
{
    //Originally From
    //https://blog.unity.com/engine-platform/detecting-performance-bottlenecks-with-unity-frame-timing-manager
    public class FrameTimingWidget : MonoBehaviour
    {
        public TextMeshProUGUI TMPText;
        readonly FrameTiming[] _frameTimings = new FrameTiming[1];
        private StringBuilder _sb;
        public double FrameBudgetMS = 16.6666;
        public ulong FrameBudgetExceedCount;

        void Awake()
        {
            //TMPText = GetComponent<TextMeshProUGUI>();
            _sb = new StringBuilder(100);
        }

        private void LateUpdate()
        {
            CaptureTimings();

            _sb.Clear();
            _sb.AppendFormat("CPU: {0:F2}", _frameTimings[0].cpuFrameTime);
            _sb.AppendFormat("\nMain Thread: {0:F2}", _frameTimings[0].cpuMainThreadFrameTime);
            _sb.AppendFormat("\nRender Thread: {0:F2}", _frameTimings[0].cpuRenderThreadFrameTime);
            _sb.AppendFormat("\nGPU: {0:F2}", _frameTimings[0].gpuFrameTime);


            TMPText.SetText(_sb);


            if (_frameTimings[0].cpuFrameTime > FrameBudgetMS)
            {
                FrameBudgetExceedCount++;
            }
        }

        private void CaptureTimings()
        {
            FrameTimingManager.CaptureFrameTimings();
            FrameTimingManager.GetLatestTimings((uint)_frameTimings.Length, _frameTimings);
        }
    }
}