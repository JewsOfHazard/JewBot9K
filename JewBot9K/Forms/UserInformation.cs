using System;
using System.Drawing;
using System.Windows.Forms;

namespace JewBot9K
{
    public partial class UserInformation : Form
    {
        public UserInformation(string url, string username, double timeInChat, double messages)
        {
            InitializeComponent();

            try
            {
                setImage(url);

            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("The user had no icon.");
            }
            label1.Text = username;
            addInformationToTable(timeInChat, messages);

        }
        private void addInformationToTable(double startTime, double messages)
        {
            double timeInChat = (double.Parse(DateTime.Now.ToString("MMddHHmm")) - startTime);
            double messagesPerMinute;
            double messagesPerHour;

            messagesPerMinute = messages / timeInChat;
            messagesPerHour = messages / (timeInChat / 60);

            if (messagesPerHour == 1D / 0D || messagesPerMinute == 1D / 0D)
            {
                messagesPerMinute = messages;
                messagesPerHour = messages;
            }

            if (timeInChat <= 60)
            {
                label2.Text = "Time in chat: " + timeInChat + " minutes.";
                label3.Text = "Number of messages: " + messages;
                label4.Text = "Messages per minute: " + messagesPerMinute;
            }
            else if (timeInChat <= 120 && timeInChat > 60)
            {
                label2.Text = "Time in chat: " + timeInChat + " hour.";
                label3.Text = "Number of messages: " + messages;
                label4.Text = "Messages per hour: " + messagesPerHour;
            }
            else
            {
                label2.Text = "Time in chat: " + timeInChat+ " hours.";
                label3.Text = "Number of messages: " + messages;
                label4.Text = "Messages per hour: " + messagesPerHour;
            }


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void setImage(string url)
        {

            System.Net.WebRequest request = System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            Bitmap origional = new Bitmap(responseStream);
            pictureBox1.Image = new Bitmap(origional, new Size(origional.Width / 3, origional.Height / 3));

        }
    }
}
