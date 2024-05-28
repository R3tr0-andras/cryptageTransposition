namespace _5tti_cryptageTransposition_andras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            methode Mp = new methode();

            do
            {
                char[,] matrix = null;

                Console.WriteLine("Enter the message to encrypt (spaces will be removed):");
                string messageClear = Mp.DeleteSpace();

                Console.WriteLine("Enter the key:");
                string ?cle = Console.ReadLine();

                Mp.CreateMatrix(ref cle, ref messageClear, ref matrix);
                Mp.ReadStringIntoMatrix(ref cle, ref messageClear, ref matrix);

                Console.WriteLine("Initial Matrix:");
                Mp.DisplayMatrix(matrix);

                char[,] matrixSorted = Mp.CreateMatrixTool(ref cle);
                Mp.ReportOrder(ref matrix, ref matrixSorted);

                string encryptedMessage = Mp.BuildCryptage(matrix);

                Console.WriteLine("Encrypted message:");
                Console.WriteLine(encryptedMessage);

                Console.WriteLine("Do you want to encrypt another message? (yes/no)");
            } while (Console.ReadLine()?.ToLower() == "yes");
        }
    }
}