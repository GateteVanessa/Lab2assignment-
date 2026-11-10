namespace Lab2
{
    public partial class MenuForm : Form
    {
        private readonly TextBox textBox1 = new();
        private readonly TextBox textBox2 = new();
        private readonly TextBox totalTextBox = new();
        private readonly Button button1 = new();
        private readonly Button button2 = new();

        public MenuForm()
        {
            InitializeComponent();
            BuildCalculator();
        }

        private void BuildCalculator()
        {
            Text = "Bicycle Rental Calculator";
            ClientSize = new Size(800, 450);
            StartPosition = FormStartPosition.CenterScreen;

            AddLabel("Starting hour", 55, 60);
            AddLabel("Ending hour", 55, 112);
            AddLabel("Total cost", 55, 164);

            AddTextBox(textBox1, 230, 55);
            AddTextBox(textBox2, 230, 107);
            AddTextBox(totalTextBox, 230, 159);
            totalTextBox.Name = "totalTextBox";
            totalTextBox.ReadOnly = true;

            button1.Name = "button1";
            button1.Text = "Calculate";
            button1.Location = new Point(230, 235);
            button1.Size = new Size(100, 32);
            button1.Click += CalculateButton_Click;
            Controls.Add(button1);

            button2.Name = "button2";
            button2.Text = "Logout";
            button2.Location = new Point(360, 235);
            button2.Size = new Size(100, 32);
            button2.Click += (_, _) => Close();
            Controls.Add(button2);
        }

        private void AddLabel(string text, int x, int y)
        {
            Controls.Add(new Label
            {
                Text = text,
                Location = new Point(x, y + 4),
                AutoSize = true
            });
        }

        private void AddTextBox(TextBox textBox, int x, int y)
        {
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(230, 27);
            Controls.Add(textBox);
        }

        private void CalculateButton_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int startHour) ||
                !int.TryParse(textBox2.Text, out int endHour))
            {
                MessageBox.Show("Enter whole numbers for both hours.", "Invalid hours",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                totalTextBox.Clear();
                return;
            }

            if (startHour < 0 || startHour > 23 || endHour < 1 || endHour > 24 || startHour >= endHour)
            {
                MessageBox.Show("Start must be 0-23, end must be 1-24, and start must be before end.",
                    "Invalid hours", MessageBoxButtons.OK, MessageBoxIcon.Error);
                totalTextBox.Clear();
                return;
            }

            int total = 0;
            for (int hour = startHour; hour < endHour; hour++)
            {
                if (hour < 7 || hour >= 21)
                    total += 500;
                else if (hour < 14 || hour >= 19)
                    total += 1000;
                else
                    total += 1500;
            }

            totalTextBox.Text = $"{total} RWF";
        }
    }
}
