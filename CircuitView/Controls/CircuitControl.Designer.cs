namespace CircuitView.Controls
{
    partial class CircuitControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.circuitsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Цепь:";
            // 
            // circuitsComboBox
            // 
            this.circuitsComboBox.FormattingEnabled = true;
            this.circuitsComboBox.Items.AddRange(new object[] {
            "Схема 1",
            "Схема 5"});
            this.circuitsComboBox.Location = new System.Drawing.Point(98, 3);
            this.circuitsComboBox.Name = "circuitsComboBox";
            this.circuitsComboBox.Size = new System.Drawing.Size(103, 21);
            this.circuitsComboBox.TabIndex = 2;
            this.circuitsComboBox.SelectionChangeCommitted += new System.EventHandler(this.circuitsComboBox_SelectionChangeCommitted);
            // 
            // CircuitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.circuitsComboBox);
            this.Name = "CircuitControl";
            this.Size = new System.Drawing.Size(204, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox circuitsComboBox;
    }
}
