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
    public abstract class Notification { }

    /*public class TheClass : ISubscriber<ConcreteNotification1>, ISubscriber<ConcreteNotification2>
    {
        public void Handle(ConcreteNotification2 Notification)
        {
            throw new NotImplementedException();
        }
    {
        public void Handle(ConcreteNotification1 Notification)
        {
            throw new NotImplementedException();
        }
    }
    
    public class TheClass2 : ISubscriber<NotificationWithPayload<Not2>>, ISubscriber<NotificationWithPayload<Not1>>
    {
        public void Handle(NotificationWithPayload<Not1> Notification)
        {
            throw new NotImplementedException();
        }
    {
        public void Handle(NotificationWithPayload<Not2> Notification)
        {
            throw new NotImplementedException();
        }
    }

    public class ConcreteNotification1 { }
    public class ConcreteNotification2 { }

    public class Not1 { }
    public class Not2 { }
*/
    public abstract class NotificationWithPayload<T> : Notification
    {
        public T Data { get; set; }
        public NotificationWithPayload(T data)
        {
            Data = data;
        }
    }

    public class AddUserProfileNotification : Notification { }

    public class EditUserProfileNotification : NotificationWithPayload<TreeNode>
    {
        public EditUserProfileNotification(TreeNode data) : base(data) { }
    }

    public class CategorySelectedNotification : NotificationWithPayload<TreeNode>
    {
        public CategorySelectedNotification(TreeNode data) : base( data) { }
    }

    public class UserProfileSelectedNotification : NotificationWithPayload<Person>
    {
        public UserProfileSelectedNotification(Person data) : base(data) { }
    }

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

            Kartoteka form1 = new Kartoteka();
            Application.Run(form1);
        }
    }
}