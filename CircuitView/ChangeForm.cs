#region
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
#endregion

namespace CircuitView
{
    public partial class ChangeForm : Form
    {
		// TODO: не везде XML-комментарии

        private IPrimitive _primitive;

        public ChangeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Устанавливает или возвращает компонент
        /// </summary>
        public IPrimitive Primitive
        {
            get
            {
                return _primitive;
            }
            set
            {
                if (value is Resistor)
                {
                    comboBoxPrimitiveType.SelectedIndex = 0;
                }
                if (value is Capacitor)
                {
                    comboBoxPrimitiveType.SelectedIndex = 1;
                }
                if(value is Inductor)
                {
                    comboBoxPrimitiveType.SelectedIndex = 2;
                }
                _primitive = value;
                textBoxValue.Text = Convert.ToString(value.Value);
                textBoxName.Text = value.Name;
                
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxPrimitiveType.SelectedIndex == 0)
            {
                IPrimitive resistor = new Resistor(textBoxName.Text, Convert.ToInt32(textBoxValue.Text));
                _primitive = resistor;
            }
            if (comboBoxPrimitiveType.SelectedIndex == 1)
            {
                IPrimitive capacitor = new Capacitor(textBoxName.Text, Convert.ToInt32(textBoxValue.Text));
                _primitive = capacitor;
            }
            if (comboBoxPrimitiveType.SelectedIndex == 2)
            {
                IPrimitive inductor = new Inductor(textBoxName.Text, Convert.ToInt32(textBoxValue.Text));
                _primitive = inductor;
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
