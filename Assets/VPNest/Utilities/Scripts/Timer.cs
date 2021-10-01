using UnityEngine.Events;

namespace VP.Nest.Utilities
{
    public class Timer
    {
        private UnityAction OnTimeUp;

        private float maxTime;
        private float elapsedTime;

        public Timer(float time, UnityAction OnTimeUp)
        {
            maxTime = time;
            this.OnTimeUp += OnTimeUp;
        }

        public void ExecuteTime(float value)
        {
            elapsedTime += value;

            if (elapsedTime >= maxTime)
            {
                elapsedTime = 0f;

                OnTimeUp?.Invoke();
            }
        }
    }
}