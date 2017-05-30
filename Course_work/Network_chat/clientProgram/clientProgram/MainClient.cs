using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace WindowsFormsApplication2
{

    public partial class MainClient : Form
    {

        private delegate void printer(string data);
        private delegate void cleaner();
        printer Printer;
        cleaner Cleaner;
        private Socket _serverSocket;
        private Thread _clientThread;
        private const string _serverHost = "localhost";
        private const int _serverPort = 8080;

        public MainClient()
        {
            InitializeComponent();
            Printer = new printer(print);
            Cleaner = new cleaner(clearChat);
            connect();
            _clientThread = new Thread(listner);
            _clientThread.IsBackground = true;
            _clientThread.Start();
        }

        private void listner()
        {
            while(_serverSocket.Connected)
            {
                byte[] buffer = new byte[1024];
                int bytesRec = _serverSocket.Receive(buffer);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                if (data.Contains("#updatechat"))
                {
                    UpdateChat(data);
                    continue;
                }

            }
        }

        private void connect()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);
                IPAddress ipAddress = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);
                _serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Connect(ipEndPoint);
            }
            catch { print("Сервер недоступен!"); }
        }

        private void clearChat()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Cleaner);
                return;
            }
            chatBox.Clear();
        }

        private void UpdateChat(string data)
        {
            //#updatechat&userName~data|username~data
            clearChat();
            string[] messages = data.Split('&')[1].Split('|');
            
            File.WriteAllBytes("newfile.txt", Encoding.Default.GetBytes(data.Split('&')[1]));
            int countMessages = messages.Length;
            if (countMessages <= 0) return;
            for(int i=0; i<countMessages; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(messages[i])) continue;
                    print(String.Format("{0}: {1}.", messages[i].Split('~')[0], messages[i].Split('~')[1]));
                }
                catch { continue; }
            }
        }

        private void send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int bytesSent = _serverSocket.Send(buffer);

            }
            catch { print("Связь с сервером прервалась..."); }

        }

        private void print(string msg)
        {
           
            if (this.InvokeRequired)
            {
                this.Invoke(Printer, msg);
                return;
            }
            if (chatBox.Text.Length == 0)
                chatBox.AppendText(msg);
            else
                chatBox.AppendText(Environment.NewLine + msg);
        }
        private void enter_chat()
        {
            string Name = userName.Text;
            if (string.IsNullOrEmpty(Name)) return;
            send("#setname&" + Name);
            chatBox.Enabled = true;
            chat_msg.Enabled = true;
            chat_send.Enabled = true;
            userName.Enabled = false;
            enter.Enabled = false;
        }
        private void enterChat_Click(object sender, EventArgs e)
        {
            enter_chat();   
        }

        private void chat_send_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void sendMessage()
        {
            try
            {
                string data = chat_msg.Text;
                if (string.IsNullOrEmpty(data)) return;
                send("#newmsg&" + data);
                chat_msg.Text = string.Empty;
            }
            catch { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }
        private void send_File(string path)
        {
            try
            {

                string data = chat_msg.Text;
                if (string.IsNullOrEmpty(data)) return;
                _serverSocket.SendFile(path);
                chat_msg.Text = string.Empty;
            }
            catch { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }

        private void chatBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }

        private void chat_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            { return; }
            byte[] type = Encoding.Default.GetBytes("|" + openFileDialog1.SafeFileName);

            byte[] tmp = File.ReadAllBytes(openFileDialog1.FileName);

            byte[] tag = Encoding.Default.GetBytes("#file&");

            byte[] sent_file = new byte[tmp.Length + tag.Length  + type.Length];

            int ind = 0; 
            for(int i = 0;i< tag.Length; i++)
            {
                sent_file[i] = tag[i];
                ind++;
            }
            int p1 = 0;
            for(int i = 0; i < tmp.Length; i++)
            {
                sent_file[i + ind] = tmp[i];
            }
            ind += p1;
            for(int i = 0;i< type.Length; i++)
            {
                sent_file[ind + i] = type[i];
            }

           
            _serverSocket.Send(sent_file); 
        }
    }
}
