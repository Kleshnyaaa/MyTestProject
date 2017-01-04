using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTests
{
    delegate void MyEventHandler(string str);

    delegate void SendNewsHandler();


    class EventGeneratedClass
    {
        public event MyEventHandler MyEvent;

        public void DoSomething()
        {
            if (MyEvent != null) MyEvent.Invoke("Hello");
        }
    }

    class NotificationSender
    {
        public event SendNewsHandler OnSendNews;
        public event MyEventHandler OnSendByAddress;

        public void SendNews()
        {
            Console.WriteLine("I have some importante news and want to tell about them!");
            if (OnSendNews != null)
                OnSendNews();
            if (OnSendByAddress != null)
                OnSendByAddress("noname@mail.ru");
        }
    }

    class Recipient
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Recipient(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void SendNews()
        {
            Console.WriteLine("{0} is get a news on address {1}", Name, Email);
        }

        public void SendNewsToSpecificRecipient(string recipient)
        {
            Console.WriteLine("Message is sent to the {0} from class of {1}", recipient, Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //EventGeneratedClass myClass = new EventGeneratedClass();
            //myClass.MyEvent += (string s) => Console.WriteLine("Method via lambds");
            //myClass.DoSomething();

            NotificationSender newsGenerator = new NotificationSender();
            Recipient vasya = new Recipient("Vasya", "vasya@gmail.com");
            Recipient kolya = new Recipient("Kolya", "kolya@gmail.com");
            Recipient mashka = new Recipient("Mashka", "mashka@gmail.com");

            newsGenerator.OnSendNews += vasya.SendNews;
            newsGenerator.OnSendNews += kolya.SendNews;

            newsGenerator.OnSendByAddress += mashka.SendNewsToSpecificRecipient;
            newsGenerator.OnSendByAddress += vasya.SendNewsToSpecificRecipient;

            newsGenerator.SendNews();

            Console.ReadLine();
        }
    }
}
