using System;

namespace BookManager
{
    [Serializable]
    public class Book
    {

        public Book()
        {

        }

        // These are attributes required for the ISBN-filtering calculation
        private int prefix;
        private int title;
        private int publisher;
        private int group;
        private int checkNumber;
        // 

        public string Title{ set; get; }
        public string Author { set; get; }
        public string ISBN
        {
            set
            {
                try
                {
                    if (value.Length == 17)
                    {
                        char[] delimiterChars = { '-' };
                        string[] parts = value.Split(delimiterChars);
                        string numbers = parts[0] + "" + parts[1] + "" + parts[2] + "" + parts[3];
                        for(int i = 0; i <= parts.Length; i++)
                        {

                        }
                        // Checks whether the first number in the ISBN is 978 or 979
                        if (parts[0] == "978" || parts[0] == "979")
                        {
                            prefix = Convert.ToInt32(parts[0]);
                        }
                        else
                        {
                            throw new Exception("The prefix is not correct. Only '978' and '979' are valid prefix numbers.");
                        }
                        // Converts the other numbers into an Integer so that they can be calculated together for the Checknumber
                        group = Convert.ToInt32(parts[1]);
                        publisher = Convert.ToInt32(parts[2]);
                        title = Convert.ToInt32(parts[3]);

                        int checkNumberDetermination = 0;
                        bool nextNumberMultipliedByOne = true;

                        //For all the numbers contained by the String "numbers"
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            // Every odd index in the ISBN is multiplied by 1
                            if (nextNumberMultipliedByOne)
                            {
                                checkNumberDetermination += (Int32)Char.GetNumericValue(numbers, i);
                                nextNumberMultipliedByOne = false;
                            }
                            // Every even index in the ISBN is multiplied by 3
                            else
                            {
                                checkNumberDetermination += (Int32)Char.GetNumericValue(numbers, i) * 3;
                                nextNumberMultipliedByOne = true;
                            }
                        }
                        // Checknumber from Wikipedia
                        checkNumber = (10 - ((checkNumberDetermination) % 10)) % 10; // The Second % 10 is for the case if the sum of the checkNumberDetermination equals a multiplier of 10,
                                                                                     //so the checkNumber is one digit.
                    }
                    else
                    {
                        throw new Exception("Invalid value.Length. Please refrain to a length of exactly 17 characters (hyphens ('-') included).");
                    }
                }catch
                {
                    throw new Exception("The ISBN Number does not meet the norm requirements: xxx-x-xx-xxxxxx-x");
                }
              }
            // returns the final ISBN added together by its initial components and adds the check-number in the end

            /* Must have entered every number into the ISBN Textbox for it to work! Checknumber will be calculated automatically and will correct
             *  the user if needed.  
             */
            get
            { return "" + prefix + "-" + group + "-" + publisher + "-" + title + "-" + checkNumber; }
        }
        public string Publisher { set; get; }
        public int Date { set; get; }
        public double Price { set; get; }
    }
}
