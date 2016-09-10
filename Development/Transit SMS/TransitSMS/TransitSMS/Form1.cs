using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GsmComm.GsmCommunication;
using GsmComm.Interfaces;
using GsmComm.PduConverter;
using GsmComm.Server;
using System.IO;

namespace TransitSMS
{
    public partial class MainForm : Form
    {
        public Int16 Comm_Port = 0;
        public Int32 Comm_BaudRate = 0;
        public Int32 Comm_TimeOut = 0;

        public static GsmCommMain comm;

        Interpreter interpreter;

        public MainForm(Int16 Comm_Port, Int32 Comm_BaudRate, Int32 Comm_TimeOut)
        {
            InitializeComponent();

            InitializeValues(Comm_Port, Comm_BaudRate, Comm_TimeOut);

            CheckConnection();
        }

        private void InitializeValues(Int16 Comm_Port, Int32 Comm_BaudRate, Int32 Comm_TimeOut)
        {
            this.Comm_Port = Comm_Port;
            this.Comm_BaudRate = Comm_BaudRate;
            this.Comm_TimeOut = Comm_TimeOut;

            interpreter = new Interpreter();
        }

        private void CheckConnection()
        {
            comm = new GsmCommMain(Comm_Port, Comm_BaudRate, Comm_TimeOut);

            comm.Open();
            if (comm.IsConnected())
            {
                ConnectionStatusMenuItem.Text = "Connected";
            }
            else
            {
                ConnectionStatusMenuItem.Text = "Not Connected";
            }

            comm.MessageReceived += new MessageReceivedEventHandler(comm_MessageReceived);
            comm.EnableMessageNotifications();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void comm_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            IMessageIndicationObject obj = e.IndicationObject;
            MemoryLocation loc = (MemoryLocation)obj;
            DecodedShortMessage[] messages;
            messages = comm.ReadMessages(PhoneMessageStatus.ReceivedUnread, loc.Storage);

            foreach (DecodedShortMessage message in messages)
            {
                SmsDeliverPdu data = new SmsDeliverPdu();

                SmsPdu smsrec = message.Data;
                ShowMessage(smsrec, message.Index);
            }
        }

        private void ShowMessage(SmsPdu pdu, int MessageIndex)
        {// Received message
            SmsDeliverPdu data = (SmsDeliverPdu)pdu;

            string SenderNumber = data.OriginatingAddress;
            string MessageQuery = data.UserDataText;

            SetSomeText(SenderNumber, MessageQuery, MessageIndex);

            return;
        }

        delegate void SetTextCallback(string SenderNumber, string MessageQuery, int MessageIndex);
        private void SetSomeText(string SenderNumber, string MessageQuery, int MessageIndex)
        {
            if (MessagesGridView.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetSomeText);
                this.Invoke(d, new object[] { SenderNumber, MessageQuery, MessageIndex });
            }
            else
            {
                //Finally we have received the message. Now we have to interpret it.

                //first wrap it in the tags
                MessageQuery = "<message>" + MessageQuery + "</message>";

                string City = interpreter.ReturnCityName(MessageQuery);
                string StartPointName = interpreter.ReturnStartPointName(MessageQuery);
                string EndPointName = interpreter.ReturnEndPointName(MessageQuery);

                if (interpreter.ConfirmCity(City))
                {
                    //this means city name is correct.
                    if (interpreter.ConfirmLocationExist(StartPointName + ", " + City))
                    {
                        //this means start point name is correct.
                        if (interpreter.ConfirmLocationExist(EndPointName + ", " + City))
                        {
                            //this means end point name is correct.

                            //we are all set. Now get the response for these Start Point & End Point Names

                            string VehiclesResponse = interpreter.GetResponse(StartPointName + ", " + City, EndPointName + ", " + City);

                            string Response = string.Empty;

                            if (VehiclesResponse.Length > 2)
                            {
                                Response = "Following vehicles will take you from " + StartPointName + " to " + EndPointName + "\n" + VehiclesResponse;
                                //response received. Now add this to gridview & send this to sender

                                if (Response.Length >= 160)
                                {
                                    Response = interpreter.ReturnShortMessage(Response);
                                }
                            }
                            else if (VehiclesResponse.Length <= 2)
                            {
                                Response = "Sorry ! Transit Pakistan is currently under development. For now we dont have any vehicles data available on route from "+StartPointName + " to " + EndPointName;
                            }

                            MessagesGridView.Rows.Add(SenderNumber, MessageQuery, StartPointName + ", " + City, EndPointName + ", " + City, Response, SendMessage(SenderNumber, Response));
                        }
                        else if (!interpreter.ConfirmLocationExist(EndPointName + ", " + City))
                        {
                            //send a message to sender that this End point name is incoorect & add this to data grid view
                            string Response = "Sorry we can't understand your destination name. Did you mean\n" + interpreter.GetSimilarSuggestions(EndPointName + ", " + City);

                            if (Response.Length >= 160)
                            {
                                Response = interpreter.ReturnShortMessage(Response);
                            }
                            
                            MessagesGridView.Rows.Add(SenderNumber, MessageQuery, StartPointName, EndPointName, Response, SendMessage(SenderNumber, Response));
                        }
                    }
                    else if (!interpreter.ConfirmLocationExist(StartPointName + ", " + City))
                    {
                        //send a message to sender that this start point name is incoorect & add this to data grid view

                        string Response = "Sorry we can't understand your start location name. Did you mean\n" + interpreter.GetSimilarSuggestions(StartPointName + ", " + City);

                        if (Response.Length >= 160)
                        {
                            Response = interpreter.ReturnShortMessage(Response);
                        }
                        
                        MessagesGridView.Rows.Add(SenderNumber, MessageQuery, StartPointName, EndPointName, Response, SendMessage(SenderNumber, Response));
                    }
                }
                else if (!interpreter.ConfirmCity(City))
                {
                    //send a message to sender that this city name is incoorect & add this to data grid view

                    string Response = "Sorry! Currently Transit Pakistan only operates in Karachi. Either you didn't write the correct city name or we dont provide services in your city.\nYou wrote : " + City;

                    if (Response.Length >= 160)
                    {
                        Response = interpreter.ReturnShortMessage(Response);
                    }
                    
                    MessagesGridView.Rows.Add(SenderNumber, MessageQuery, StartPointName, EndPointName, Response, SendMessage(SenderNumber, Response));
                }
            }

