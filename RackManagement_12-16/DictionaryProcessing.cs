namespace RackManagement
{
    using System;
    using System.IO;

    class WordList
    {
        private const string WordListLocation 
            = @"C:\Users\Aaron\Documents\Programming and Code\DailyProgrammer\enable1.txt";
        public string[] AllWords;
        public int Length;
        
        public WordList()
        {
            this.AllWords = ReadListFromFile(WordListLocation);
            this.Length = AllWords.Length;
        }
        public WordList(string listType)
        {
            switch (listType)
            {
                case "alphabetical":
                    this.AllWords = ReadListFromFile(WordListLocation);
                    this.Length = AllWords.Length;
                    break;
                case "length":
                    this.AllWords = SortByLength(ReadListFromFile(WordListLocation));
                    this.Length = AllWords.Length;
                    break;
                default:
                    break;
            }
        }

        private string[] ReadListFromFile(string fileLocation)
        {
            try
            {
                string[] allWords = File.ReadAllLines(fileLocation);
                return allWords;
            }
            catch
            {
                throw new FileLoadException();
            }
        }

        private string[] SortByLength(string[] wordList)
        {
            QuickSortByStringLength(wordList, 0, wordList.Length - 1);
            return wordList;            
        }

        private void QuickSortByStringLength(string[] array, int left, int right)
        {
            if (right - left < 30)
            {
                SelectionSort(array, left, right);
                return;
            }

            var leftMarker = left;
            var rightMarker = right;
            var sideToMove = "left";
            var random = new Random();
            var pivot = random.Next(left, right);
            var temp = array[pivot];

            while (leftMarker < rightMarker)
            {
                if (sideToMove == "left")
                {
                    if (array[leftMarker].Length < temp.Length)
                    {
                        array[pivot] = array[leftMarker];
                        pivot = leftMarker;
                        sideToMove = "right";
                    }
                }
                if (sideToMove == "right")
                {
                    if (array[rightMarker].Length > temp.Length)
                    {
                        array[pivot] = array[rightMarker];
                        pivot = rightMarker;
                        sideToMove = "left";
                    }
                }
                
                if (sideToMove == "left")
                {
                    leftMarker++;
                }
                else
                {
                    rightMarker--;
                }
            }

            array[pivot] = temp;
            QuickSortByStringLength(array, left, pivot);
            QuickSortByStringLength(array, pivot + 1, right);

            return;
        }

        private void SelectionSort(string[] array, int start, int end)
        {
            while(end > start)
            {
                int indexToMove = start;

                for (int i = start; i < end; i++)
                {
                    if (array[indexToMove].Length <= array[i].Length)
                    {
                        indexToMove = i;
                    }
                }

                if (indexToMove < end)
                {
                    var temp = array[indexToMove];
                    array[indexToMove] = array[end];
                    array[end] = temp;
                }
                end--;
            }
        }

    }
}
