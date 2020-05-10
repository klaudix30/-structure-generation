using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        
        StructureGenerator sg;
        List<Double> times;
        public Form1()
        {

            InitializeComponent();
            sg = new StructureGenerator();
            times = sg.checkTime();
            time();

        }



        private void time()
        {
            label2.Text = "Czas ładowania: " + times.ElementAt(0).ToString() + "s\n"
            + "Czas generowania dwuliterowych: " + times.ElementAt(1).ToString() + "s\n"
            + "Czas generowania trzyliterowych: " + times.ElementAt(2).ToString() + "s\n";
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.Append;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(sg.getListOfSurname().ToArray());
            textBox1.AutoCompleteCustomSource = autoComplete;

        }
    }
}
