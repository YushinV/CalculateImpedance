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
    public partial class DrawControl : UserControl
    {
        private ICircuit _circuit;
        const int x = 100;
        const int y = 100;
        private int h = 52;
        private int w = 52;
        int x1 = x;
        int y1 = y;

        public DrawControl()
        {
            InitializeComponent();
        }

        public ICircuit SetCircuit
        {
            set
            {
                _circuit = value;
            }
        }

        /// <summary>
        /// Событие рисующее схему
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawControl_Paint(object sender, PaintEventArgs e)
        {
            CircuitDraw(_circuit, e);
            
        }

        /// <summary>
        /// Метод рисования
        /// </summary>
        /// <param name="circuit"></param>
        /// <param name="e"></param>
        private void CircuitDraw(ICircuit circuit, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 2);

            if (circuit is SerialCircuit)
            {
                foreach (var component in circuit.Components)
                {
                    
                    if (component is IPrimitive)
                    {
                        IPrimitive primitive = (IPrimitive)component;
                        e.Graphics.DrawImage(primitive.Image, x1, y);
                        x1 += w;
                    }
                    if (component is ICircuit)
                    {
                        ICircuit cir = (ICircuit) component;
                        CircuitDraw(cir, e);
                        x1 += w;
                    }
                }
            }

            
            if (circuit is ParallelCircuit)
            {
                int countComponent = circuit.Components.Count;

                e.Graphics.DrawLine(blackPen,
                    new Point(x1-1,  y + 25), 
                    new Point(x1-1,  y + (w * countComponent) - 25));
                

                foreach (var component in circuit.Components)
                {
                    if (component is IPrimitive)
                    {
                        IPrimitive primitive = (IPrimitive)component;
                        e.Graphics.DrawImage(primitive.Image, x1, y1);
                        y1 += 52;
                    }
                    if (component is ICircuit)
                    {
                        ICircuit cir = (ICircuit)component;
                        CircuitDraw(cir, e);
                    }
                }
                e.Graphics.DrawLine(blackPen,
                    new Point(x1 + w, y + 25),
                    new Point(x1 + w, y + (w * countComponent) - 25));
            }
        }
    }
}
