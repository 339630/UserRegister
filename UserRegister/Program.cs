using System.Security.Cryptography;
using Uwr.OOP.BehavioralPatterns.EventAggregator;

namespace Uwr.OOP.BehavioralPatterns.EventAggregator
{
    public interface ISubscriber<T>
    {
        void Handle(T Notification);
    }
    public interface IEventAggregator
    {
        void AddSubscriber<T>(ISubscriber<T> Subscriber);
        void RemoveSubscriber<T>(ISubscriber<T> Subscriber);
        void Publish<T>(T Event);
    }

    public class EventAggregator : IEventAggregator
    {
        Dictionary<Type, List<object>> _subscribers = new Dictionary<Type, List<object>>();

        #region IEventAggregator Members 
        public void AddSubscriber<T>(ISubscriber<T> Subscriber)
        { 
            if (!_subscribers.ContainsKey(typeof(T))) 
                _subscribers.Add(typeof(T), new List<object>());
            _subscribers[typeof(T)].Add(Subscriber); 
        }
        public void RemoveSubscriber<T>(ISubscriber<T> Subscriber)
        {
            if (_subscribers.ContainsKey(typeof(T)))
                _subscribers[typeof(T)].Remove(Subscriber);
        }
        public void Publish<T>(T Event)
        { 
            if (_subscribers.ContainsKey(typeof(T)))
                foreach (ISubscriber<T> subscriber in _subscribers[typeof(T)].OfType<ISubscriber<T>>())
                    subscriber.Handle(Event);
        }
        #endregion
    }
}

namespace UserRegister
{
    using Notification = KeyValuePair<EventType, object?>;

    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person ()
        {
            Name = "";
            Surname = "";
            DateOfBirth = DateTime.Now;
        }

        public Person(string name, string surname, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }
    }

    public enum EventType
    {
        CategorySelectedNotification,
        UserProfileSelectedNotification,
        AddUserProfileNotification,
        EditUserProfileNotification
    }
    



    internal static class Program
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            EventAggregator eventAggregator = new EventAggregator();
            Form1 form1 = new Form1(eventAggregator);
            eventAggregator.AddSubscriber<Notification>(form1);
            Application.Run(form1);
        }
    }
}