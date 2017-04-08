using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();
        Person p = new Person();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(path + "\\AddressBook"))
                Directory.CreateDirectory(path + "\\AddressBook");
            if (!File.Exists(path + "\\AddressBook\\settings.xml"))
                File.Create(path + "\\AddressBook\\ settings.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.Name = textBox1.Text;
            p.Email = textBox2.Text;
            p.StreetAddress = textBox3.Text;
            p.Birthday = dateTimePicker1.Value;
            p.AdditionalNotes = textBox4.Text;
            people.Add(p);
            listView2.Items.Add(p.Name);
            //listView1.

            //clear fields
            ClearFields();
        }

        private void ClearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;
           
        }

        private void ListView1(object sender, EventArgs e)
        {
            textBox1.Text = people[listView2.SelectedItems[0].Index].Name;
        }
    }

    public class Person
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String StreetAddress { get; set; }
        public String AdditionalNotes { get; set; }
        public DateTime Birthday { get; set; }
    }
}
