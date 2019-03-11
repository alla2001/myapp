using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;
using System.Net;
using System.Net.NetworkInformation;

namespace WindowsFormsApp3
{

    public partial class Form1 : Form
    {


        //System.
        public Form1()
        {
            IPAddress ips=IPAddress.Parse("192.168.1.70");
            var ping= new Ping();
            ping.Send(ips);
            
           
            Console.WriteLine(ping.Send(ips));
            InitializeComponent();
            addbox();
            NetworkGateway();
            /* List<string> devices = new List<string>();
                  NetworkInterface[] niArr = NetworkInterface.GetAllNetworkInterfaces();
                  Console.WriteLine("Retriving basic information of network.\n\n");

                  foreach (NetworkInterface tempNetworkInterface in niArr)
                  {
                      devices.Add(tempNetworkInterface.Name);
                      Console.WriteLine(tempNetworkInterface.Name);
                  }*/

        }

        public void addbox()
        {
            var column = new DataGridViewCheckBoxColumn();
            column.Width = 80;
            column.HeaderText = "cut downlaod";
            dataGridView1.Columns.Add(column);
            var column2 = new DataGridViewCheckBoxColumn();
            column2.Width = 80;
            column2.HeaderText = "cut upload";
            dataGridView1.Columns.Add(column2);
        }
        public void box(Dv pc)
        {
            var index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells["Name"].Value = pc.Name;
            dataGridView1.Rows[index].Cells["ip"].Value = pc.Address;
        }
        static string NetworkGateway()
        {
            string ip = null;

            foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (f.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (GatewayIPAddressInformation d in f.GetIPProperties().GatewayAddresses)
                    {
                        ip = d.Address.ToString();
                        Console.WriteLine(d.Address.ToString());
                    }
                }
            }

            return ip;
        }
        public class Dv
        {
            public IPAddress Address { get; private set; }
            public string Name { get; private set; }
            public Dv(string _address, string _name)
            {
                Name = _name;

                try
                {
                    Address = System.Net.IPAddress.Parse(_address);
                }
                catch
                {
                    Console.WriteLine("ip address is null");
                }
            }
            public static Dv addip(string _address, string _name)
            {
                var pc = new Dv(_address, _name);
                return pc;
            }



        }
        /*public List<string> pingip(IPAddress ip)
        {
            List<string> _ip;
            

            return ip;
        }*/



        private void button1_Click(object sender, EventArgs e)
        {

            var pc = Dv.addip("192.168.1.1", "oppof9");
            box(pc);
            Console.WriteLine(pc.Address);





        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
