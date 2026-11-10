namespace mushroom
{
    partial class menu
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
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(233, 30);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 0;
            label1.Text = "Mushroom Identifier";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 77);
            label2.Name = "label2";
            label2.Size = new Size(336, 20);
            label2.TabIndex = 1;
            label2.Text = "Think of one of these mushrooms, then click Start.";
            // 
            // label3
            // 
            label3.Location = new Point(193, 138);
            label3.Name = "label3";
            label3.Size = new Size(336, 127);
            label3.TabIndex = 2;
            label3.Text = " Agaric Jaunissant\r\nAmanite tue-mouche\r\n Cepe de Bordeaux\r\nCoprin chevelu\r\nGirolle\r\n Pied bleu\r\n\r\n";
            // 
            // button1
            // 
            button1.BackColor = Color.Aquamarine;
            button1.Location = new Point(193, 317);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Aquamarine;
            button2.Location = new Point(480, 317);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Logout";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Aquamarine;
            button3.Location = new Point(332, 317);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 5;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = false;
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "menu";
            Text = "menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}