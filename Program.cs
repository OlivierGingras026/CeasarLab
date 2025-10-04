using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CeasarLab1
{
    internal class Program
    {
        static void Main(string[] args)


        {

            try
            {
                if (args.Length != 3)
                {

                    Console.WriteLine("You must enter three parameters");
                    return;
                }

                string trainingFilePath = args[0];
                string scrambleFilePath = args[1];
                string outputFilePath = args[2];

                //taking parameters for each file : war_and_peace , encrypted , output 



                FileIO fileio = new FileIO();


                Console.WriteLine($"\nReading training file \"{trainingFilePath}\"");

                int linecounts = fileio.CountLine(trainingFilePath);

                int charcounts = fileio.CountCharacters(trainingFilePath);

                Console.WriteLine("\nLength of the input file is " + linecounts + " lines and " + charcounts + " characthers");


                String resultNormaltext = fileio.GetCount(trainingFilePath); //able MostUpperCaseOccurence and MostOccurenceLowerCase to work 

                var (firstUpperCarac, firstUpperCount, secondUpperCarac, secondUpperCount) = fileio.MostUpperCaseOccurence();

                Console.WriteLine($"\nThe two most occurring uppercase characters in War and Peace are  " + firstUpperCarac + " and " + secondUpperCarac +
                   " occuring " + firstUpperCount + "  and " + secondUpperCount + " times");

                var (firstLowerCarac, firstLowerCount, secondLowerCarac, secondLowerCount) = fileio.MostOccurenceLowerCase();

                Console.WriteLine($"\nThe two most occurring lowercase characters in War and Peace are  " + firstLowerCarac + " and " + secondLowerCarac +
                   " occuring " + firstLowerCount + " and " + secondLowerCount + " times");

                //////////////////////////////////////////////////////////////////


                Console.WriteLine($"\nReading encrypted file \"{scrambleFilePath}\"");

                int linecountsEncry = fileio.CountLine(scrambleFilePath);

                int charcountsEncry = fileio.CountCharacters(scrambleFilePath);

                Console.WriteLine("\nLength of the input file is " + linecountsEncry + " lines and " + charcountsEncry + " characthers");


                String encryptedtext = fileio.GetCount(scrambleFilePath);

                var (firstUpperCaracEncry, firstUpperCountEncry, secondUpperCaracEncry, secondUpperCountEncry) = fileio.MostUpperCaseOccurence();

                Console.WriteLine($"\nThe two most occurring uppercase characters in the Encrypted file are  " + firstUpperCaracEncry + " and " + secondUpperCarac +
                   " occuring " + firstUpperCountEncry + "  and " + secondUpperCountEncry + " times");

                var (firstLowerCaracEncry, firstLowerCountEncry, secondLowerCaracEncry, secondLowerCountEncry) = fileio.MostOccurenceLowerCase();

                Console.WriteLine($"\nThe two most occurring lowercase characters in the Encrypted file are  " + firstLowerCaracEncry + " and " + secondLowerCaracEncry +
                 " occuring " + firstLowerCountEncry + " and " + secondLowerCountEncry + " times");

                ////////////////////////////////////////////////////////////
                ///
                

                int shiftUppercase = fileio.CalculateShiftUppercase(firstUpperCarac, firstUpperCaracEncry);

                Console.WriteLine("\nFor the upper cases , a shift factor of " + shiftUppercase + " has been determined ");


                int shiftLowerCase = fileio.CalculateShiftLowerCase(firstLowerCarac, firstLowerCaracEncry);

                Console.WriteLine("\nFor the lower cases , a shift factor of " + shiftLowerCase + " has been determined ");


                /////////////////////////////////////////////////////////////////////////////////////////////

                Decoder decoder = new Decoder();



                string outputtext = args[2];


                Console.WriteLine($"\nWriting output file now to \"{outputtext}\".");


                string decode = decoder.Decode(scrambleFilePath, outputtext, shiftLowerCase, shiftUppercase);



                Console.Write("Display the file? (y/n): ");

                char displayChoice = Console.ReadKey().KeyChar;

     
                
                if (char.ToLower(displayChoice) == 'y')
                {

                    string output = fileio.ReadFile(outputtext);

                    Console.WriteLine('\n' + output);
                }
                else
                {
                    Console.WriteLine("\nCeasar Lab has endend");
                  
                }



            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The file was not founded");
            }

            catch (IOException e) {

                Console.WriteLine(e.Message);
            }










        }
    }
}
