using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elements;
using System.Numerics;
using IComponent = Elements.IComponent;

namespace CircuitView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Комплексное сопротивление цепи";
            column1.CellTemplate = new DataGridViewTextBoxCell();
            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Частоты";
            column2.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView.Columns.Add(column2);
            dataGridView.Columns.Add(column1);
            dataGridView.RowCount = 1;

            
            Resistor r1 = new Resistor("R1", 100);
            Resistor r2 = new Resistor("R2", 150);
            Resistor r3 = new Resistor("R3", 50);

            Inductor l1 = new Inductor("L1", 100);
            Inductor l2 = new Inductor("L2", 100);
            Inductor l3 = new Inductor("L3", 100);

            Capacitor c1 = new Capacitor("C1", 100);
            Capacitor c2 = new Capacitor("C2", 200);
            Capacitor c3 = new Capacitor("C3", 300);

            ICircuit parallelCircuit1 = new ParallelCircuit();

            ICircuit parallelCircuit2 = new ParallelCircuit();

            ICircuit serialCircuit1 = new SerialCircuit();

            ICircuit serialCircuit2 = new SerialCircuit();

            ICircuit serialCircuit3 = new SerialCircuit();
            


            parallelCircuit1.AddComponent(c1);
            parallelCircuit1.AddComponent(r1);

            serialCircuit1.AddComponent(r2);
            serialCircuit1.AddComponent(l1);

            serialCircuit2.AddComponent(l2);
            serialCircuit2.AddComponent(parallelCircuit1);

            parallelCircuit2.AddComponent(c2);
            parallelCircuit2.AddComponent(serialCircuit1);
            parallelCircuit2.AddComponent(serialCircuit2);

            serialCircuit3.AddComponent(r2);
            serialCircuit3.AddComponent(parallelCircuit2);

            double freguency = 50;
            Complex impedance = serialCircuit3.CalculateZ(freguency);
            dataGridView.Rows.Add(freguency, impedance);



            //for (int i = 0; i < 5; i++)
            //{

            //    dataGridView.Rows.Add(freguency[i], impedance[i]);
            //}
        }
    }
}
