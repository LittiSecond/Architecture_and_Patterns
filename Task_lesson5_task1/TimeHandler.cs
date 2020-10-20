using System;
using System.Windows.Forms;  // для таймера

namespace Task_lesson5_task1
{
    static class TimeHandler
    {

        private static Timer _timer = null;
        private static int _interval = 100;
        private static bool _enabled = false;

        /// <summary>
        /// на вход - текущее время, в милисекундах
        /// </summary>
        public static Action<int> Update = delegate { ;}; // вроде это null object паттерн?

        public static void Start()
        {
            if (_enabled) return;
            if (_timer == null)
            {
                _timer = new Timer();
                _timer.Interval = _interval;
                _timer.Tick += RunUpdate;
            }
            _timer.Start();
            _enabled = true;
        }

        public static void Stop()
        {
            if (!_enabled)
            {
                _timer.Stop();
                //_timer.Tick -= RunUpdate;
                _enabled = false;
            }
        }

        private static void RunUpdate(object sender, EventArgs e)
        {
            Update(0);
            Stop();
        }

    }
}
