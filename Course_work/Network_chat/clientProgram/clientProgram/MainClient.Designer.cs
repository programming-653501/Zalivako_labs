namespace WindowsFormsApplication2
{
    partial class MainClient
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.enter = new System.Windows.Forms.Button();
            this.gui_userName = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.chat_send = new System.Windows.Forms.Button();
            this.chat_msg = new System.Windows.Forms.TextBox();
            this.gui_chat = new System.Windows.Forms.Label();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enter
            // 
            this.enter.Location = new System.Drawing.Point(291, 16);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(142, 25);
            this.enter.TabIndex = 0;
            this.enter.Text = "Войти в чат";
            this.enter.UseVisualStyleBackColor = true;
            this.enter.Click += new System.EventHandler(this.enterChat_Click);
            this.enter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // gui_userName
            // 
            this.gui_userName.AutoSize = true;
            this.gui_userName.Location = new System.Drawing.Point(9, 17);
            this.gui_userName.Name = "gui_userName";
            this.gui_userName.Size = new System.Drawing.Size(134, 17);
            this.gui_userName.TabIndex = 1;
            this.gui_userName.Text = "Введите ваше имя:";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(151, 17);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(134, 22);
            this.userName.TabIndex = 2;
            // 
            // chat_send
            // 
            this.chat_send.Enabled = false;
            this.chat_send.Location = new System.Drawing.Point(520, 420);
            this.chat_send.Name = "chat_send";
            this.chat_send.Size = new System.Drawing.Size(142, 25);
            this.chat_send.TabIndex = 4;
            this.chat_send.Text = "Отправить";
            this.chat_send.UseVisualStyleBackColor = true;
            this.chat_send.Click += new System.EventHandler(this.chat_send_Click);
            // 
            // chat_msg
            // 
            this.chat_msg.Enabled = false;
            this.chat_msg.Location = new System.Drawing.Point(15, 420);
            this.chat_msg.Name = "chat_msg";
            this.chat_msg.Size = new System.Drawing.Size(499, 22);
            this.chat_msg.TabIndex = 5;
            this.chat_msg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chat_msg_KeyDown);
            // 
            // gui_chat
            // 
            this.gui_chat.AutoSize = true;
            this.gui_chat.Location = new System.Drawing.Point(12, 198);
            this.gui_chat.Name = "gui_chat";
            this.gui_chat.Size = new System.Drawing.Size(33, 17);
            this.gui_chat.TabIndex = 6;
            this.gui_chat.Text = "Чат";
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(12, 228);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(741, 186);
            this.chatBox.TabIndex = 7;
            this.chatBox.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(678, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "Файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 454);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.gui_chat);
            this.Controls.Add(this.chat_msg);
            this.Controls.Add(this.chat_send);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.gui_userName);
            this.Controls.Add(this.enter);
            this.Name = "Form1";
            this.Text = "Сетевой чат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enter;
        private System.Windows.Forms.Label gui_userName;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Button chat_send;
        private System.Windows.Forms.TextBox chat_msg;
        private System.Windows.Forms.Label gui_chat;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}

