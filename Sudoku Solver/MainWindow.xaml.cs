using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Suduku_Solver_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            F11.Focus();
        }
        int[,] user_input = new int[9, 9];
        string[] sub_array;
        string[] colomns;
        string[] rows;

        private void ReadInput()
        {
            int position = 0;
            for (int i = 0; i < grd_container.Children.Count; i++)
            {
                string num = (grd_container.Children[i] as TextBox).Text;
                if (num == string.Empty || num == "?" || num == "0")
                    user_input[position % 10, position / 10] = 0;
                else
                    user_input[position % 10, position / 10] = int.Parse(num);
                position++;
                if (position % 10 == 9)
                    position++;
            }
        }

        private MatrexState CheckInput()
        {
            bool id = true;
            ReadInput();
            List<int> tmp = new List<int>();
            rows = new string[9];
            colomns = new string[9];
            sub_array = new string[9];
            for (int i = 0; i < 9; i++)
            {
                tmp.Clear();
                int zero_count = 0;
                for (int j = 0; j < 9; j++)
                {
                    tmp.Add(user_input[i, j]);
                    colomns[i] += user_input[i, j];
                    if (user_input[i, j] == 0)
                        zero_count++;
                }
                if (tmp.Distinct().Count() - (zero_count == 0 ? 0 : 1) != tmp.Count() - zero_count)
                    id = false;
            }

            for (int j = 0; j < 9; j++)
            {
                tmp.Clear();
                int zero_count = 0;
                for (int i = 0; i < 9; i++)
                {
                    tmp.Add(user_input[i, j]);
                    rows[j] += user_input[i, j];
                    if (user_input[i, j] == 0)
                        zero_count++;
                }
                if (tmp.Distinct().Count() - (zero_count == 0 ? 0 : 1) != tmp.Count() - zero_count)
                    id = false;
            }

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    sub_array[(i / 3) * 3 + j / 3] += rows[i][j];
                }


            for (int i = 0; i < 9; i++)
            {
                tmp.Clear();
                int zero_count = 0;
                for (int j = 0; j < 9; j++)
                {
                    tmp.Add(sub_array[i][j]);
                    if (sub_array[i][j] == '0')
                        zero_count++;
                }
                if (tmp.Distinct().Count() - (zero_count == 0 ? 0 : 1) != tmp.Count() - zero_count)
                    id = false;
            }


            if (!id)
            {
                //check and highlight similer items;
                return MatrexState.Invaled;
            }
            else
            {
                bool solved = true;
                foreach (string i in sub_array)
                    if (i.Contains('0'))
                        solved = false;
                if (solved)
                    return MatrexState.Solved;
                return MatrexState.Chalange;
            }
        }



        private void SolveMatrex()
        {
            string[] solotion = new string[9];
            long s1 = DateTime.UtcNow.Ticks;
            var result = NextStep(0, GeneratePossibleNumber(rows, colomns, sub_array), solotion);
            long time = DateTime.UtcNow.Ticks - s1;
            switch (result)
            {
                case 0:
                    MessageBox.Show(string.Format("Can not Solve , Invalid Input\nTotal time : {0} ms", (long)TimeSpan.FromTicks(time).TotalMilliseconds));
                    break;
                case 1:
                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                            (grd_container.Children[i * 9 + j] as TextBox).Text = solotion[i][j].ToString();
                    switch (CheckInput())
                    {
                        case MatrexState.Invaled:
                        case MatrexState.Chalange:
                            MessageBox.Show(string.Format("Can not Solve , Invalid Input\nTotal time : {0} ms",(long) TimeSpan.FromTicks(time).TotalMilliseconds));
                            break;
                        case MatrexState.Solved:
                            MessageBox.Show(string.Format("SOLVED\nTotal time : {0} ms", (long)TimeSpan.FromTicks(time).TotalMilliseconds));
                            break;
                    }
                    break;

                case -1:
                    MessageBox.Show(string.Format("Can not Solve , Invalid Input\nTotal time : {0} ms", (long)TimeSpan.FromTicks(time).TotalMilliseconds));
                    break;
            }
        }

        private int NextStep(int level, string[] possible_number, string[] solotion)
        {
            string[] x = new string[9];
            Array.Copy(possible_number, 9 * level, x, 0, 9);
            var y = GeneratePossibleSolutions(x);
            if (y.Count == 0)
                return 0;
            foreach (var num in y)
            {
                for (int i = level + 1; i < 9; i++)
                    solotion[i] = rows[i];
                solotion[level] = num;
                if (level < 8)
                {
                    string[] col = new string[9];
                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                            col[i] += solotion[j][i];
                    string[] sub_arr = new string[9];
                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                            sub_arr[(i / 3) * 3 + (j / 3)] += solotion[i][j];
                    var poss = GeneratePossibleNumber(solotion, col, sub_arr);
                    if (NextStep(level + 1, poss, solotion) == 1)
                        return 1;
                }
                if (level == 8)
                    return 1;
            }
            return -1;
        }

        private string[] GeneratePossibleNumber(string[] rows,string[] colomns,string[]sub_arrays)
        {
            string[] poss = new string[81];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    poss[i * 9 + j] = "";
                    if (rows[i][j] != '0')
                        poss[i * 9 + j] += rows[i][j];
                    else
                    {
                        for (char k = '1'; k <= '9'; k++)
                            if (!rows[i].Contains(k) && !colomns[j].Contains(k) && !sub_arrays[((i / 3) * 3) + (j / 3) % 3].Contains(k))
                                poss[i * 9 + j] += k;
                    }
                }
            return poss;
        }

        private List<string> GeneratePossibleSolutions(string[] allowed_numbers)
        {
            List<string> numbers_list = new List<string>();
            for (int a = 0; a < allowed_numbers[0].Length; a++)
            {
                for (int b = 0; b < allowed_numbers[1].Length; b++)
                {
                    if (allowed_numbers[0][a] == allowed_numbers[1][b]) continue;
                    for (int c = 0; c < allowed_numbers[2].Length; c++)
                    {
                        if (allowed_numbers[2][c] == allowed_numbers[1][b] || allowed_numbers[2][c] == allowed_numbers[0][a]) continue;
                        for (int d = 0; d < allowed_numbers[3].Length; d++)
                        {
                            if (allowed_numbers[3][d] == allowed_numbers[2][c] || allowed_numbers[3][d] == allowed_numbers[1][b] || allowed_numbers[3][d] == allowed_numbers[0][a]) continue;
                            for (int f = 0; f < allowed_numbers[4].Length; f++)
                            {
                                if (allowed_numbers[4][f] == allowed_numbers[3][d] || allowed_numbers[4][f] == allowed_numbers[2][c] || allowed_numbers[4][f] == allowed_numbers[1][b] || allowed_numbers[4][f] == allowed_numbers[0][a]) continue;
                                for (int g = 0; g < allowed_numbers[5].Length; g++)
                                {
                                    if (allowed_numbers[5][g] == allowed_numbers[4][f] || allowed_numbers[5][g] == allowed_numbers[3][d] || allowed_numbers[5][g] == allowed_numbers[2][c] || allowed_numbers[5][g] == allowed_numbers[1][b] || allowed_numbers[5][g] == allowed_numbers[0][a]) continue;
                                    for (int h = 0; h < allowed_numbers[6].Length; h++)
                                    {
                                        if (allowed_numbers[6][h] == allowed_numbers[5][g] || allowed_numbers[6][h] == allowed_numbers[4][f] || allowed_numbers[6][h] == allowed_numbers[3][d] || allowed_numbers[6][h] == allowed_numbers[2][c] || allowed_numbers[6][h] == allowed_numbers[1][b] || allowed_numbers[6][h] == allowed_numbers[0][a]) continue;
                                        for (int i = 0; i < allowed_numbers[7].Length; i++)
                                        {
                                            if (allowed_numbers[7][i] == allowed_numbers[6][h] || allowed_numbers[7][i] == allowed_numbers[5][g] || allowed_numbers[7][i] == allowed_numbers[4][f] || allowed_numbers[7][i] == allowed_numbers[3][d] || allowed_numbers[7][i] == allowed_numbers[2][c] || allowed_numbers[7][i] == allowed_numbers[1][b] || allowed_numbers[7][i] == allowed_numbers[0][a]) continue;
                                            for (int j = 0; j < allowed_numbers[8].Length; j++)
                                            {
                                                if (allowed_numbers[8][j] == allowed_numbers[7][i] || allowed_numbers[8][j] == allowed_numbers[6][h] || allowed_numbers[8][j] == allowed_numbers[5][g] || allowed_numbers[8][j] == allowed_numbers[4][f] || allowed_numbers[8][j] == allowed_numbers[3][d] || allowed_numbers[8][j] == allowed_numbers[2][c] || allowed_numbers[8][j] == allowed_numbers[1][b] || allowed_numbers[8][j] == allowed_numbers[0][a]) continue;
                                                numbers_list.Add(allowed_numbers[0][a].ToString() + allowed_numbers[1][b] + allowed_numbers[2][c] + allowed_numbers[3][d] + allowed_numbers[4][f] + allowed_numbers[5][g] + allowed_numbers[6][h] + allowed_numbers[7][i] + allowed_numbers[8][j]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return numbers_list;
        }




        private void Cell_GetFocus(object sender, RoutedEventArgs e)
        {
            foreach (TextBox i in grd_container.Children)
                i.Select(0, 0);
            (sender as TextBox).SelectAll();
        }

        private void Cell_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 1)
            {
                string allowed_input = "123456789?";
                if (!allowed_input.Contains((sender as TextBox).Text))
                {
                    MessageBox.Show("Wrong input! - only numbers (1...9) and question mark (?) are allowed -");
                    (sender as TextBox).Text = "?";
                    (sender as TextBox).SelectAll();
                }
            }
        }

        private void Cell_KeyUp(object sender, KeyEventArgs e)
        {
            int index;
            switch (e.Key)
            {
                case Key.Home:
                    F11.Focus();
                    break;
                case Key.End:
                    F99.Focus();
                    break;
                case Key.PageUp:
                case Key.Up:
                    index = grd_container.Children.IndexOf(sender as TextBox);
                    if (index > 8)
                        grd_container.Children[index - 9].Focus();
                    break;
                case Key.PageDown:
                case Key.Down:
                    index = grd_container.Children.IndexOf(sender as TextBox);
                    if (index < 72)
                        grd_container.Children[index + 9].Focus();
                    break;
                case Key.Left:
                    index = grd_container.Children.IndexOf(sender as TextBox);
                    if (index > 0)
                        grd_container.Children[index - 1].Focus();
                    break;
                case Key.Right:
                case Key.Enter:
                    index = grd_container.Children.IndexOf(sender as TextBox);
                    if (index < 80)
                        grd_container.Children[index + 1].Focus();
                    break;
            }
            e.Handled = true;
        }


        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            switch (CheckInput())
            {
                case MatrexState.Invaled:
                    MessageBox.Show("Invalid input");
                    break;
                case MatrexState.Solved:
                    MessageBox.Show("SOLVED");
                    break;
            }
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            switch (CheckInput())
            {
                case MatrexState.Invaled:
                    MessageBox.Show("Invalid input");
                    break;
                case MatrexState.Solved:
                    MessageBox.Show("SOLVED");
                    break;
                case MatrexState.Chalange:
                    SolveMatrex();
                    break;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox item in grd_container.Children)
                item.Text = "";
        }

        private void ClearRowButton_MouseLeave(object sender, MouseEventArgs e)
        {
            HideItem(sender as Button);
        }

        private void ClearRowButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender != btm_clear)
                HideItem(btm_clear);
            foreach (Button i in grd_clr_columns.Children)
            {
                if (i == sender)
                    continue;
                else
                    HideItem(i);
            }
            foreach (Button i in grd_clr_rows.Children)
            {
                if (i == sender)
                    continue;
                else
                    HideItem(i);
            }
            ShowItem(sender as Button);
        }

        private void ShowItem(Button item)
        {
            if (item.Opacity < 0.95)
            {
                DoubleAnimation da = new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(100)));
                item.BeginAnimation(OpacityProperty, da);
            }
        }

        private void HideItem(Button item)
        {
            if (item.Opacity > 0.05)
            {
                DoubleAnimation da = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(100)));
                item.BeginAnimation(OpacityProperty, da);
            }
        }

        private void ClearColumnButton_Click(object sender, RoutedEventArgs e)
        {
            int j = 0;
            for (int i = grd_clr_columns.Children.IndexOf(sender as Button); j < 9; j++)
            {
                (grd_container.Children[i] as TextBox).Text = "";
                i += 9;
            }
        }

        private void ClearRowButton_Click(object sender, RoutedEventArgs e)
        {
            int j = 0;
            for (int i = 9 * grd_clr_rows.Children.IndexOf(sender as Button); j < 9; j++)
            {
                (grd_container.Children[i] as TextBox).Text = "";
                i++;
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            string text = "";
            int counter = 0;
            foreach (TextBox i in grd_container.Children)
            {
                if (i.Text != "")
                    text += i.Text + (counter < 80 ? ((counter+1) % 9 == 0 && counter > 0) ? "\r\n" : "\t" : "");
                else
                    text += "?" + (counter < 80 ? ((counter+1) % 9 == 0 && counter > 0) ? "\r\n" : "\t" : "");
                counter++;
            }
            Clipboard.SetText(text);
        }

        private void PasteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                string tmp = Clipboard.GetText(TextDataFormat.Text);
                if (tmp.Length < 1024)
                {
                    string nums = "";
                    string h = "0123456789?";
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (h.Contains(tmp[i]))
                        {
                            if (tmp[i] == '0')
                                nums += '?';
                            else
                                nums += tmp[i];
                            if (nums.Length == 81)
                                break;
                        }
                    }

                    if (nums.Length == 81)
                        for (int i = 0; i < 81; i++)
                            (grd_container.Children[i] as TextBox).Text = nums[i].ToString();

                }
                else
                    MessageBox.Show("Clipboard contains too long text");
            }
        }
    }

    enum MatrexState
    {
        Unknown = 0,
        Chalange = 1,
        Invaled = 2,
        Solved = 3
    }
}
