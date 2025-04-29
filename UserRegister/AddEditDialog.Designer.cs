namespace UserRegister
{
    partial class AddEditDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            surnameTextBox = new TextBox();
            label2 = new Label();
            nameTextBox = new TextBox();
            buttonOk = new Button();
            buttonCancel = new Button();
            label3 = new Label();
            birthdayDateTimePicker = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 27);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Nazwisko";
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new Point(107, 24);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(200, 23);
            surnameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 63);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 2;
            label2.Text = "Imię";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(107, 60);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(200, 23);
            nameTextBox.TabIndex = 3;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(73, 149);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 5;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(154, 149);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Anuluj";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 103);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 7;
            label3.Text = "Data urodzenia";
            label3.Click += label3_Click;
            // 
            // birthdayDateTimePicker
            // 
            birthdayDateTimePicker.Location = new Point(107, 97);
            birthdayDateTimePicker.Name = "birthdayDateTimePicker";
            birthdayDateTimePicker.Size = new Size(200, 23);
            birthdayDateTimePicker.TabIndex = 9;
            // 
            // AddEditDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 184);
            Controls.Add(birthdayDateTimePicker);
            Controls.Add(label3);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(nameTextBox);
            Controls.Add(label2);
            Controls.Add(surnameTextBox);
            Controls.Add(label1);
            Name = "AddEditDialog";
            Text = "AddEditDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox surnameTextBox;
        private Label label2;
        private TextBox nameTextBox;
        private Button buttonOk;
        private Button buttonCancel;
        private Label label3;
        private DateTimePicker birthdayDateTimePicker;
    }
}