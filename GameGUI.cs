namespace Program5
{
    public partial class GameGUI : Form
    {
        public GameGUI()
        {
            InitializeComponent();
            MessageBox.Show("Hello World");



            // Concrete method: Displays the grid in a ListBox
            //public void DisplayGrid(ListBox listBox)
            //{
            //    listBox.Items.Clear();
            //    for (int i = 0; i < rows; i++)
            //    {
            //        string row = "";
            //        for (int j = 0; j < cols; j++)
            //        {
            //            row += grid[i, j];
            //        }
            //        listBox.Items.Add(row);
            //    }
            //}
        }
    }
}
