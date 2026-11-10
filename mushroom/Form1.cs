namespace mushroom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            button2.Click += button2_Click;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                menu menuForm = new menu();
                menuForm.FormClosed += (s, args) =>
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    Show();
                };
                Hide();
                menuForm.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
                textBox2.Clear();
            }
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
