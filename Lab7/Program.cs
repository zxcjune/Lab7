using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab7
{
    internal class Program
    {
        static List<TV> TVs;

        static void PrintTVs()
        {
            foreach (TV tv in TVs)
            {
                Console.WriteLine(tv.Info());
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            TVs = new List<TV>();
            FileStream fs = new FileStream("TVs.tvs", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            try
            {
                Console.WriteLine("Читаємо дані з файлу...\n");
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    TV tv = new TV();
                    for (int i = 0; i < 8; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                tv.Model = br.ReadString();
                                break;
                            case 2:
                                tv.Display = br.ReadString();
                                break;
                            case 3:
                                tv.Cores = br.ReadInt32();
                                break;
                            case 4:
                                tv.Resolution = br.ReadString();
                                break;
                            case 5:
                                tv.Platform = br.ReadString();
                                break;
                            case 6:
                                tv.HasTuner = br.ReadBoolean();
                                break;
                            case 7:
                                tv.HasAI = br.ReadBoolean();
                                break;
                        }
                    }
                    TVs.Add(tv);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталась помилка: {0}", ex.Message);
            }
            finally
            {
                br.Close();
            }
            Console.WriteLine($"Несортований перелік телевізорів: {TVs.Count}");
            PrintTVs();
            TVs.Sort();
            Console.WriteLine($"Сортований перелік телевізорів: {TVs.Count}");
            PrintTVs();
            TV tv1 = new TV("TV", "Oled", 4, "1000x500", "Android", true, true);
            TVs.Add(tv1);
            TVs.Sort();
            Console.WriteLine($"Перелік телевізорів: {TVs.Count}");
            PrintTVs();
            Console.WriteLine("Видаляємо останнє значення");
            TVs.RemoveAt(TVs.Count - 1);
            Console.WriteLine($"Перелік телевізорів: {TVs.Count}");
            PrintTVs();
            Console.ReadKey();
        }
    }
}
