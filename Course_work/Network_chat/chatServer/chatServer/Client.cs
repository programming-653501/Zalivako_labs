using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Xml;
using System.IO;


namespace chatServer
{
    public class Client
    {
        private string _userName;
        private Socket _handler;
        private Thread _userThread;
        XmlDocument history = new XmlDocument();

        public Client(Socket socket)
        {
            _handler = socket;
            _userThread = new Thread(listner);
            _userThread.IsBackground = true;
            _userThread.Start();

        }


        public string UserName
        {
            get { return _userName; }
        }

        private void listner()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int byteRec = _handler.Receive(buffer);
                    string data = Encoding.UTF8.GetString(buffer, 0, byteRec);
                    handleCommand(data);
                }
                catch { Server.EndClient(this); return; }
            }
        }

        public void End()
        {
            try
            {
                _handler.Close();
                try
                {
                    _userThread.Abort();
                }
                catch { } //
            }
            catch (Exception exp) { Console.WriteLine("Error with end: {0}.", exp.Message); }
        }

        private void handleCommand(string data)
        {
            Console.WriteLine(data);
            if (data.Contains("#setname"))
            {
                _userName = data.Split('&')[1];
                UpdateChat();
                return; 
            }
            if (data.Contains("#newmsg"))
            {
                string message = data.Split('&')[1];
                ChatController.AddMessage(_userName,message+"|");
                history.Load("history.xml");
                XmlNode msg = history.CreateElement("msg");
                history.DocumentElement.AppendChild(msg);

                XmlAttribute attribute = history.CreateAttribute("id");
                attribute.Value = DateTime.Now.ToString();

                XmlNode name = history.CreateElement("name");
                XmlNode info = history.CreateElement("info");
                name.InnerText = _userName;

                msg.AppendChild(name);
                info.InnerText = message;
                msg.AppendChild(info);

                history.Save("history.xml");
                return;
            }

            if (data.Contains("#gethistory"))
            {
                UpdateChat();
                return;
            }
        }

        public void UpdateChat()
        {
            Send(ChatController.GetChat());
        }

        public void Send(string command)
        {
            try
            {
                int byteSent = _handler.Send(Encoding.UTF8.GetBytes(command));
                Console.WriteLine(command);
                if (byteSent > 0) Console.WriteLine("Success");
            }
            catch(Exception exp) { Console.WriteLine("Error with send command: {0}.", exp.Message); Server.EndClient(this); }
        }
    }
}
