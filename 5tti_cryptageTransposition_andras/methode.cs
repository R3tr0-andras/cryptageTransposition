using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5tti_cryptageTransposition_andras
{
    public struct methode
    {
        // ça m'a cassé les pied de devoir gérer le for alors j'ai fait autrement, les chars d'assault sont très éfficace au passage
        public string DeleteSpace()
        {
            string ?message = Console.ReadLine();
            if (message == null) return "";
            string messageClear = "";
            foreach (char c in message)
            {
                if (c != ' ')
                {
                    messageClear += c;
                }
            }
            return messageClear.ToUpper();
        }

        public void CreateMatrix(ref string cle, ref string messageClear, ref char[,] matrix)
        {
            int d1 = (messageClear.Length / cle.Length) + 2;
            int d2 = cle.Length;

            if (messageClear.Length % cle.Length != 0)
            {
                d1 += 1;
            }
            matrix = new char[d1, d2];
        }

        public void ReadStringIntoMatrix(ref string cle, ref string messageClear, ref char[,] matrix)
        {
            for (int i = 0; i < cle.Length; i++)
            {
                matrix[0, i] = cle[i];
            }

            int k = 0;
            for (int j = 1; j < matrix.GetLength(0); j++)
            {
                for (int i = 0; i < matrix.GetLength(1) && k < messageClear.Length; i++)
                {
                    matrix[j, i] = messageClear[k++];
                }
            }
        }

        public void SortingLine(ref char[,] matrix)
        {
            bool permut;
            do
            {
                permut = false;
                for (int i = 0; i < matrix.GetLength(1) - 1; i++)
                {
                    if (matrix[0, i] > matrix[0, i + 1])
                    {
                        for (int j = 0; j < matrix.GetLength(0); j++)
                        {
                            char temp = matrix[j, i];
                            matrix[j, i] = matrix[j, i + 1];
                            matrix[j, i + 1] = temp;
                        }
                        permut = true;
                    }
                }
            } while (permut);
        }

        public char[,] CreateMatrixTool(ref string cle)
        {
            char[,] matrixSorted = new char[3, cle.Length];

            for (int j = 0; j < matrixSorted.GetLength(1); j++)
            {
                matrixSorted[0, j] = cle[j];
                matrixSorted[2, j] = '0';
            }

            SortingLine(ref matrixSorted);

            for (int j = 0; j < matrixSorted.GetLength(1); j++)
            {
                matrixSorted[1, j] = char.Parse((j + 1).ToString());
            }

            return matrixSorted;
        }

        public void ReportOrder(ref char[,] matrix, ref char[,] matrixSorted)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                bool found = false;
                int j = 0;

                while (!found && j < matrixSorted.GetLength(1))
                {
                    if (matrix[0, i] == matrixSorted[0, j] && matrixSorted[2, j] != '1')
                    {
                        matrix[1, i] = matrixSorted[1, j];
                        matrixSorted[2, j] = '1';
                        found = true;
                    }
                    j++;
                }
            }
        }

        public string BuildCryptage(char[,] matrix)
        {
            string chaineCrypt = "";

            for (int i = 1; i <= matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[1, j] == char.Parse(i.ToString()))
                    {
                        for (int k = 2; k < matrix.GetLength(0); k++)
                        {
                            chaineCrypt += matrix[k, j];
                        }
                        chaineCrypt += " ";
                    }
                }
            }
            return chaineCrypt.Trim();
        }

        public void DisplayMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] == '\0' ? ' ' : matrix[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}