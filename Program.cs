using System;
using System.Text;
using System.Collections;

FileStream fileStream = new FileStream(@"C:\temp\advent-of-code\Advent-of-Code-Day-01\data.txt", FileMode.Open);
//set this to true to search for number words or false for just single digit numbers
bool transposeNumberWords = true;
int total = 0;
int twoDigitNumber = 0;
int indexFirstCurrent = 0;
int indexLastCurrent = 0;
int wordFirst = 0;
int wordLast = 0;
int indexFirst = 9999;
int indexLast = -1;
Dictionary<string, int> wordList = new Dictionary<string, int>();
wordList.Add("0",0);
wordList.Add("1",1);
wordList.Add("2",2);
wordList.Add("3",3);
wordList.Add("4",4);
wordList.Add("5",5);
wordList.Add("6",6);
wordList.Add("7",7);
wordList.Add("8",8);
wordList.Add("9",9);
if (transposeNumberWords)
{
    wordList.Add("zero",0);
    wordList.Add("one",1);
    wordList.Add("two",2);
    wordList.Add("three",3);
    wordList.Add("four",4);
    wordList.Add("five",5);
    wordList.Add("six",6);
    wordList.Add("seven",7);
    wordList.Add("eight",8);
    wordList.Add("nine",9);
}
using (StreamReader reader = new StreamReader(fileStream))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        foreach (KeyValuePair<string,int> word in wordList)
        {
            indexFirstCurrent = line.IndexOf(word.Key);
            if (indexFirstCurrent > -1 && indexFirstCurrent < indexFirst)
            {
                indexFirst = indexFirstCurrent;
                wordFirst = word.Value;
            }
             indexLastCurrent = line.LastIndexOf(word.Key);
             if (indexLastCurrent > indexLast)
            {
                indexLast = indexLastCurrent;
                wordLast = word.Value;
            }
        }
        twoDigitNumber = wordFirst*10+wordLast;
        Console.WriteLine(line + " " + twoDigitNumber.ToString());
        total+=twoDigitNumber;
        //reset indexes and words for next search term
        indexFirst = 9999;
        indexLast= -1;
        wordFirst = 0;
        wordLast= 0;
    }
}

Console.WriteLine("Total: " + total.ToString());


