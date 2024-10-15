namespace WinFormsApp
{
    partial class MainForm
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
            listViewStudents = new ListView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            UpdateListBtn = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // listViewStudents
            // 
            listViewStudents.Location = new Point(14, 120);
            listViewStudents.Margin = new Padding(3, 4, 3, 4);
            listViewStudents.Name = "listViewStudents";
            listViewStudents.Size = new Size(572, 428);
            listViewStudents.TabIndex = 0;
            listViewStudents.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(639, 120);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(229, 31);
            button1.TabIndex = 1;
            button1.Text = "Добавить студента";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAddStudent_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(639, 172);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(229, 31);
            button2.TabIndex = 2;
            button2.Text = "Удалить выбранного студента";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnRemoveStudent_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(639, 224);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(229, 31);
            button3.TabIndex = 3;
            button3.Text = "Изменить выбранного студента";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnUpdateStudent_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Location = new Point(639, 501);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(229, 79);
            button4.TabIndex = 4;
            button4.Text = "Гистаграмма";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnShowDistribution_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Peace Sans", 35.9999962F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(129, 12);
            label1.Name = "label1";
            label1.Size = new Size(653, 83);
            label1.TabIndex = 5;
            label1.Text = "Деканат Pro Max ++";
            label1.Click += label1_Click;
            // 
            // UpdateListBtn
            // 
            UpdateListBtn.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UpdateListBtn.Location = new Point(14, 557);
            UpdateListBtn.Margin = new Padding(3, 4, 3, 4);
            UpdateListBtn.Name = "UpdateListBtn";
            UpdateListBtn.Size = new Size(150, 31);
            UpdateListBtn.TabIndex = 6;
            UpdateListBtn.Text = "Обновить список";
            UpdateListBtn.UseVisualStyleBackColor = true;
            UpdateListBtn.Click += UpdateListBtn_Click;
            // 
            // button5
            // 
            button5.Location = new Point(774, 2);
            button5.Name = "button5";
            button5.Size = new Size(137, 29);
            button5.TabIndex = 7;
            button5.Text = "Фуфелшмерц?";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOrange;
            ClientSize = new Size(914, 600);
            Controls.Add(button5);
            Controls.Add(UpdateListBtn);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listViewStudents);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "Деканат про макс";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listViewStudents;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Button UpdateListBtn;
        private Button button5;
    }
}
