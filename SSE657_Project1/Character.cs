using System;
using System.ComponentModel;

namespace SSE657_Project1
{
    public class Character : INotifyPropertyChanged
    {
        
        public enum AbilityScore
        {
            Strength = 0,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma
        };

        public enum SkillBonus
        {
            Athletics = 0, //STR
            Acrobatics, //DEX
            SleightOfHand,
            Stealth,
            Arcana, //INT
            History,
            Investigation,
            Nature,
            Religion,
            AnimalHandling, //WIS
            Insight,
            Medicine,
            Perception,
            Survival,
            Deception, //CHA
            Intimidation,
            Performance,
            Persuasion
        };

        private string _characterName = "Kel Yurok";
        private int _level = 5;
        private int _hp = 25;
        private int _ac = 10;
        private string _armorType = "None";
        private int[] _abilityScores = { 8, 12, 18, 8, 14, 20};
        private int[] _skillBonuses = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private bool[] _skillProficiencies = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

        private Inventory inventory = new Inventory();
        private Class characterClass = new Class();
        private SpellList spells = new SpellList();

        public event PropertyChangedEventHandler PropertyChanged;

        public String CharacterName
        {
            get
            {
                return _characterName;
            }
            set
            {
                _characterName = value;
            }
        }

        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }

        public int HP
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }
        }

        public int AC
        {
            get
            {
                return _ac;
            }
            set
            {
                _ac = value;
            }
        }

        public string ArmorType
        {
            get
            {
                return _armorType;
            }
            set
            {
                _armorType = value.Substring(value.LastIndexOf(':') + 2);
                calculateAC();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AC"));
            }
        }

        public int[] AbilityScores
        {
            get
            {
                return _abilityScores;
            }
            set
            {
                _abilityScores = value;
            }
        }

        public int[] SkillBonuses
        {
            get
            {
                return _skillBonuses;
            }
            set
            {
                _skillBonuses = value;
            }
        }

        public bool[] SkillProficiencies
        {
            get
            {
                return _skillProficiencies;
            }
            set
            {
                _skillProficiencies = value;
            }
        }

        public Class CharacterClass
        {
            get
            {
                return characterClass;
            }
            set
            {
                characterClass = value;
            }
        }

        public int getProficiency()
        {
            if (_level <= 4)
                return 2;
            else if (_level <= 8)
                return 3;
            else if (_level <= 11)
                return 4;
            else if (_level <= 16)
                return 5;
            else if (_level <= 20)
                return 6;
            else
                return 0;
        }
        public void changeStat(AbilityScore name, int newValue)
        {
            AbilityScores[(int)name] = newValue;

            SkillBonuses[(int)SkillBonus.Athletics] = AbilityScores[(int)AbilityScore.Strength];

            for (int i = (int)SkillBonus.Acrobatics; i < (int)SkillBonus.Arcana; i++)
            {
                SkillBonuses[i] = (AbilityScores[(int)AbilityScore.Dexterity] - 10)/2;
                if (SkillProficiencies[i])
                    SkillBonuses[i] += getProficiency();
            }
            for (int i = (int)SkillBonus.Arcana; i < (int)SkillBonus.AnimalHandling; i++)
            {
                SkillBonuses[i] = (AbilityScores[(int)AbilityScore.Intelligence] - 10) / 2;
                if (SkillProficiencies[i])
                    SkillBonuses[i] += getProficiency();
            }
            for (int i = (int)SkillBonus.AnimalHandling; i < (int)SkillBonus.Survival; i++)
            {
                SkillBonuses[i] = (AbilityScores[(int)AbilityScore.Wisdom] - 10) / 2;
                if (SkillProficiencies[i])
                    SkillBonuses[i] += getProficiency();
            }
            for (int i = (int)SkillBonus.Survival; i <= (int)SkillBonus.Persuasion; i++)
            {
                SkillBonuses[i] = (AbilityScores[(int)AbilityScore.Charisma] - 10) / 2;
                if (SkillProficiencies[i])
                    SkillBonuses[i] += getProficiency();
            }

            SkillBonuses = SkillBonuses;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SkillBonuses"));

        }
        public void changeClass(string name)
        {
            characterClass.getClass(name);
            changeStat(AbilityScore.Charisma, AbilityScores[(int)AbilityScore.Charisma]);
        }

        public void calculateAC()
        {
            switch (_armorType)
            {
                case "None":
                    AC = 10 + ((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2);
                    break;
                case "Leather":
                    AC = 11 + ((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2);
                    break;
                case "Studded Leather":
                    AC = 12 + ((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2);
                    break;
                case "Hide":
                    if (((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2) >= 2)
                    {
                        AC = 14;
                        break;
                    }
                    AC = 12 + ((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2);
                    break;
                case "Chain Shirt":
                    if (((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2) >= 2)
                    {
                        AC = 15;
                        break;
                    }
                    AC = 13 + ((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2);
                    break;
                case "Scale Mail":
                    if (((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2) >= 2)
                    {
                        AC = 16;
                        break;
                    }
                    AC = 14 + ((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2);
                    break;
                case "Breastplate":
                    if (((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2) >= 2)
                    {
                        AC = 16;
                        break;
                    }
                    AC = 14 + ((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2);
                    break;
                case "Half Plate":
                    if (((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2) >= 2)
                    {
                        AC = 17;
                        break;
                    }
                    AC = 15 + ((AbilityScores[(int)AbilityScore.Dexterity] - 10) / 2);
                    break;
                case "Ring Mail":
                    AC = 14;
                    break;
                case "Chain Mail":
                    AC = 16;
                    break;
                case "Split":
                    AC = 17;
                    break;
                case "Plate":
                    AC = 18;
                    break;
            }
        }
    }
}
