using System;

// ���������� ���� �� CarLibrary.
using CarLibrary;

// ������������� ����������� ���������� ����.

namespace CSharpCarClient
{
    class Program
    {
        public static void Main()
        {
            // ������� ���������� ���������� ������.
            SportsCar sportcar = new SportsCar("Viper", 240, 40);
            sportcar.Acceleration();

            // ������� ����-���.
            MiniVan minivan = new MiniVan();
            minivan.Acceleration();

            // ��������.
            Console.ReadKey();            
        }
    }
}
