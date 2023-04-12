using fabsi.Dotnet.Events;

var main = new Main();

main.MessageExample();

namespace fabsi.Dotnet.Events
{
    class Main
    {
        public void MessageExample()
        {
            var whatsAppServer = new WhatsAppServer();
            var sarah = new Smartphone("Sarah", whatsAppServer);
            sarah.AppÖffnen();
            var fabian = new Smartphone("Fabian", whatsAppServer);
            fabian.AppÖffnen();

            sarah.SendMessage(fabian, "Ich liebe dich!");
            fabian.SendMessage(sarah, "Ich dich auch! <3");
        }
    }

    class WhatsAppServer
    {
        public delegate void MessageReceiveEvent(Smartphone user, string text);
        public event MessageReceiveEvent? MessageReceive;

        public void PublishMessage(Smartphone from, Smartphone to, string text)
        {
            MessageReceive?.Invoke(from, text);
        }
    }

    class Smartphone
    {
        public string Name { get; }
        private readonly WhatsAppServer _messenger;
        public Smartphone(string name, WhatsAppServer messenger)
        {
            Name = name;
            _messenger = messenger;
        }

        public void AppÖffnen()
        {
            _messenger.MessageReceive += ReceiveMessage;
        }

        public void AppSchließen()
        {
            _messenger.MessageReceive -= ReceiveMessage;
        }

        public void ReceiveMessage(Smartphone from, string text)
        {
            if (from == this)
            {
                // own message
                return;
            }

            Console.WriteLine($"New Message from '{from.Name}' :: '{text}'");
        }

        public void SendMessage(Smartphone to, string text)
        {
            _messenger.PublishMessage(this, to, text);
        }
    }
}