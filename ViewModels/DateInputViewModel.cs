using Practice1Buha.Models;
using Practice1Buha.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1Buha.ViewModels
{
    class DateInputViewModel : INotifyPropertyChanged
    {
        #region Fields
        private DateOfBirth dateInput = new DateOfBirth();
        private int ageOfUser;
        private RelayCommand<object> _outputOfAgeCommand;
        private RelayCommand<object> _cancelCommand;
        private string westernZodiacSign;
        private string chineseZodiacSign;
        #endregion

        #region Properties
        public DateTime InputDate
        {
            get
            {
                return dateInput.Date;
            }
            set
            {
                dateInput.Date = value;
            }
        }

        public RelayCommand<object> OutputOfAgeCommand
        {
            get
            {
                return _outputOfAgeCommand ??= new RelayCommand<object>(_ => OutputOfAge());
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ??= new RelayCommand<object>(_ => Environment.Exit(0));
            }
        }

        public string ChineseZodiacSign
        {
            get
            {
                return chineseZodiacSign;
            }
            set
            {
                chineseZodiacSign = value;
            }
        }
        public string WesternZodiacSign
        {
            get
            {
                return westernZodiacSign;
            }
            set
            {
                westernZodiacSign = value;
            }
        }
        public int AgeOfUser
        {
            get
            {
                return ageOfUser;
            }
            set
            {
                ageOfUser = value;
            }
        }
        #endregion

        #region ZodiacSignCalculations
        private void CalculateWesternZodiacSign(DateTime inputedDate)
        {
            switch (inputedDate.Month)
            {
                case 1:
                    if (inputedDate.Day < 21)
                        WesternZodiacSign = "Capricorn";
                    else
                        WesternZodiacSign = "Aquarius";
                    break;
                case 2:
                    if (inputedDate.Day < 20)
                        WesternZodiacSign = "Aquarius";
                    else
                        WesternZodiacSign = "Pisces";
                    break;
                case 3:
                    if (inputedDate.Day < 21)
                        WesternZodiacSign = "Pisces";
                    else
                        WesternZodiacSign = "Aries";
                    break;
                case 4:
                    if (inputedDate.Day < 21)
                        WesternZodiacSign = "Aries";
                    else
                        WesternZodiacSign = "Taurus";
                    break;
                case 5:
                    if (inputedDate.Day < 22)
                        WesternZodiacSign = "Taurus";
                    else
                        WesternZodiacSign = "Gemini";
                    break;
                case 6:
                    if (inputedDate.Day < 22)
                        WesternZodiacSign = "Gemini";
                    else
                        WesternZodiacSign = "Cancer";
                    break;
                case 7:
                    if (inputedDate.Day < 23)
                        WesternZodiacSign = "Cancer";
                    else
                        WesternZodiacSign = "Leo";
                    break;
                case 8:
                    if (inputedDate.Day < 22)
                        WesternZodiacSign = "Leo";
                    else
                        WesternZodiacSign = "Virgo";
                    break;
                case 9:
                    if (inputedDate.Day < 24)
                        WesternZodiacSign = "Virgo";
                    else
                        WesternZodiacSign = "Libra";
                    break;
                case 10:
                    if (inputedDate.Day < 24)
                        WesternZodiacSign = "Libra";
                    else
                        WesternZodiacSign = "Scorpio";
                    break;
                case 11:
                    if (inputedDate.Day < 24)
                        WesternZodiacSign = "Scorpio";
                    else
                        WesternZodiacSign = "Sagittarius";
                    break;
                case 12:
                    if (inputedDate.Day < 23)
                        WesternZodiacSign = "Sagittarius";
                    else
                        WesternZodiacSign = "Capricorn";
                    break;
            }
        }
        private void CalculateChineseZodiacSign(DateTime inputedDate)
        {
            switch ((inputedDate.Year - 4) % 12)
            {
                case 0:
                    ChineseZodiacSign = "Rat";
                    break;
                case 1:
                    ChineseZodiacSign = "Ox";
                    break;
                case 2:
                    ChineseZodiacSign = "Tiger";
                    break;
                case 3:
                    ChineseZodiacSign = "Rabbit";
                    break;
                case 4:
                    ChineseZodiacSign = "Dragon";
                    break;
                case 5:
                    ChineseZodiacSign = "Snake";
                    break;
                case 6:
                    ChineseZodiacSign = "Horse";
                    break;
                case 7:
                    ChineseZodiacSign = "Goat";
                    break;
                case 8:
                    ChineseZodiacSign = "Monkey";
                    break;
                case 9:
                    ChineseZodiacSign = "Rooster";
                    break;
                case 10:
                    ChineseZodiacSign = "Dog";
                    break;
                case 11:
                    ChineseZodiacSign = "Pig";
                    break;
            }
        }

        private int CalculateAge(DateTime inputedDate, DateTime now)
        {
            int age = now.Year - inputedDate.Year;
            if (now.Month < inputedDate.Month || (now.Month == inputedDate.Month && now.Day < inputedDate.Day))
                age--;
            return age;
        }
        #endregion

        private void OutputOfAge()
        {
            AgeOfUser = CalculateAge(dateInput.Date, DateTime.Now);
            if (AgeOfUser < 0 || AgeOfUser > 135)
            {
                MessageBox.Show($"Birth date {dateInput.Date} is wrong!");
                return;
            }
            if(((DateTime.Now.Month - dateInput.Date.Month) == 0) && ((DateTime.Now.Day - dateInput.Date.Day) == 0))
            {
                MessageBox.Show("Happy Birthday!");
            }
            CalculateChineseZodiacSign(dateInput.Date);
            CalculateWesternZodiacSign(dateInput.Date);
            CalculateAge(dateInput.Date, DateTime.Now);
            OnPropertyChanged("AgeOfUser");
            OnPropertyChanged("ChineseZodiacSign");
            OnPropertyChanged("WesternZodiacSign");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
