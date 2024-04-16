/********************************************
 *                                          *
 * Name: Bill Nicholson                     *
 * email: nicholdw@ucmail.uc.edu            *
 * Luhn's Algorithm                         *
 *                                          *
 ********************************************/
using System;

namespace Luhns_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a credit card number, no dashes, and I will compute the validity of the format: ");
                String ccNumber;
                ccNumber = Console.ReadLine();
                if (Validator.ValidateCard(ccNumber))
                {
                    Console.WriteLine(ccNumber + " appears to be a valid format.");
                }
                else
                {
                    Console.WriteLine("That number does not appear to be a valid format.");
                }
            }
        }
    }

    public class Validator
    {
        public static bool ValidateCard(String cardNumber)
        {
            try
            {
                int cardLength = cardNumber.Length;

                int sum = 0;
                bool isSecond = false;
                for (int i = cardLength - 1; i >= 0; i--)
                {
                    int digit = cardNumber[i] - '0';

                    if (isSecond)
                    {
                        // Double every 2nd digit
                        digit *= 2;
                    }

                    sum += digit / 10;
                    sum += digit % 10;

                    isSecond = !isSecond; //Set it to the opposite of its current valid, switches back and forth between true and false
                }

                // If a multiple of 10, card is valid
                return (sum % 10 == 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}