            //once everything is done. Now delete the message from Sim memory so that space is available for more messages

            comm.DeleteMessage(MessageIndex, PhoneStorageType.Sim);
        }

        private bool SendMessage(string CELL_Number, string SMS_Message)
        {
            SmsSubmitPdu pdu1;
            if (comm.IsConnected() == true)
            {
                try
                {
                    pdu1 = new SmsSubmitPdu(SMS_Message, CELL_Number, "");
                    comm.SendMessage(pdu1);

                    return true;
                }
                catch (Exception E5)
                {
                    MessageBox.Show("Error Sending SMS To Destination Address\r\n\n Connection Has Been Terminated !!!\r\n\n");
                    comm.Close();
                    return false;
                }
            }
            return false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MessagesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MessageBox.Show(MessagesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), "Content", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConnectionStatusMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExportRecordsMenuItem_Click(object sender, EventArgs e)
        {
            string TextForFile = string.Empty;

            foreach (DataGridViewRow Row in MessagesGridView.Rows)
            {
                string Sender = Row.Cells["SenderColumn"].Value.ToString();
                string Query = Row.Cells["QueryColumn"].Value.ToString();
                string StartPoint = Row.Cells["StartPointColumn"].Value.ToString();
                string EndPoint = Row.Cells["EndPointColumn"].Value.ToString();
                string Response = Row.Cells["ResponseColumn"].Value.ToString();
                string Responded = Row.Cells["RespondedColumn"].Value.ToString();

                TextForFile = TextForFile + WrapXML(Sender, Query, StartPoint, EndPoint, Response, Responded);
            }

            TextForFile = "<Records>" + "\n"
                + TextForFile + "\n"
                + "</Records>";

            //now write this in a text file

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Export records";

            sfd.Filter = "Text Files| *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string FileName = sfd.FileName;

                FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs);

                sw.Write(TextForFile);

                sw.Close();
                fs.Close();

                MessageBox.Show("All records are written to file " + FileName, "Content", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public string WrapXML(string Sender, string Query, string StartPoint, string EndPoint, string Response, string Responded)
        {
            Sender = "<Sender>" + Sender + "</Sender>";
            Query = "<Query>" + Query + "</Query>";
            StartPoint = "<StartPoint>" + StartPoint + "</StartPoint>";
            EndPoint = "<EndPoint>" + EndPoint + "</EndPoint>";
            Response = "<Response>" + Response + "</Response>";
            Responded = "<Responded>" + Responded + "</Responded>";

            string SingleRowXML = "<Record>" + "\n"
                + Sender + "\n"
                + Query + "\n"
                + StartPoint + "\n"
                + EndPoint + "\n"
                + Response + "\n"
                + Responded + "\n"
                + "</Record>";

            return SingleRowXML;
        }

        private void TestMessageMenuItem_Click(object sender, EventArgs e)
        {
            SendMessage sm = new SendMessage();

            if (sm.ShowDialog() == DialogResult.OK)
            {
                if (SendMessage(sm.NumberBox.Text, sm.MessageRBox.Text))
                    MessageBox.Show("Message Sent", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Message Not Sent", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is SMS Module of Transit Pakistan developed by\nSajjad Gul\nMaaz Hassan\nand Haris Ali.\nDated : 16-05-2016", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
