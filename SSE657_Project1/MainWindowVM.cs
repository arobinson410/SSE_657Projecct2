using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SSE657_Project1
{
    public class MainWindowVM
    {
        public Character c;

        public MainWindowVM(Character c)
        {
            this.c = c;
        }

        public string CharacterName
        {
            get
            {
                return c.CharacterName;
            }
            set
            {
                c.CharacterName = value;
            }
        }

        public int[] AbilityScores
        {
            get
            {
                return c.AbilityScores;
            }
            set
            {
                c.AbilityScores = value;
            }
        }

        public Character character
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
            }

        }

        public int Strength
        {
            get
            {
                return c.AbilityScores[0];
            }
            set
            {
                c.changeStat(Character.AbilityScore.Strength, value); ;
            }
        }

        public int Dexterity
        {
            get
            {
                return c.AbilityScores[1];
            }
            set
            {
                c.changeStat(Character.AbilityScore.Dexterity, value);
            }
        }

        public int Constitution
        {
            get
            {
                return c.AbilityScores[2];
            }
            set
            {
                c.changeStat(Character.AbilityScore.Constitution, value);
            }
        }

        public int Intelligence
        {
            get
            {
                return c.AbilityScores[3];
            }
            set
            {
                c.changeStat(Character.AbilityScore.Intelligence, value);
            }
        }

        public int Wisdom
        {
            get
            {
                return c.AbilityScores[4];
            }
            set
            {
                c.changeStat(Character.AbilityScore.Wisdom, value);
            }
        }

        public int Charisma
        {
            get
            {
                return c.AbilityScores[5];
            }
            set
            {
                c.changeStat(Character.AbilityScore.Charisma, value);
            }
        }

        public string ArmorType
        {
            get
            {
                return c.ArmorType;
            }
            set
            {
                c.ArmorType = value;
            }
        }

        public int AC
        {
            get
            {
                return c.AC;
            }
            set
            {
                c.AC = value;
            }
        }

    }

    public class AbilityModConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value < 10)
            {
                return -(int)(Math.Ceiling((10.0 - (int)value) / 2.0));
            }
            else if ((int)value > 10)
            {
                return ((int)value - 10) / 2;
            }
            else
                return 0;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
