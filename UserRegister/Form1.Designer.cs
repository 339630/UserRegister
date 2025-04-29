namespace UserRegister
{
    partial class Kartoteka
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonAdd = new Button();
            buttonEdit = new Button();
            treeView1 = new TreeView();
            panelPersonInfo = new Panel();
            birthDateTextBox = new TextBox();
            nameTextBox = new TextBox();
            surnameTextBox = new TextBox();
            surnameLabel = new Label();
            categoryPanel = new Panel();
            dataGridView1 = new DataGridView();
            SurnameCol = new DataGridViewTextBoxColumn();
            NameCol = new DataGridViewTextBoxColumn();
            BirthdayCol = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panelPersonInfo.SuspendLayout();
            categoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(12, 392);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(218, 46);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Dodaj osobę";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(0, 380);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(206, 46);
            buttonEdit.TabIndex = 2;
            buttonEdit.Text = "Edytuj";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(218, 374);
            treeView1.TabIndex = 3;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // panelPersonInfo
            // 
            panelPersonInfo.Controls.Add(label3);
            panelPersonInfo.Controls.Add(label2);
            panelPersonInfo.Controls.Add(label1);
            panelPersonInfo.Controls.Add(birthDateTextBox);
            panelPersonInfo.Controls.Add(nameTextBox);
            panelPersonInfo.Controls.Add(buttonEdit);
            panelPersonInfo.Controls.Add(surnameTextBox);
            panelPersonInfo.Controls.Add(surnameLabel);
            panelPersonInfo.Location = new Point(236, 12);
            panelPersonInfo.Name = "panelPersonInfo";
            panelPersonInfo.Size = new Size(552, 426);
            panelPersonInfo.TabIndex = 4;
            panelPersonInfo.Visible = false;
            // 
            // birthDateTextBox
            // 
            birthDateTextBox.Enabled = false;
            birthDateTextBox.Location = new Point(190, 108);
            birthDateTextBox.Name = "birthDateTextBox";
            birthDateTextBox.Size = new Size(263, 23);
            birthDateTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            nameTextBox.Enabled = false;
            nameTextBox.Location = new Point(190, 63);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(263, 23);
            nameTextBox.TabIndex = 2;
            // 
            // surnameTextBox
            // 
            surnameTextBox.Enabled = false;
            surnameTextBox.Location = new Point(190, 21);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(263, 23);
            surnameTextBox.TabIndex = 1;
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Location = new Point(115, 24);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new Size(57, 15);
            surnameLabel.TabIndex = 0;
            surnameLabel.Text = "Nazwisko";
            surnameLabel.Click += label1_Click;
            // 
            // categoryPanel
            // 
            categoryPanel.Controls.Add(dataGridView1);
            categoryPanel.Location = new Point(236, 15);
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Size = new Size(552, 423);
            categoryPanel.TabIndex = 5;
            categoryPanel.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { SurnameCol, NameCol, BirthdayCol });
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(546, 97);
            dataGridView1.TabIndex = 1;
            // 
            // SurnameCol
            // 
            SurnameCol.HeaderText = "Nazwisko";
            SurnameCol.Name = "SurnameCol";
            SurnameCol.ReadOnly = true;
            SurnameCol.Width = 180;
            // 
            // NameCol
            // 
            NameCol.HeaderText = "Imię";
            NameCol.Name = "NameCol";
            NameCol.ReadOnly = true;
            NameCol.Width = 180;
            // 
            // BirthdayCol
            // 
            BirthdayCol.HeaderText = "Data urodzenia";
            BirthdayCol.Name = "BirthdayCol";
            BirthdayCol.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(248, 206);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 4;
            label1.Text = "Nazwisko";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 66);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 5;
            label2.Text = "Imię";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(86, 111);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 6;
            label3.Text = "Data urodzenia";
            label3.Click += label3_Click;
            // 
            // Kartoteka
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 447);
            Controls.Add(categoryPanel);
            Controls.Add(panelPersonInfo);
            Controls.Add(treeView1);
            Controls.Add(buttonAdd);
            Name = "Kartoteka";
            Text = "Form1";
            panelPersonInfo.ResumeLayout(false);
            panelPersonInfo.PerformLayout();
            categoryPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAdd;
        private Button buttonEdit;
        private TreeView treeView1;
        private Panel panelPersonInfo;
        private Label surnameLabel;
        private TextBox surnameTextBox;
        private TextBox nameTextBox;
        private TextBox birthDateTextBox;
        private Panel categoryPanel;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn SurnameCol;
        private DataGridViewTextBoxColumn NameCol;
        private DataGridViewTextBoxColumn BirthdayCol;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
