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

namespace CircuitView
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Переменная с частотой
        /// </summary>
        private double _freguency;

        /// <summary>
        /// Переменная со схемой
        /// </summary>
        private ICircuit _circuit;
        

        private int _indexComboBox;
        public MainForm()
        {
            InitializeComponent();
            double freguency = 50;
            textBoxFrequency.Text = freguency.ToString();
        }

        /// <summary>
        /// Метод возвращающий схемы
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private ICircuit getCircuit(int index)
        {
            if (index == 0)
            {
                #region Схема 1
                Resistor r4 = new Resistor("R1", 100);
                Inductor l4 = new Inductor("L1", 100);
                Capacitor c4 = new Capacitor("C1", 100);
                
                ParallelCircuit parallelCircuit1 = new ParallelCircuit();
                parallelCircuit1.AddComponent(l4);
                parallelCircuit1.AddComponent(c4);

                SerialCircuit serialCircuit4 = new SerialCircuit();
                serialCircuit4.AddComponent(r4);
                serialCircuit4.AddComponent(parallelCircuit1);
                return serialCircuit4;

                #endregion
            }
            if (index == 1)
            {
                #region Схема 2
                Inductor l1 = new Inductor("L1", 100);
                Resistor r1 = new Resistor("R1", 100);
                Capacitor c1 = new Capacitor("C1", 100);

                SerialCircuit serialCircuit = new SerialCircuit();
                ParallelCircuit parallelCircuit = new ParallelCircuit();

                parallelCircuit.AddComponent(r1);
                parallelCircuit.AddComponent(c1);

                serialCircuit.AddComponent(l1);
                serialCircuit.AddComponent(parallelCircuit);

                return serialCircuit;
                #endregion
            }
            if (index == 2)
            {
                #region Схема 3
                Inductor l1 = new Inductor("L1", 100);
                Inductor l2 = new Inductor("L2", 100);
                Inductor l3 = new Inductor("l3", 100);
                Capacitor c1 = new Capacitor("C1", 100);
                Resistor r1 = new Resistor("R1", 100);

                ParallelCircuit parallelCircuit1 = new ParallelCircuit();
                ParallelCircuit parallelCircuit2 = new ParallelCircuit();
                SerialCircuit serialCircuit = new SerialCircuit();

                parallelCircuit1.AddComponent(c1);
                parallelCircuit1.AddComponent(l1);
                parallelCircuit2.AddComponent(l2);
                parallelCircuit2.AddComponent(r1);

                serialCircuit.AddComponent(parallelCircuit1);
                serialCircuit.AddComponent(parallelCircuit2);
                serialCircuit.AddComponent(l3);

                return serialCircuit;

                #endregion
            }
            if (index == 3)
            {
                #region Схема 4
                Capacitor c1 = new Capacitor("C1", 100);
                Resistor r1 = new Resistor("R1", 100);
                Inductor l1 = new Inductor("L1", 100);
                Inductor l2 = new Inductor("L1", 100);
                Resistor r2 = new Resistor("R2", 100);
                Capacitor c2 = new Capacitor("C2", 100);

                ICircuit parallelCircuit1 = new ParallelCircuit();
                ICircuit serialCircuit1 = new SerialCircuit();
                ICircuit parallelCircuit2 = new ParallelCircuit();
                ICircuit serialCircuit2 = new SerialCircuit();
                ICircuit parallelCircuit3 = new ParallelCircuit();

                parallelCircuit1.AddComponent(r1);
                parallelCircuit1.AddComponent(l1);
                serialCircuit1.AddComponent(parallelCircuit1);
                serialCircuit1.AddComponent(c1);

                parallelCircuit2.AddComponent(l2);
                parallelCircuit2.AddComponent(r2);
                serialCircuit2.AddComponent(parallelCircuit2);
                serialCircuit2.AddComponent(c2);
                
                parallelCircuit3.AddComponent(serialCircuit1);
                parallelCircuit3.AddComponent(serialCircuit2);

                return parallelCircuit3;

                #endregion
            }
            else
            {
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
                return serialCircuit3;

                #endregion
            }
        }
        
        /// <summary>
        /// Комбобокс выбора схемы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCircuit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            _circuit = getCircuit(comboBoxCircuit.SelectedIndex);
            iPrimitiveBindingSource.DataSource = _circuit.Primitives;
            _freguency = Convert.ToInt32(textBoxFrequency.Text);
            textBoxImpedance.Text = Convert.ToString(_circuit.CalculateZ(_freguency));
        }

        /// <summary>
        /// Кнопка изменения компонента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChange_Click(object sender, EventArgs e)
        {
            var changeForm = new ChangeForm();
            IPrimitive oldPrimitive = (IPrimitive)iPrimitiveBindingSource.Current;
            changeForm.Primitive = oldPrimitive;
            if (changeForm.ShowDialog() == DialogResult.OK)
            {
                IPrimitive primitive = changeForm.Primitive;
                _circuit.InsertComponent(oldPrimitive, primitive);
                iPrimitiveBindingSource.DataSource = _circuit.Primitives;

                _freguency = Convert.ToInt32(textBoxFrequency.Text);
                textBoxImpedance.Text = Convert.ToString(_circuit.CalculateZ(_freguency));
            }
        }
    }
}
