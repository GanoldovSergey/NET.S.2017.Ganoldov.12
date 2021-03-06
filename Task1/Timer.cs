﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Class contains an information that sends to recipients of the event notification.
    /// </summary>
    public sealed class NewTimerEventArgs : EventArgs
    {
        /// <summary>
        /// Some words about reason of setting timer.
        /// </summary>
        public string Notification { get; set}

        /// <summary>
        /// Information about the time of setting a timer.
        /// </summary>
        public DateTime TimeNow { get; set; }

        public NewTimerEventArgs(string notification)
        {
            Notification = notification;
            TimeNow = DateTime.Now;
        }

    }

    /// <summary>
    /// Class that models some kind of timer.
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Event for triggered timer.
        /// </summary>
        public event EventHandler<NewTimerEventArgs> NewTimer = delegate { };

        protected virtual void OnNewTimer(NewTimerEventArgs e)
        {
            EventHandler<NewTimerEventArgs> temp = NewTimer;

            temp?.Invoke(this, e);
        }

        /// <summary>
        /// Method that simulates setting of timer.
        /// </summary>
        /// <param name="time">Quantity of seconds.</param>
        /// <param name="notification">Some note about current timer.</param>
        public void SimulateNewTimer(int time, string notification)
        {
            time *= 1000;
            Thread.Sleep(time);
            OnNewTimer(new NewTimerEventArgs(notification));
        }
    }

    /// <summary>
    /// This class simulates a mobile phone.
    /// </summary>
    public sealed class MobilePhone
    {
        /// <summary>
        /// Method to subscribe to the event of the current timer.
        /// </summary>
        /// <param name="timer">Timer to subscribe to it's event.</param>
        public void Register(Timer timer)
        {
            timer.NewTimer += MobilePhoneMsg;
        }

        private void MobilePhoneMsg(object sender, NewTimerEventArgs eventArgs)
        {
            Console.WriteLine("Task for timer complited om mobile phone:");
            Console.WriteLine($"Task for timer complited:{Environment.NewLine}" +
                              $"Was set on: {eventArgs.TimeNow}," +
                              $" Notification: {eventArgs.Notification}");
        }

        /// <summary>
        /// Method to subscribe from the event of the current timer.
        /// </summary>
        /// <param name="timer"></param>
        public void Unregister(Timer timer)
        {
            timer.NewTimer -= MobilePhoneMsg;
        }
    }

    /// <summary>
    /// This class simulates a pager.
    /// </summary>
    public sealed class Pager
    {
        /// <summary>
        /// Method to subscribe to the event of the current timer.
        /// </summary>
        /// /// <param name="timer">Timer to subscribe to it's event.</param>
        public void Register(Timer timer)
        {
            timer.NewTimer += PagerMsg;
        }

        private void PagerMsg(object sender, NewTimerEventArgs eventArgs)
        {
            Console.WriteLine("Task for timer complited on pager:");
            Console.WriteLine($"Task for timer complited:{Environment.NewLine}" +
                              $"Was set on: {eventArgs.TimeNow}," +
                              $" Notification: {eventArgs.Notification}");
        }

        /// <summary>
        /// Method to subscribe from the event of the current timer.
        /// </summary>
        /// <param name="timer"></param>
        public void Unregister(Timer timer)
        {
            timer.NewTimer -= PagerMsg;
        }
    }
}
