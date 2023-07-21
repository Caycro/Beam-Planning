namespace PlanIt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float unAssignedPercent = 0;
            DateTime startDate;
            DateTime endDate;
            List<BookedDates> bookedDates;
            List<User> users = new List<User>();
            LoadUsers(users);
            //sort the users based on their priority
            users.Sort((x, y) => x._priorty.CompareTo(y._priorty));
            GetDates(out startDate, out endDate, out bookedDates);
            int numBooked = 0;
            Console.WriteLine("what % of days should be kept empty for ad hoc use");
            while (!float.TryParse(Console.ReadLine(), out unAssignedPercent)) ;


            //go through every user in order on the ranked list and give them the bookings required
            foreach (User u in users)
            {
                AssignDatesToUser(u, bookedDates, ref numBooked);
                //unsure that the required % of dates requicred for adhoc is fulfilled
                if (numBooked / bookedDates.Count * 100 > (100 - unAssignedPercent))
                {
                    break;
                }

            }
            DisplayCalender(bookedDates);

            static void DisplayCalender(List<BookedDates> bookedDates)
            {
                Console.Clear();
                //all that is left is to make a display for the calender
                Console.SetWindowSize(Math.Max(bookedDates.Count * 2 / 5, 100), 30);
                for (int i = 0; i <= 6; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(Convert.ToString((DayOfWeek)(i))[0]);
                }
                foreach (BookedDates currentDate in bookedDates)
                {

                    Console.SetCursorPosition((currentDate.date - bookedDates[0].date).Days / 7 * 2 + 2, (int)currentDate.date.DayOfWeek);
                    if (currentDate.booker != null)
                    {
                        Console.WriteLine(currentDate.booker._email);
                    }

                }
                Console.ReadKey();
            }
        }

        private static void GetDates(out DateTime startDate, out DateTime endDate, out List<BookedDates> bookedDates)
        {
            string date, date2;
            Console.WriteLine("what is the start date (YYYY/MM/DD)");
            date = Console.ReadLine();

            //potential error here  has not been tested
            Console.WriteLine("what is the end date (YYYY/MM/DD)");
            date2 = Console.ReadLine();

            while (!DateTime.TryParse(date, out startDate) || !DateTime.TryParse(date2, out endDate));
            {
                Console.WriteLine("what is the start date (YYYY/MM/DD)");
                date = Console.ReadLine();

                //potential error here  has not been tested
                Console.WriteLine("what is the end date (YYYY/MM/DD)");
                date2 = Console.ReadLine();
            }
            bookedDates = GenerateCalender(startDate, endDate);
        }



        public static void AssignDatesToUser(User user, List<BookedDates> calender, ref int numBooked)
        {
            foreach (BookedDates currentDate in calender)
            {
                if (!user.datesUnavalible.Contains(currentDate.date) && currentDate.booker == null)
                {
                    foreach (Block b in user.blocks)
                    {
                        if (WeekDayOrEnd(currentDate.date) == b._typeOfDay && b._length > 0)
                        {
                            b._length--;
                            currentDate.booker = user;
                            numBooked++;
                        }
                    }
                }
            }
        }

        public static List<BookedDates> GenerateCalender(DateTime startDate, DateTime endDate)
        {
            List<BookedDates> dates = new List<BookedDates>();
            for (DateTime currentDay = startDate.Date; currentDay.Date <= endDate.Date; currentDay = currentDay.AddDays(1))
            {
                dates.Add(new BookedDates(currentDay));
            }
            return dates;
        }
        

        //convert an array of string to DateTimes

        public static DateTime DateTimeFromInput(string input)
        {
            string[] placeHolder = input.Split(new char[] { '/' });
            //crashes if input not in correct format
            return new DateTime(Convert.ToInt16("20" + placeHolder[2]), Convert.ToInt16(placeHolder[1]), Convert.ToInt16(placeHolder[0]));

        }
        //convert string array to datetime array, should be used ater string.split
        public static DateTime[] StringArrToDateARR(string[] input)
        {
            DateTime[] result = new DateTime[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length > 6)
                {

                    //chect if already in correct format
                    DateTime.TryParse(input[i], out result[i]);
                    //check for DD/MM/YY
                    string ukInput = "20" + input[i][6] + input[i][7] + "/" + input[i][3] + input[i][4] + "/" + input[i].Remove(2);
                    DateTime.TryParse(ukInput, out result[i]);
                    //check for MM/DD/YY
                    string americaInput = "20" + input[i][6] + input[i][7] + "/" + input[i].Remove(2) + "/" + input[i][3] + input[i][4];
                    DateTime.TryParse(americaInput, out result[i]);
                }
            }
            return result;
        }

        //load data from csv for users and store it into user list
        static void LoadUsers(List<User> users)
        {
            string path = ("Form.csv");
            string[] lines = System.IO.File.ReadAllLines(path);
            int linecount = 0;
            foreach (string line in lines)
            {
                if (linecount > 6)
                {
                    string[] attributes = line.Split(new char[] { ',' });
                    DateTime timeSubmitted = MakeValidDate(attributes);
                    string email = attributes[3];
                    string name = attributes[4];
                    int priority = Convert.ToInt32(attributes[13]);
                    List<Block> blocks = new List<Block>();

                    string[] conversionList = attributes[14].Split(new char[] { }, ' ');
                    DateTime[] datesUnavalible = StringArrToDateARR(conversionList);

                    for (int i = 7; i < 12; i = i + 2)
                    {
                        blocks.Add(new Block(Convert.ToInt32(attributes[i]), attributes[i + 1]) { });

                    }
                    users.Add(new User(email, name, priority, blocks, timeSubmitted, datesUnavalible.ToList()));
                    //calculate the actual priority based on the time they submitted it and their assigned priority
                    users.Last().MakeTruePriority();
                }
                linecount++;

            }

            static DateTime MakeValidDate(string[] attributes)
            {

                //potential error here since forms uses form MM/DD/YY and this is not UTC
                //C# wants YYYY/MM/DD

                return Convert.ToDateTime("20" + attributes[1][6] + attributes[1][7] + "/" + attributes[1].Remove(4));
            }
        }

        static string WeekDayOrEnd(DateTime date)
        {
            if (((int)date.DayOfWeek) == 6 || (int)date.DayOfWeek == 0)
            {
                return "Weekends";
            }
            return "Weekdays";
        }
    }

    internal class User
    {   //represent how significant the time plays in determining where people in the ordered list are
        //larger values means time is more significant and priority manually assigned is less significant
        public const float TimeWeight = 1 / 100;


        public string _email { get; }
        private string _name { get; }
        public int _priorty;
        private DateTime daySubmitted { get; }
        public List<Block> blocks = new List<Block> { };
        public readonly List<DateTime> datesUnavalible = new List<DateTime>();

        public User(string email, string name, int priorty, List<Block> blocks, DateTime daySubmitted, List<DateTime> datesUnavalible)
        {
            _email = email;
            _name = name;
            _priorty = priorty;
            this.blocks = blocks;
            this.daySubmitted = daySubmitted;
            this.datesUnavalible = datesUnavalible;
        }

        //calculate how ranked a user is in the ranked list

        public void MakeTruePriority()
        {
            //make sure priority is already a valid form 
            if (_priorty == null)
            {
                _priorty = 1;
            }
            if (_priorty < 1)
            {
                _priorty = 1;

            }
            else if (_priorty > 3)
            {
                _priorty = 3;
            }
            _priorty = (int)Math.Ceiling(_priorty * (DateTime.Now.Date - this.daySubmitted.Date).TotalHours * TimeWeight);
        }
    }



    internal class Block
    {
        public int _length { get; set; }
        public string _typeOfDay { get; }
        public Block(int length, string typeOfDay)
        {
            _length = length;
            _typeOfDay = typeOfDay;
        }



    }



    internal class BookedDates
    {
        public User booker = null;
        public DateTime date;

        public BookedDates(DateTime date)
        {
            this.date = date;
        }
    }

}





