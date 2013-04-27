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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        class Box
        {
            public byte x, y, bigboxX, bigboxY, smallboxX, smallboxY, number;

            public Box(byte x, byte y, byte bigboxX, byte bigboxY, byte smallboxX, byte smallboxY, byte number)
            {
                this.x = x;
                this.y = y;
                this.bigboxX = bigboxX;
                this.bigboxY = bigboxY;
                this.smallboxX = smallboxX;
                this.smallboxY = smallboxY;
                this.number = number;
            }
        }

        Byte[,] Arr = new Byte[9, 9];
        Byte[,][,] Arr3x3 = new byte[3, 3][,];
        Byte[,] basicArr = new Byte[9, 9];
        Byte[,][,] basicArr3x3 = new byte[3, 3][,];
        bool? Solved = null;
        List<byte> takedNumber = new List<byte>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FullBasicArr()
        {
            Byte.TryParse(textBox1.Text, out basicArr[0, 0]);
            Byte.TryParse(textBox2.Text, out basicArr[0, 1]);
            Byte.TryParse(textBox3.Text, out basicArr[0, 2]);
            Byte.TryParse(textBox4.Text, out basicArr[0, 3]);
            Byte.TryParse(textBox5.Text, out basicArr[0, 4]);
            Byte.TryParse(textBox6.Text, out basicArr[0, 5]);
            Byte.TryParse(textBox7.Text, out basicArr[0, 6]);
            Byte.TryParse(textBox8.Text, out basicArr[0, 7]);
            Byte.TryParse(textBox9.Text, out basicArr[0, 8]);
            Byte.TryParse(textBox10.Text, out basicArr[1, 0]);
            Byte.TryParse(textBox11.Text, out basicArr[1, 1]);
            Byte.TryParse(textBox12.Text, out basicArr[1, 2]);
            Byte.TryParse(textBox13.Text, out basicArr[1, 3]);
            Byte.TryParse(textBox14.Text, out basicArr[1, 4]);
            Byte.TryParse(textBox15.Text, out basicArr[1, 5]);
            Byte.TryParse(textBox16.Text, out basicArr[1, 6]);
            Byte.TryParse(textBox17.Text, out basicArr[1, 7]);
            Byte.TryParse(textBox18.Text, out basicArr[1, 8]);
            Byte.TryParse(textBox19.Text, out basicArr[2, 0]);
            Byte.TryParse(textBox20.Text, out basicArr[2, 1]);
            Byte.TryParse(textBox21.Text, out basicArr[2, 2]);
            Byte.TryParse(textBox22.Text, out basicArr[2, 3]);
            Byte.TryParse(textBox23.Text, out basicArr[2, 4]);
            Byte.TryParse(textBox24.Text, out basicArr[2, 5]);
            Byte.TryParse(textBox25.Text, out basicArr[2, 6]);
            Byte.TryParse(textBox26.Text, out basicArr[2, 7]);
            Byte.TryParse(textBox27.Text, out basicArr[2, 8]);
            Byte.TryParse(textBox28.Text, out basicArr[3, 0]);
            Byte.TryParse(textBox29.Text, out basicArr[3, 1]);
            Byte.TryParse(textBox30.Text, out basicArr[3, 2]);
            Byte.TryParse(textBox31.Text, out basicArr[3, 3]);
            Byte.TryParse(textBox32.Text, out basicArr[3, 4]);
            Byte.TryParse(textBox33.Text, out basicArr[3, 5]);
            Byte.TryParse(textBox34.Text, out basicArr[3, 6]);
            Byte.TryParse(textBox35.Text, out basicArr[3, 7]);
            Byte.TryParse(textBox36.Text, out basicArr[3, 8]);
            Byte.TryParse(textBox37.Text, out basicArr[4, 0]);
            Byte.TryParse(textBox38.Text, out basicArr[4, 1]);
            Byte.TryParse(textBox39.Text, out basicArr[4, 2]);
            Byte.TryParse(textBox40.Text, out basicArr[4, 3]);
            Byte.TryParse(textBox41.Text, out basicArr[4, 4]);
            Byte.TryParse(textBox42.Text, out basicArr[4, 5]);
            Byte.TryParse(textBox43.Text, out basicArr[4, 6]);
            Byte.TryParse(textBox44.Text, out basicArr[4, 7]);
            Byte.TryParse(textBox45.Text, out basicArr[4, 8]);
            Byte.TryParse(textBox46.Text, out basicArr[5, 0]);
            Byte.TryParse(textBox47.Text, out basicArr[5, 1]);
            Byte.TryParse(textBox48.Text, out basicArr[5, 2]);
            Byte.TryParse(textBox49.Text, out basicArr[5, 3]);
            Byte.TryParse(textBox50.Text, out basicArr[5, 4]);
            Byte.TryParse(textBox51.Text, out basicArr[5, 5]);
            Byte.TryParse(textBox52.Text, out basicArr[5, 6]);
            Byte.TryParse(textBox53.Text, out basicArr[5, 7]);
            Byte.TryParse(textBox54.Text, out basicArr[5, 8]);
            Byte.TryParse(textBox55.Text, out basicArr[6, 0]);
            Byte.TryParse(textBox56.Text, out basicArr[6, 1]);
            Byte.TryParse(textBox57.Text, out basicArr[6, 2]);
            Byte.TryParse(textBox58.Text, out basicArr[6, 3]);
            Byte.TryParse(textBox59.Text, out basicArr[6, 4]);
            Byte.TryParse(textBox60.Text, out basicArr[6, 5]);
            Byte.TryParse(textBox61.Text, out basicArr[6, 6]);
            Byte.TryParse(textBox62.Text, out basicArr[6, 7]);
            Byte.TryParse(textBox63.Text, out basicArr[6, 8]);
            Byte.TryParse(textBox64.Text, out basicArr[7, 0]);
            Byte.TryParse(textBox65.Text, out basicArr[7, 1]);
            Byte.TryParse(textBox66.Text, out basicArr[7, 2]);
            Byte.TryParse(textBox67.Text, out basicArr[7, 3]);
            Byte.TryParse(textBox68.Text, out basicArr[7, 4]);
            Byte.TryParse(textBox69.Text, out basicArr[7, 5]);
            Byte.TryParse(textBox70.Text, out basicArr[7, 6]);
            Byte.TryParse(textBox71.Text, out basicArr[7, 7]);
            Byte.TryParse(textBox72.Text, out basicArr[7, 8]);
            Byte.TryParse(textBox73.Text, out basicArr[8, 0]);
            Byte.TryParse(textBox74.Text, out basicArr[8, 1]);
            Byte.TryParse(textBox75.Text, out basicArr[8, 2]);
            Byte.TryParse(textBox76.Text, out basicArr[8, 3]);
            Byte.TryParse(textBox77.Text, out basicArr[8, 4]);
            Byte.TryParse(textBox78.Text, out basicArr[8, 5]);
            Byte.TryParse(textBox79.Text, out basicArr[8, 6]);
            Byte.TryParse(textBox80.Text, out basicArr[8, 7]);
            Byte.TryParse(textBox81.Text, out basicArr[8, 8]);

            Byte.TryParse(textBox1.Text, out basicArr3x3[0, 0][0, 0]);
            Byte.TryParse(textBox2.Text, out basicArr3x3[0, 0][0, 1]);
            Byte.TryParse(textBox3.Text, out basicArr3x3[0, 0][0, 2]);
            Byte.TryParse(textBox10.Text, out basicArr3x3[0, 0][1, 0]);
            Byte.TryParse(textBox11.Text, out basicArr3x3[0, 0][1, 1]);
            Byte.TryParse(textBox12.Text, out basicArr3x3[0, 0][1, 2]);
            Byte.TryParse(textBox19.Text, out basicArr3x3[0, 0][2, 0]);
            Byte.TryParse(textBox20.Text, out basicArr3x3[0, 0][2, 1]);
            Byte.TryParse(textBox21.Text, out basicArr3x3[0, 0][2, 2]);
            Byte.TryParse(textBox4.Text, out basicArr3x3[0, 1][0, 0]);
            Byte.TryParse(textBox5.Text, out basicArr3x3[0, 1][0, 1]);
            Byte.TryParse(textBox6.Text, out basicArr3x3[0, 1][0, 2]);
            Byte.TryParse(textBox13.Text, out basicArr3x3[0, 1][1, 0]);
            Byte.TryParse(textBox14.Text, out basicArr3x3[0, 1][1, 1]);
            Byte.TryParse(textBox15.Text, out basicArr3x3[0, 1][1, 2]);
            Byte.TryParse(textBox22.Text, out basicArr3x3[0, 1][2, 0]);
            Byte.TryParse(textBox23.Text, out basicArr3x3[0, 1][2, 1]);
            Byte.TryParse(textBox24.Text, out basicArr3x3[0, 1][2, 2]);
            Byte.TryParse(textBox7.Text, out basicArr3x3[0, 2][0, 0]);
            Byte.TryParse(textBox8.Text, out basicArr3x3[0, 2][0, 1]);
            Byte.TryParse(textBox9.Text, out basicArr3x3[0, 2][0, 2]);
            Byte.TryParse(textBox16.Text, out basicArr3x3[0, 2][1, 0]);
            Byte.TryParse(textBox17.Text, out basicArr3x3[0, 2][1, 1]);
            Byte.TryParse(textBox18.Text, out basicArr3x3[0, 2][1, 2]);
            Byte.TryParse(textBox25.Text, out basicArr3x3[0, 2][2, 0]);
            Byte.TryParse(textBox26.Text, out basicArr3x3[0, 2][2, 1]);
            Byte.TryParse(textBox27.Text, out basicArr3x3[0, 2][2, 2]);
            Byte.TryParse(textBox28.Text, out basicArr3x3[1, 0][0, 0]);
            Byte.TryParse(textBox29.Text, out basicArr3x3[1, 0][0, 1]);
            Byte.TryParse(textBox30.Text, out basicArr3x3[1, 0][0, 2]);
            Byte.TryParse(textBox37.Text, out basicArr3x3[1, 0][1, 0]);
            Byte.TryParse(textBox38.Text, out basicArr3x3[1, 0][1, 1]);
            Byte.TryParse(textBox39.Text, out basicArr3x3[1, 0][1, 2]);
            Byte.TryParse(textBox46.Text, out basicArr3x3[1, 0][2, 0]);
            Byte.TryParse(textBox47.Text, out basicArr3x3[1, 0][2, 1]);
            Byte.TryParse(textBox48.Text, out basicArr3x3[1, 0][2, 2]);
            Byte.TryParse(textBox31.Text, out basicArr3x3[1, 1][0, 0]);
            Byte.TryParse(textBox32.Text, out basicArr3x3[1, 1][0, 1]);
            Byte.TryParse(textBox33.Text, out basicArr3x3[1, 1][0, 2]);
            Byte.TryParse(textBox40.Text, out basicArr3x3[1, 1][1, 0]);
            Byte.TryParse(textBox41.Text, out basicArr3x3[1, 1][1, 1]);
            Byte.TryParse(textBox42.Text, out basicArr3x3[1, 1][1, 2]);
            Byte.TryParse(textBox49.Text, out basicArr3x3[1, 1][2, 0]);
            Byte.TryParse(textBox50.Text, out basicArr3x3[1, 1][2, 1]);
            Byte.TryParse(textBox51.Text, out basicArr3x3[1, 1][2, 2]);
            Byte.TryParse(textBox34.Text, out basicArr3x3[1, 2][0, 0]);
            Byte.TryParse(textBox35.Text, out basicArr3x3[1, 2][0, 1]);
            Byte.TryParse(textBox36.Text, out basicArr3x3[1, 2][0, 2]);
            Byte.TryParse(textBox43.Text, out basicArr3x3[1, 2][1, 0]);
            Byte.TryParse(textBox44.Text, out basicArr3x3[1, 2][1, 1]);
            Byte.TryParse(textBox45.Text, out basicArr3x3[1, 2][1, 2]);
            Byte.TryParse(textBox52.Text, out basicArr3x3[1, 2][2, 0]);
            Byte.TryParse(textBox53.Text, out basicArr3x3[1, 2][2, 1]);
            Byte.TryParse(textBox54.Text, out basicArr3x3[1, 2][2, 2]);
            Byte.TryParse(textBox55.Text, out basicArr3x3[2, 0][0, 0]);
            Byte.TryParse(textBox56.Text, out basicArr3x3[2, 0][0, 1]);
            Byte.TryParse(textBox57.Text, out basicArr3x3[2, 0][0, 2]);
            Byte.TryParse(textBox64.Text, out basicArr3x3[2, 0][1, 0]);
            Byte.TryParse(textBox65.Text, out basicArr3x3[2, 0][1, 1]);
            Byte.TryParse(textBox66.Text, out basicArr3x3[2, 0][1, 2]);
            Byte.TryParse(textBox73.Text, out basicArr3x3[2, 0][2, 0]);
            Byte.TryParse(textBox74.Text, out basicArr3x3[2, 0][2, 1]);
            Byte.TryParse(textBox75.Text, out basicArr3x3[2, 0][2, 2]);
            Byte.TryParse(textBox58.Text, out basicArr3x3[2, 1][0, 0]);
            Byte.TryParse(textBox59.Text, out basicArr3x3[2, 1][0, 1]);
            Byte.TryParse(textBox60.Text, out basicArr3x3[2, 1][0, 2]);
            Byte.TryParse(textBox67.Text, out basicArr3x3[2, 1][1, 0]);
            Byte.TryParse(textBox68.Text, out basicArr3x3[2, 1][1, 1]);
            Byte.TryParse(textBox69.Text, out basicArr3x3[2, 1][1, 2]);
            Byte.TryParse(textBox76.Text, out basicArr3x3[2, 1][2, 0]);
            Byte.TryParse(textBox77.Text, out basicArr3x3[2, 1][2, 1]);
            Byte.TryParse(textBox78.Text, out basicArr3x3[2, 1][2, 2]);
            Byte.TryParse(textBox61.Text, out basicArr3x3[2, 2][0, 0]);
            Byte.TryParse(textBox62.Text, out basicArr3x3[2, 2][0, 1]);
            Byte.TryParse(textBox63.Text, out basicArr3x3[2, 2][0, 2]);
            Byte.TryParse(textBox70.Text, out basicArr3x3[2, 2][1, 0]);
            Byte.TryParse(textBox71.Text, out basicArr3x3[2, 2][1, 1]);
            Byte.TryParse(textBox72.Text, out basicArr3x3[2, 2][1, 0]);
            Byte.TryParse(textBox79.Text, out basicArr3x3[2, 2][2, 0]);
            Byte.TryParse(textBox80.Text, out basicArr3x3[2, 2][2, 1]);
            Byte.TryParse(textBox81.Text, out basicArr3x3[2, 2][2, 2]);
        }

        #region Stage 1
        private void Number_Of_Iteration(out Byte[] Iteration)
        {
            Iteration = new Byte[10];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (Arr[i, j] > 0)
                        Iteration[Arr[i, j]]++;
        }

        private Byte Max_Iteration(Byte[] Iteration, byte minNumber)
        {
            Byte maxiteration = 0;
            for (Byte i = 1; i < 10; i++)
                if (Iteration[i] > Iteration[maxiteration] && !(takedNumber.Contains(i)))
                    maxiteration = i;
            if (Iteration[maxiteration] >= minNumber)
            {
                takedNumber.Add(maxiteration);
                return maxiteration;
            }
            throw new Exception("Cannot Be Solved");
        }

        private List<byte> DonotContainsn(byte n)
        {
            List<Byte> boxes = new List<byte>();
            List<Byte> notboxes = new List<byte>();
            Byte index = 1;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                        for (int l = 0; l < 3; l++)
                            if (Arr3x3[i, j][k, l] == n)
                                boxes.Add(index);
                    index++;
                }
            for (byte i = 1; i < 10; i++)
                if (!boxes.Contains(i))
                    notboxes.Add(i);
            return notboxes;
        }

        private bool[,] PossibleNumbers(byte n, byte index, byte row, byte column)
        {
            byte x, y;
            byte indexX, indexY;
            FirstIndexes9x9(index, out indexX, out indexY);
            int x1 = indexX, x2 = indexX + 1, x3 = indexX + 2;
            int y1 = indexY, y2 = indexY + 1, y3 = indexY + 2;
            bool[,] possibleNumbers = new bool[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    possibleNumbers[i, j] = true;
            Indexes(index, out x, out y);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Arr3x3[x, y][i, j] > 0)
                        possibleNumbers[i, j] = false;
            for (int i = 0; i < 9; i++)
                if (Arr[x1, i] == n)
                { possibleNumbers[0, 0] = false; possibleNumbers[0, 1] = false; possibleNumbers[0, 2] = false; break; }
            for (int i = 0; i < 9; i++)
                if (Arr[x2, i] == n)
                { possibleNumbers[1, 0] = false; possibleNumbers[1, 1] = false; possibleNumbers[1, 2] = false; break; }
            for (int i = 0; i < 9; i++)
                if (Arr[x3, i] == n)
                { possibleNumbers[2, 0] = false; possibleNumbers[2, 1] = false; possibleNumbers[2, 2] = false; break; }
            for (int i = 0; i < 9; i++)
                if (Arr[i, y1] == n)
                { possibleNumbers[0, 0] = false; possibleNumbers[1, 0] = false; possibleNumbers[2, 0] = false; break; }
            for (int i = 0; i < 9; i++)
                if (Arr[i, y2] == n)
                { possibleNumbers[0, 1] = false; possibleNumbers[1, 1] = false; possibleNumbers[2, 1] = false; break; }
            for (int i = 0; i < 9; i++)
                if (Arr[i, y3] == n)
                { possibleNumbers[0, 2] = false; possibleNumbers[1, 2] = false; possibleNumbers[2, 2] = false; break; }
            return possibleNumbers;
        }

        private byte NumberOfPosible(bool[,] possibleNumbers)
        {
            byte numberOfPosible = 0;
            foreach (var i in possibleNumbers)
                if (i)
                    numberOfPosible++;
            return numberOfPosible;
        }

        private void Indexes(byte index, out byte x, out byte y)
        {
            if (index == 1) { x = 0; y = 0; return; }
            if (index == 2) { x = 0; y = 1; return; }
            if (index == 3) { x = 0; y = 2; return; }
            if (index == 4) { x = 1; y = 0; return; }
            if (index == 5) { x = 1; y = 1; return; }
            if (index == 6) { x = 1; y = 2; return; }
            if (index == 7) { x = 2; y = 0; return; }
            if (index == 8) { x = 2; y = 1; return; }
            if (index == 9) { x = 2; y = 2; return; }
            throw new Exception("");
        }

        private void FirstIndexes9x9(byte numberOfArr3x3, out byte indexX, out byte indexY)
        {
            if (numberOfArr3x3 == 1) { indexX = 0; indexY = 0; }
            else if (numberOfArr3x3 == 2) { indexX = 0; indexY = 3; }
            else if (numberOfArr3x3 == 3) { indexX = 0; indexY = 6; }
            else if (numberOfArr3x3 == 4) { indexX = 3; indexY = 0; }
            else if (numberOfArr3x3 == 5) { indexX = 3; indexY = 3; }
            else if (numberOfArr3x3 == 6) { indexX = 3; indexY = 6; }
            else if (numberOfArr3x3 == 7) { indexX = 6; indexY = 0; }
            else if (numberOfArr3x3 == 8) { indexX = 6; indexY = 3; }
            else if (numberOfArr3x3 == 9) { indexX = 6; indexY = 6; }
            else { indexX = 0; indexY = 0; }
        }

        private void FirstStage()
        {
            int iter = 0;
            while (iter < 100)
            {
                takedNumber.Clear();
                byte[] numberOfIteration;
                Number_Of_Iteration(out numberOfIteration);
                byte[] numberOfIterationSorted;
                Number_Of_Iteration(out numberOfIterationSorted);
                List<Byte> listOfnumberOfIterationSorted = numberOfIterationSorted.ToList<Byte>();
                listOfnumberOfIterationSorted.Sort();
                int Iteration = 9;
                do
                {
                    byte inwork = Max_Iteration(numberOfIteration, listOfnumberOfIterationSorted[Iteration]);
                    List<Byte> donotContainsn = DonotContainsn(inwork);
                    for (int i = 0; i < donotContainsn.Count; i++)
                    {
                        byte x, y;//احداثيات المصفوفة الحاوية على n
                        byte indexX, IndexY;//احداثيات الرقم n
                        Indexes(donotContainsn[i], out x, out y);
                        Indexfrom3x3(inwork, donotContainsn[i], Arr3x3[x, y], out indexX, out IndexY);
                        if (NumberOfPosible(PossibleNumbers(inwork, donotContainsn[i], x, y)) == 1)
                        {
                            var possiblePosition = PossibleNumbers(inwork, donotContainsn[i], indexX, IndexY);
                            byte newnumberX = 0, newnumberY = 0;
                            for (byte j = 0; j < 3; j++)
                                for (byte k = 0; k < 3; k++)
                                    if (possiblePosition[j, k])
                                    {
                                        newnumberX = j;
                                        newnumberY = k;
                                        break;
                                    }
                            Arr3x3[x, y][newnumberX, newnumberY] = inwork;
                            Arr[x * 3 + newnumberX, y * 3 + newnumberY] = inwork;
                        }
                    }
                    Iteration--;
                } while (takedNumber.Count < 9);
                iter++;
            }
        }
        #endregion

        #region Stage 2
        private byte NumberOfZero(List<Byte> List)
        {
            byte numberOfZero = 0;
            foreach (var i in List)
                if (i == 0)
                    numberOfZero++;
            return numberOfZero;
        }

        private List<Byte> MissingNumbers(List<Byte> List)
        {
            List<Byte> missingNumbers = new List<byte>();
            for (byte i = 1; i < 10; i++)
                if (!List.Contains(i))
                    missingNumbers.Add(i);
            return missingNumbers;
        }

        private float NumberWithPosition(List<Byte> MissingNumber, List<Box> missingNumberPosition, out List<Box> numberWithPosition)
        {
            numberWithPosition = new List<Box>();
            byte Done = 0;
            byte number = 0;
            List<Box> possiblenumberWithPosition = new List<Box>();
            for (int k = 0; k < 100; k++)
                foreach (var x in missingNumberPosition)
                {
                    foreach (var i in MissingNumber)
                    {
                        bool accept = true;
                        foreach (var j in Arr3x3[x.bigboxX, x.bigboxY])
                            if (i == j) { accept = false; break; }
                        for (byte j = 0; j < 9; j++)
                            if (i == Arr[x.x, j]) { accept = false; break; }
                        for (byte j = 0; j < 9; j++)
                            if (i == Arr[j, x.y]) { accept = false; break; }
                        if (accept)
                        {
                            number = i;
                            x.number = i;
                            possiblenumberWithPosition.Add(x);
                        }
                    }
                    if (possiblenumberWithPosition.Count == 1)
                    {
                        Done++;
                        x.number = number;
                        numberWithPosition.Add(x);
                    }
                }
            //نسبة الأرقام الموضوعة في أماكنها
            float rate = Done / (missingNumberPosition.Count + 2) * 100;
            return rate;
        }

        private void SocendSatge()
        {
            List<Byte> boxNumbers = new List<byte>();
            for (byte i = 0; i < 9; i++)
            {
                boxNumbers.Clear();
                List<Box> missingNumberPosition = new List<Box>();
                for (byte j = 0; j < 9; j++)
                {
                    boxNumbers.Add(Arr[i, j]);
                    if (Arr[i, j] == 0)
                    {
                        Box x1 = new Box(i, j, (Byte)(i / 3), (Byte)(j / 3), (Byte)(i % 3), (Byte)(i % 3), 0);
                        missingNumberPosition.Add(x1);
                    }
                }
                byte numberOfZero = NumberOfZero(boxNumbers);
                List<Byte> missingNumbers = MissingNumbers(boxNumbers);
                List<Box> numberWithPosition;
                NumberWithPosition(missingNumbers, missingNumberPosition, out numberWithPosition);
                foreach (var k in numberWithPosition)
                {
                    Arr[k.x, k.y] = k.number;
                    Arr3x3[k.bigboxX, k.bigboxY][k.smallboxX, k.smallboxY] = k.number;
                }
            }
        }
        #endregion

        private void Clear()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    Arr[i, j] = basicArr[i, j];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        for (int l = 0; l < 3; l++)
                            Arr3x3[i, j][k, l] = basicArr3x3[i, j][k, l];
        }

        private void Print()
        {
            textBox1.Text = Arr[0, 0].ToString();
            textBox2.Text = Arr[0, 1].ToString();
            textBox3.Text = Arr[0, 2].ToString();
            textBox4.Text = Arr[0, 3].ToString();
            textBox5.Text = Arr[0, 4].ToString();
            textBox6.Text = Arr[0, 5].ToString();
            textBox7.Text = Arr[0, 6].ToString();
            textBox8.Text = Arr[0, 7].ToString();
            textBox9.Text = Arr[0, 8].ToString();
            textBox10.Text = Arr[1, 0].ToString();
            textBox11.Text = Arr[1, 1].ToString();
            textBox12.Text = Arr[1, 2].ToString();
            textBox13.Text = Arr[1, 3].ToString();
            textBox14.Text = Arr[1, 4].ToString();
            textBox15.Text = Arr[1, 5].ToString();
            textBox16.Text = Arr[1, 6].ToString();
            textBox17.Text = Arr[1, 7].ToString();
            textBox18.Text = Arr[1, 8].ToString();
            textBox19.Text = Arr[2, 0].ToString();
            textBox20.Text = Arr[2, 1].ToString();
            textBox21.Text = Arr[2, 2].ToString();
            textBox22.Text = Arr[2, 3].ToString();
            textBox23.Text = Arr[2, 4].ToString();
            textBox24.Text = Arr[2, 5].ToString();
            textBox25.Text = Arr[2, 6].ToString();
            textBox26.Text = Arr[2, 7].ToString();
            textBox27.Text = Arr[2, 8].ToString();
            textBox28.Text = Arr[3, 0].ToString();
            textBox29.Text = Arr[3, 1].ToString();
            textBox30.Text = Arr[3, 2].ToString();
            textBox31.Text = Arr[3, 3].ToString();
            textBox32.Text = Arr[3, 4].ToString();
            textBox33.Text = Arr[3, 5].ToString();
            textBox34.Text = Arr[3, 6].ToString();
            textBox35.Text = Arr[3, 7].ToString();
            textBox36.Text = Arr[3, 8].ToString();
            textBox37.Text = Arr[4, 0].ToString();
            textBox38.Text = Arr[4, 1].ToString();
            textBox39.Text = Arr[4, 2].ToString();
            textBox40.Text = Arr[4, 3].ToString();
            textBox41.Text = Arr[4, 4].ToString();
            textBox42.Text = Arr[4, 5].ToString();
            textBox43.Text = Arr[4, 6].ToString();
            textBox44.Text = Arr[4, 7].ToString();
            textBox45.Text = Arr[4, 8].ToString();
            textBox46.Text = Arr[5, 0].ToString();
            textBox47.Text = Arr[5, 1].ToString();
            textBox48.Text = Arr[5, 2].ToString();
            textBox49.Text = Arr[5, 3].ToString();
            textBox50.Text = Arr[5, 4].ToString();
            textBox51.Text = Arr[5, 5].ToString();
            textBox52.Text = Arr[5, 6].ToString();
            textBox53.Text = Arr[5, 7].ToString();
            textBox54.Text = Arr[5, 8].ToString();
            textBox55.Text = Arr[6, 0].ToString();
            textBox56.Text = Arr[6, 1].ToString();
            textBox57.Text = Arr[6, 2].ToString();
            textBox58.Text = Arr[6, 3].ToString();
            textBox59.Text = Arr[6, 4].ToString();
            textBox60.Text = Arr[6, 5].ToString();
            textBox61.Text = Arr[6, 6].ToString();
            textBox62.Text = Arr[6, 7].ToString();
            textBox63.Text = Arr[6, 8].ToString();
            textBox64.Text = Arr[7, 0].ToString();
            textBox65.Text = Arr[7, 1].ToString();
            textBox66.Text = Arr[7, 2].ToString();
            textBox67.Text = Arr[7, 3].ToString();
            textBox68.Text = Arr[7, 4].ToString();
            textBox69.Text = Arr[7, 5].ToString();
            textBox70.Text = Arr[7, 6].ToString();
            textBox71.Text = Arr[7, 7].ToString();
            textBox72.Text = Arr[7, 8].ToString();
            textBox73.Text = Arr[8, 0].ToString();
            textBox74.Text = Arr[8, 1].ToString();
            textBox75.Text = Arr[8, 2].ToString();
            textBox76.Text = Arr[8, 3].ToString();
            textBox77.Text = Arr[8, 4].ToString();
            textBox78.Text = Arr[8, 5].ToString();
            textBox79.Text = Arr[8, 6].ToString();
            textBox80.Text = Arr[8, 7].ToString();
            textBox81.Text = Arr[8, 8].ToString();
        }

        private bool NotExist(Byte[] Array, byte toCheak)
        {
            for (int i = 0; i < Array.Length; i++)
                if (Array[i] == toCheak)
                    return false;
            return true;
        }

        private void Indexfrom3x3(byte n, byte index, byte[,] Array, out byte x, out byte y)
        {
            x = 0; y = 0;
            for (byte i = 0; i < 3; i++)
                for (byte j = 0; j < 3; j++)
                    if (Array[i, j] == n)
                    { x = i; y = j; }
            byte tmpx, tmpy;
            Indexes(index, out tmpx, out tmpy);
            x = (Byte)(x + 3 * tmpx);
            y = (Byte)(y + 3 * tmpy);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox38.Text = "";
            textBox39.Text = "";
            textBox40.Text = "";
            textBox41.Text = "";
            textBox42.Text = "";
            textBox43.Text = "";
            textBox44.Text = "";
            textBox45.Text = "";
            textBox46.Text = "";
            textBox47.Text = "";
            textBox48.Text = "";
            textBox49.Text = "";
            textBox50.Text = "";
            textBox51.Text = "";
            textBox52.Text = "";
            textBox53.Text = "";
            textBox54.Text = "";
            textBox55.Text = "";
            textBox56.Text = "";
            textBox57.Text = "";
            textBox58.Text = "";
            textBox59.Text = "";
            textBox60.Text = "";
            textBox61.Text = "";
            textBox62.Text = "";
            textBox63.Text = "";
            textBox64.Text = "";
            textBox65.Text = "";
            textBox66.Text = "";
            textBox67.Text = "";
            textBox68.Text = "";
            textBox69.Text = "";
            textBox70.Text = "";
            textBox71.Text = "";
            textBox72.Text = "";
            textBox73.Text = "";
            textBox74.Text = "";
            textBox75.Text = "";
            textBox76.Text = "";
            textBox77.Text = "";
            textBox78.Text = "";
            textBox79.Text = "";
            textBox80.Text = "";
            textBox81.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int k = 0; k < 10; k++)
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        Arr3x3[i, j] = new Byte[3, 3];
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        basicArr3x3[i, j] = new Byte[3, 3];
                FullBasicArr();
                Clear();
                FirstStage();
                SocendSatge();
                Print();
            }
        }
    }
}
