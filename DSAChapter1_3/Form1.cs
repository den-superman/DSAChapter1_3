namespace DSAChapter1_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.txt";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                Dictionary<string, int> Dict = Core.CalculateWords(path);
                if (Dict != null)
                {
                    var mostUsedWords = Dict.OrderByDescending(pair => pair.Value).Take(10);
                    var leastUsedWords = Dict.OrderBy(pair => pair.Value).Take(10);
                    foreach (var pair in mostUsedWords)
                    {
                        listBox1.Items.Add($"{pair.Key}: {pair.Value} times");
                    }
                    foreach (var pair in leastUsedWords)
                    {
                        listBox2.Items.Add($"{pair.Key}: {pair.Value} times");
                    }
                }
            }
        }
    }
}