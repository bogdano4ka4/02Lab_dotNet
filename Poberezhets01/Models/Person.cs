using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poberezhets01.Tools.Interfaces;

namespace Poberezhets01.Models
            
    //TODO перевірити весь клас!!!
{
    internal class Person : INotifyPropertyChanged, IChinaHoroscope
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birth;
        private readonly bool _isAdult = false;
        private readonly string _sunSign;
        private readonly string _chineseSign;
        private readonly bool _isBirthday = false;
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public DateTime Birth
        {
            get => _birth;
            set => _birth = value;
        }
        public bool IsBirthday => _isBirthday;

        public string SunSign
        {
            get => _sunSign;
        }

        public string ChineseSign => _chineseSign;
        public bool IsAdult => _isAdult;
        #endregion

        #region Constructors
        public Person(string name, string surname, string email, DateTime birth)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birth = birth;
            if (CalculateAge() >= 18) _isAdult = true;
            _sunSign = WestHor();
            _chineseSign = GiveChinaHoroscope(Birth);
            _isBirthday = CheckBirthday();
        }
        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
            if (CalculateAge() >= 18) _isAdult = true;
            _sunSign = WestHor();
            _chineseSign = GiveChinaHoroscope(Birth);
            _isBirthday = CheckBirthday();
        }
        public Person(string name, string surname, DateTime birth)
        {
            _name = name;
            _surname = surname;
            _birth = birth;
            if (CalculateAge() >= 18) _isAdult = true;
            _sunSign = WestHor();
            _chineseSign = GiveChinaHoroscope(Birth);
            _isBirthday = CheckBirthday();
        }
        #endregion

        #region Methods
        private int CalculateAge()
        {
            DateTime today = Convert.ToDateTime(DateTime.Today);
            int year = 0;
            if (Birth.Month > today.Month || (today.Month == Birth.Month && today.Day < Birth.Day))
                year = today.Year - Birth.Year - 1;
            else year = today.Year - Birth.Year;
            return year;
        }
        //method that return West Horoscope
        private String WestHor()
        {
            if ((Birth.Month == 3 && Birth.Day >= 21) || (Birth.Month == 4 && Birth.Day <= 20))
                return "Овен";
            if ((Birth.Month == 4 && Birth.Day >= 21) || (Birth.Month == 5 && Birth.Day <= 21))
                return "Телець";
            if ((Birth.Month == 5 && Birth.Day >= 22) || (Birth.Month == 6 && Birth.Day <= 21))
                return "Близнюки";
            if ((Birth.Month == 6 && Birth.Day >= 22) || (Birth.Month == 7 && Birth.Day <= 22))
                return "Овен";
            if ((Birth.Month == 7 && Birth.Day >= 23) || (Birth.Month == 8 && Birth.Day <= 21))
                return "Лев";
            if ((Birth.Month == 8 && Birth.Day >= 22) || (Birth.Month == 9 && Birth.Day <= 23))
                return "Діва";
            if ((Birth.Month == 9 && Birth.Day >= 24) || (Birth.Month == 10 && Birth.Day <= 23))
                return "Терези";
            if ((Birth.Month == 10 && Birth.Day >= 24) || (Birth.Month == 11 && Birth.Day <= 22))
                return "Скорпіон";
            if ((Birth.Month == 11 && Birth.Day >= 23) || (Birth.Month == 12 && Birth.Day <= 22))
                return "Стрілець";
            if ((Birth.Month == 12 && Birth.Day >= 24) || (Birth.Month == 1 && Birth.Day <= 23))
                return "Козеріг";
            if ((Birth.Month == 1 && Birth.Day >= 21) || (Birth.Month == 2 && Birth.Day <= 19))
                return "Водолій";
            if ((Birth.Month == 2 && Birth.Day >= 20) || (Birth.Month == 3 && Birth.Day <= 20))
                return "Риба";
            return "Zodiak";
        }
        private bool CheckBirthday()
        {
            DateTime today = Convert.ToDateTime(DateTime.Today);
            DateTime birthday = Convert.ToDateTime(Birth);
            if (today.Month == birthday.Month && today.Day == birthday.Day)
                return true;
            return false;
        }

        public string GiveChinaHoroscope(DateTime date)
        {
            int year = date.Year % 12;
            return Enum.GetName(typeof(ViewChinaHoroscope), year);
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
    }
}
