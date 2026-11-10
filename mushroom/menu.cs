namespace mushroom
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button3.Click += button3_Click;
        }

        // Ask one yes/no question.
        private bool Ask(string question)
        {
            return MessageBox.Show(question, "Mushroom", MessageBoxButtons.YesNo)
                == DialogResult.Yes;
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            string mushroomName;

            if (Ask("Does your mushroom have a convex cup?"))
            {
                if (Ask("Does it grow in a forest?"))
                {
                    mushroomName = Ask("Does it have a ring?")
                        ? "Amanite tue-mouche" : "Pied bleu";
                }
                else
                {
                    mushroomName = "Agaric Jaunissant";
                }
            }
            else if (Ask("Does it have a ring?"))
            {
                mushroomName = "Coprin chevelu";
            }
            else
            {
                mushroomName = Ask("Does it have gills?")
                    ? "Girolle" : "Cepe de Bordeaux";
            }

            MessageBox.Show("Your mushroom is: " + mushroomName);
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
