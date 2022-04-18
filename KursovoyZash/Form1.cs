using System.Globalization;
using System.Text;

namespace KursovoyZash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
        }

        const int cells = 5;                                    //количество блоков в ключе
        const int column = 8;                                   //количество ячеек в ключе
        const int blockLength = 40;                             //длинна блока ключа
        const int maxBit = 80;                                  //максимальная длина текста в битах
        const int bit = 8;                                      //количество битов в байте
        const int P = 9;                                        //переменная определяющая количество ключей

        int[,] K1 = new int[cells, column];
        int[,] K2 = new int[cells, column];
        int[,] K3 = new int[cells, column];
        int[,] K4 = new int[cells, column];
        int[,] K5 = new int[cells, column];
        int[,] K6 = new int[cells, column];
        int[,] K7 = new int[cells, column];
        int[,] K8 = new int[cells, column];
        int[,] newK = new int[P, blockLength];
        int reserveHighBit = maxBit - bit;
        int reserveLowBit = maxBit - bit / 2;
        string highBit = "";
        string lowBit = "";
        string[] textBlock1 = new string[maxBit];
        int[] textBlock2 = new int[maxBit];
        int[,] L = new int[P, blockLength];
        int[,] R = new int[P, blockLength];
        int[,] F = new int[P, blockLength];
        int[] L0 = new int[blockLength];
        int[] R0 = new int[blockLength];
        int[] L8 = new int[blockLength];
        int[] R8 = new int[blockLength];
        string encryption = "";
        int[] binaryEncryption = new int[maxBit];

        string s = "";
        string s2 = "";
        string[] kir = new string[32];
        string binaryCode1 = "";

        private void Form1_Load(object sender, EventArgs e)
        {


            char ch;
            int n = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 1072; i <= 1103; i++)
            {
                ch = System.Convert.ToChar(i);
                kir[n] = Convert.ToString(ch);
                n++;
            }
        }
        public string Crutch(string str, int maxSymbols)       //функция первода бинарного текста в текст
        {
            string[] subs = str.Split(5).ToArray();
            string[] otvetbukv = new string[subs.Length];
            int[] otvetcifr = new int[subs.Length];
            string finalEncryption = "";
            for (int i = 0; i < subs.Length; i++)
            {
                int _int = Convert.ToInt32(subs[i], 2);
                otvetbukv[i] = Convert.ToString(_int, 10);
                otvetcifr[i] = Convert.ToInt32(otvetbukv[i]);

            }
            for (int i = 0; i < otvetcifr.Length; i++)
            {
                for (int j = 0; j < kir.Length; j++)
                {
                    if (otvetcifr[i] == j)
                    {
                        finalEncryption = finalEncryption.Insert(finalEncryption.Length, Convert.ToString(kir[j]));
                    }
                }
            }
            return finalEncryption;
        }


        private string Coding(string str)
        {
            string binaryCode = "";
            int[] TT = new int[str.Length];
            string[] KT = new string[str.Length];
            string ResStr = str.ToLower(new CultureInfo("ru-RU", false));
            char[] b = ResStr.ToCharArray();
            for (int i = 0; i < b.Length; i++)
            {
                KT[i] = Convert.ToString(b[i]);
            }
            for (int i = 0; i < KT.Length; i++)
            {
                for (int j = 0; j < kir.Length; j++)
                {
                    if (KT[i] == kir[j])
                    {
                        TT[i] = j;
                    }
                }
            }

            foreach (int c in TT)
            {
                binaryCode = binaryCode.Insert(binaryCode.Length, Convert.ToString(c, 2).PadLeft(5, '0'));
            }

            return binaryCode;
        }


        private int[,] key(string binaryCode) //Создание ключей
        {
            string[] key = new string[binaryCode.Length];


            for (int i = 0; i < binaryCode.Length; i++)
            {
                key[i] = binaryCode[i].ToString();
            }
            int[,] K0 = new int[cells, column];
            int numberKey = column;
            int cellsKey = 0;
            int columnKey = 0;
            for (int i = 0; i < key.Length; i++)
            {
                if (i < numberKey)
                {
                    K0[cellsKey, columnKey] = Convert.ToInt32(key[i]);
                    columnKey++;
                }
                else
                {
                    numberKey = numberKey + column;
                    cellsKey++;
                    columnKey = 0;
                    i--;
                }
            }
            //преобразование P(E)=(a7,a5,a1,a6,a8,a3,a4,a2)
            for (int i = 0; i < cells; i++)
            {
                K1[i, 0] = K0[i, 6];
                K1[i, 1] = K0[i, 4];
                K1[i, 2] = K0[i, 0];
                K1[i, 3] = K0[i, 5];
                K1[i, 4] = K0[i, 7];
                K1[i, 5] = K0[i, 2];
                K1[i, 6] = K0[i, 3];
                K1[i, 7] = K0[i, 1];

                K2[i, 0] = K1[i, 6];
                K2[i, 1] = K1[i, 4];
                K2[i, 2] = K1[i, 0];
                K2[i, 3] = K1[i, 5];
                K2[i, 4] = K1[i, 7];
                K2[i, 5] = K1[i, 2];
                K2[i, 6] = K1[i, 3];
                K2[i, 7] = K1[i, 1];

                K3[i, 0] = K2[i, 6];
                K3[i, 1] = K2[i, 4];
                K3[i, 2] = K2[i, 0];
                K3[i, 3] = K2[i, 5];
                K3[i, 4] = K2[i, 7];
                K3[i, 5] = K2[i, 2];
                K3[i, 6] = K2[i, 3];
                K3[i, 7] = K2[i, 1];

                K4[i, 0] = K3[i, 6];
                K4[i, 1] = K3[i, 4];
                K4[i, 2] = K3[i, 0];
                K4[i, 3] = K3[i, 5];
                K4[i, 4] = K3[i, 7];
                K4[i, 5] = K3[i, 2];
                K4[i, 6] = K3[i, 3];
                K4[i, 7] = K3[i, 1];

                K5[i, 0] = K4[i, 6];
                K5[i, 1] = K4[i, 4];
                K5[i, 2] = K4[i, 0];
                K5[i, 3] = K4[i, 5];
                K5[i, 4] = K4[i, 7];
                K5[i, 5] = K4[i, 2];
                K5[i, 6] = K4[i, 3];
                K5[i, 7] = K4[i, 1];


                K6[i, 0] = K5[i, 6];
                K6[i, 1] = K5[i, 4];
                K6[i, 2] = K5[i, 0];
                K6[i, 3] = K5[i, 5];
                K6[i, 4] = K5[i, 7];
                K6[i, 5] = K5[i, 2];
                K6[i, 6] = K5[i, 3];
                K6[i, 7] = K5[i, 1];

                K7[i, 0] = K6[i, 6];
                K7[i, 1] = K6[i, 4];
                K7[i, 2] = K6[i, 0];
                K7[i, 3] = K6[i, 5];
                K7[i, 4] = K6[i, 7];
                K7[i, 5] = K6[i, 2];
                K7[i, 6] = K6[i, 3];
                K7[i, 7] = K6[i, 1];

                K8[i, 0] = K7[i, 6];
                K8[i, 1] = K7[i, 4];
                K8[i, 2] = K7[i, 0];
                K8[i, 3] = K7[i, 5];
                K8[i, 4] = K7[i, 7];
                K8[i, 5] = K7[i, 2];
                K8[i, 6] = K7[i, 3];
                K8[i, 7] = K7[i, 1];
            }
            int q = 0;
            for (int i = 0; i < cells; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    newK[0, q] = K0[i, j];
                    newK[1, q] = K1[i, j];
                    newK[2, q] = K2[i, j];
                    newK[3, q] = K3[i, j];
                    newK[4, q] = K4[i, j];
                    newK[5, q] = K5[i, j];
                    newK[6, q] = K6[i, j];
                    newK[7, q] = K7[i, j];
                    newK[8, q] = K8[i, j];
                    q++;
                }
            }
            return newK;
        }

        private void encryption1(string s2) //Шифрование
        {

            string result = Coding(s2);
            string[] text = new string[result.Length];
            for (int i = 0; i < result.Length; i++)
            {
                text[i] = result[i].ToString();
            }
            int valueHighBit = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result.Length % bit == 0)
                {
                    break;
                }
                else
                {
                    result = result + "0";
                    valueHighBit++;
                }
            }
            int valueLowBit = (maxBit - result.Length) / bit;                 //значение младшего разряда
            for (int i = 0; i < result.Length; i++)
            {
                if (result.Length < maxBit)
                {
                    result = result + "0";
                }
                else
                {
                    break;
                }
            }
            highBit = Convert.ToString(valueHighBit, 2).PadLeft(4, '0');        //старший разряд
            lowBit = Convert.ToString(valueLowBit, 2).PadLeft(4, '0');          //младший разряд
            result = result.Substring(0, reserveHighBit);                 //резервируем последние 8 бит   
            result = result.Insert(reserveHighBit, highBit);             //дописываем в пустые ячейки массива нули
            result = result.Insert(reserveLowBit, lowBit);               //записываем остаток
            for (int i = 0; i < result.Length; i++)                                  //преобразование массива из char в Int64
            {
                textBlock1[i] = Convert.ToString(result[i]);
                textBlock2[i] = Convert.ToInt32(textBlock1[i]);
            }
            Array.Copy(textBlock2, 0, L0, 0, 40);
            Array.Copy(textBlock2, 40, R0, 0, 40);
            for (int i = 0; i < blockLength; i++)
            {
                L[0, i] = L0[i];
                R[0, i] = R0[i];
            }
            int[] L1 = new int[blockLength];
            int[] R1 = new int[blockLength];
            //R = x, K(i) = y, K(i - 1) = z
            //1+z+y+xz
            for (int i = 1; i < 9; i++)
            {
                for (int j = 0; j < blockLength; j++)
                {
                    F[i - 1, j] = (1 + newK[i - 1, j] + newK[i, j] + (R[i - 1, j] * newK[i - 1, j])) % 2;
                    L[i, j] = R[i - 1, j];
                    R[i, j] = (F[i - 1, j] + L[i - 1, j]) % 2;
                    R8[j] = R[7, j];
                    //R8[j] = L[8, j];
                    L8[j] = (F[i - 1, j] + L[i - 1, j]) % 2;
                    L1[j] = L[1, j];
                    R1[j] = R[1, j];
                }
            }
            encryption = "";
            binaryEncryption = L8.Concat(R8).ToArray();
            for (int i = 0; i < binaryEncryption.Length; i++)
            {
                encryption = encryption + binaryEncryption[i];
            }

            string finalEncryption = Crutch(encryption, 5);
            textBox3.Text = finalEncryption;
        }

        private bool TryT(string s,string s1)
        { bool b=false;
            if (s2.Length < 3 || s2.Length > 5)
            {
                MessageBox.Show("Неправильно задан текст!!!", "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (s.Length != 8)
            {
                MessageBox.Show("Неправильно задан пароль!!!", "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                b = true;
            }
            return b;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            s = "";
            s2 = "";
            s = textBox1.Text;
            s2 = textBox2.Text;

            if( TryT(s,s2)==true)
            {
                Size = new Size(743, 343);
                binaryCode1 = Coding(s);
                key(binaryCode1);
                encryption1(s2);
            }

        }

        private void button2_Click(object sender, EventArgs e) //дешифровка
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Сначало нужно выполнить шифровку!!!", "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                string result_binary = Coding(textBox3.Text);
                string[] text = new string[result_binary.Length];
                for (int i = 0; i < result_binary.Length; i++)
                {
                    text[i] = result_binary[i].ToString();
                }
                for (int i = 0; i < result_binary.Length; i++)                           //преобразование массива из char в Int64
                {
                    textBlock1[i] = Convert.ToString(result_binary[i]);
                    textBlock2[i] = Convert.ToInt32(textBlock1[i]);
                }
                Array.Copy(textBlock2, 0, L8, 0, 40);
                Array.Copy(textBlock2, 40, R8, 0, 40);
                //R = x, Ki = y, Ki - 1 = z
                //1+z+y+xz
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 0; j < blockLength; j++)
                    {
                        F[i - 1, j] = (1 + newK[i - 1, j] + newK[i, j] + (R[i - 1, j] * newK[i - 1, j])) % 2;
                        L[i, j] = R[i - 1, j];
                        R[i, j] = (F[i - 1, j] + L[i - 1, j]) % 2;

                        R0[j] = R[0, j];
                        L0[j] = L[0, j];
                    }
                }
                binaryEncryption = L0.Concat(R0).ToArray();

                encryption = "";

                for (int i = 0; i < binaryEncryption.Length; i++)
                {
                    encryption = encryption + binaryEncryption[i];
                }
                int cut1 = 0;
                int cut2 = 0;
                highBit = encryption.Substring(reserveHighBit, 4);
                lowBit = encryption.Substring(reserveLowBit, 4);
                cut1 = Convert.ToInt32(highBit, 2);
                cut2 = Convert.ToInt32(lowBit, 2) * bit;
                encryption = encryption.Substring(0, encryption.Length - (cut1 + cut2));     //отрезает лишние биты

                string finalEncryption = Crutch(encryption, 5);
                textBox4.Text = finalEncryption;
            }
        }
    }
}