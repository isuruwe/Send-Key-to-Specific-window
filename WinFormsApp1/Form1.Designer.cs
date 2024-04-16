using WinFormsApp1.Controls;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WinFormsApp1
{
    partial class Form1
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
            button1 = new KeyButton();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            button2 = new Button();
            button3 = new KeyButton();
            button4 = new KeyButton();
            button5 = new KeyButton();
            button6 = new KeyButton();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.IsPressed = false;
            button1.KeyCode = 18;
            button1.Location = new Point(481, 118);
            button1.Name = "button1";
            button1.NormalText = null;
            button1.ShiftText = null;
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Alt";
            button1.UnNumLockKeyCode = 0;
            button1.UnNumLockText = null;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.Location = new Point(30, 22);
            listView1.Name = "listView1";
            listView1.Size = new Size(260, 328);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Open Windows";
            columnHeader1.Width = 200;
            // 
            // button2
            // 
            button2.Location = new Point(565, 38);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Refresh Windows";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.IsPressed = false;
            button3.KeyCode = 17;
            button3.Location = new Point(579, 118);
            button3.Name = "button3";
            button3.NormalText = null;
            button3.ShiftText = null;
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Ctrl";
            button3.UnNumLockKeyCode = 0;
            button3.UnNumLockText = null;
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.BackColor = Color.Black;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.White;
            button4.IsPressed = false;
            button4.KeyCode = 37;
            button4.Location = new Point(481, 158);
            button4.Name = "button4";
            button4.NormalText = null;
            button4.ShiftText = null;
            button4.Size = new Size(75, 23);
            button4.TabIndex = 4;
            button4.Text = "<-";
            button4.UnNumLockKeyCode = 0;
            button4.UnNumLockText = null;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button5
            // 
            button5.BackColor = Color.Black;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.White;
            button5.IsPressed = false;
            button5.KeyCode = 39;
            button5.Location = new Point(579, 158);
            button5.Name = "button5";
            button5.NormalText = null;
            button5.ShiftText = null;
            button5.Size = new Size(75, 23);
            button5.TabIndex = 5;
            button5.Text = "->";
            button5.UnNumLockKeyCode = 0;
            button5.UnNumLockText = null;
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.BackColor = Color.Black;
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.White;
            button6.IsPressed = false;
            button6.KeyCode = 39;
            button6.Location = new Point(579, 158);
            button6.Name = "button6";
            button6.NormalText = null;
            button6.ShiftText = null;
            button6.Size = new Size(75, 23);
            button6.TabIndex = 5;
            button6.Text = "->";
            button6.UnNumLockKeyCode = 0;
            button6.UnNumLockText = null;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            TopMost = true;
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private KeyButton button1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private Button button2;
        private KeyButton button3;
        private KeyButton button4;
        private KeyButton button5;
        private KeyButton button6;
    }
}
