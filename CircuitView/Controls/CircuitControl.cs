using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elements;

namespace CircuitView.Controls
{
    public partial class CircuitControl : UserControl
    {
        /// <summary>
        /// Конструктор контрола
        /// </summary>
        public CircuitControl()
        {

            InitializeComponent();

            #region Схема 5

            Resistor r1 = new Resistor("R1", 100);
            Resistor r2 = new Resistor("R2", 150);
            Resistor r3 = new Resistor("R3", 50);

            Inductor l1 = new Inductor("L1", 100);
            Inductor l2 = new Inductor("L2", 100);
            Inductor l3 = new Inductor("L3", 100);

            Capacitor c1 = new Capacitor("C1", 100);
            Capacitor c2 = new Capacitor("C2", 200);
            Capacitor c3 = new Capacitor("C3", 300);

            List<IPrimitive> circuitComponents5 = new List<IPrimitive>();
            circuitComponents5.Add(r1);
            circuitComponents5.Add(r2);
            circuitComponents5.Add(l1);
            circuitComponents5.Add(l2);
            circuitComponents5.Add(c1);
            circuitComponents5.Add(c2);
            circuitComponents5.Add(r3);
            _listCircuit.Add(circuitComponents5);

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

            serialCircuit3.AddComponent(r3);
            serialCircuit3.AddComponent(parallelCircuit2);
            #endregion

            #region Схема 1

            Resistor r4 = new Resistor("R1", 100);
            Inductor l4 = new Inductor("L1", 100);
            Capacitor c4 = new Capacitor("C1", 100);
            List<IPrimitive> circuitComponents1 = new List<IPrimitive>();
            circuitComponents1.Add(r4);
            circuitComponents1.Add(l4);
            circuitComponents1.Add(c4);
            _listCircuit.Add(circuitComponents1);


            ParallelCircuit parallelCircuit4 = new ParallelCircuit();
            parallelCircuit4.AddComponent(l4);
            parallelCircuit4.AddComponent(c4);

            SerialCircuit serialCircuit4 = new SerialCircuit();
            serialCircuit4.AddComponent(r4);
            serialCircuit4.AddComponent(parallelCircuit4);
            #endregion

        }

        private List<List<Elements.IPrimitive>> _listCircuit = new List<List<IPrimitive>>();

        public List<IPrimitive> GetPrimitives
        {
            get
            {
                if (circuitsComboBox.SelectedIndex == 0)
                {
                    return _listCircuit.ElementAt(0);
                }
                else
                {
                    return _listCircuit.ElementAt(1);
                }
            }
        }

        private void circuitsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
