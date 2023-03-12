using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string sourcePath = @"C:\Users\china\Documents\Text\file1.txt";
        string targetPath = @"C:\Users\china\Documents\Text\file2.txt";


        FileInfoExemplo(sourcePath, targetPath);
        StreamReaderFileStream(sourcePath);
        BlocoUsing(sourcePath);


    }
    static void FileInfoExemplo(string sourcePath, string targetPath)
    {
        try
        {
            FileInfo fileInfo = new FileInfo(sourcePath);

            // Copia arquivos de um arquivo para outro
            //fileInfo.CopyTo(targetPath);

            // Lê todas as linhas de um arquivo
            string[] lines = File.ReadAllLines(sourcePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    static void StreamReaderFileStream(string sourcePath)
    {
        //FileStream fs = null;
        StreamReader sr = null;

        try
        {
            // Permite operações de leitura e escrita
            // fs = new FileStream(sourcePath, FileMode.Open);

            sr = File.OpenText(sourcePath);
            // Enquanto não chegar no final da stream
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }

            // É capaz de ler caracteres a partir de uma stream binária
            //sr = new StreamReader(fs);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            //if (fs != null) fs.Close();
            if (sr != null) sr.Close();
        }
    }
    static void BlocoUsing(string sourcePath)
    {
        try
        {
            using (FileStream fs = new FileStream(sourcePath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}