namespace UsefulTeacherTools
{
    public partial class AutoMarking : Form
    {
        public AutoMarking()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> students = textBoxClass.Text.Split("\n").ToList();
                List<string> temp = textBoxMarks.Text.Split("\n").ToList();
                List<int> marks = new List<int>();
                for (int i = 0; i < temp.Count; i++)
                {
                    marks.Add(Convert.ToInt32(temp[i]));
                }

                double max = Convert.ToDouble(textBoxMaxMark.Text);

                List<string> two = new List<string>();
                List<string> three = new List<string>();
                List<string> four = new List<string>();
                List<string> five = new List<string>();

                for (int i = 0; i < students.Count(); i++)
                {
                    if (marks[i] < 0 || marks[i] > max)
                    {
                        MessageBox.Show("Қателік бар!");
                        break;
                    }
                    if (marks[i] >= 0.85 * max && marks[i] <= max)
                        five.Add(students[i]);
                    else if (marks[i] >= 0.64 * max && marks[i] < 0.85 * max)
                        four.Add(students[i]);
                    else if (marks[i] >= 0.4 * max && marks[i] < 0.64 * max)
                        three.Add(students[i]);
                    else
                        two.Add(students[i]);
                }
                textBoxQuality.Text = $"{100 * (four.Count() + five.Count()) / (three.Count() + four.Count() + five.Count())}";

                //textBoxTwo.Text = "0-40: " + two.Count().ToString();
                textBoxThreeCount.Text = $"{three.Count().ToString()}";
                textBoxFourCount.Text = $"{four.Count().ToString()}";
                textBoxFiveCount.Text = $"{five.Count().ToString()}";

                //listViewThree(two);
                AddToTextBox(three, textBoxThree);
                AddToTextBox(four, textBoxFour);
                AddToTextBox(five, textBoxFive);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} Тізімде бос жол, дұрыс емес дерек болмағанын тексеріңіз. Максималды балл дұрыс енгізілгенін тексеріңіз.");
            }
        }
        private void AddToTextBox(List<string> list, TextBox textBox)
        {
            foreach(var item in list)
                textBox.Text += $"{item}\n";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFive.Text = "";
            textBoxFiveCount.Text = "";
            textBoxFour.Text = "";
            textBoxFourCount.Text = "";
            textBoxThree.Text = "";
            textBoxThreeCount.Text = "";
            textBoxMarks.Text = "";
            textBoxMaxMark.Text = "";
            textBoxQuality.Text = "";
        }
    }
}