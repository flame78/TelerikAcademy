//A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. Write a program that reads the information about a company and its manager and prints them on the console.

using System;

class Company
{
    static void Main()
    {
        string cName, cAddress, cPhone, cFax, cWeb; // c = Company
        string mFirstName, mLastName, mPhone; // m = Manager
        byte mAge;

        Console.WriteLine("Enter company name, address, phone number, fax number and web site .\nIn this order each on new line");
        cName = Console.ReadLine();
        cAddress = Console.ReadLine();
        cPhone = Console.ReadLine();
        cFax = Console.ReadLine();
        cWeb = Console.ReadLine();

        Console.WriteLine("Enter manager first name, last name, age and a phone number.\nIn this order each on new line");
        mFirstName = Console.ReadLine();
        mLastName = Console.ReadLine();
        mAge = byte.Parse(Console.ReadLine());
        mPhone = Console.ReadLine();

        Console.WriteLine(new string('-', 80));
        Console.WriteLine(cName);
        Console.WriteLine(cAddress);
        Console.WriteLine(cPhone);
        Console.WriteLine(cFax);
        Console.WriteLine(cWeb);
        Console.WriteLine(mFirstName);
        Console.WriteLine(mLastName);
        Console.WriteLine(mAge);
        Console.WriteLine(mPhone);
    }
}

