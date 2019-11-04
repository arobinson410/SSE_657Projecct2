using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSE657_Project1;
using System;
using System.ComponentModel;

namespace Project2_Unit_Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CheckChangeClass() //Checks Class Changes
        {
            const string classToChangeTo = "Warlock";

            Character character = new Character();
            character.changeClass(classToChangeTo);
            string newClassName = character.CharacterClass.ClassName;

            Assert.AreEqual(classToChangeTo, newClassName);
        }

        [TestMethod]
        public void CheckProficiency() //Checks Get Proficiency Method
        {
            Character character = new Character();
            character.changeClass("Warlock");
            Random random = new Random();

            int testVal = (random.Next() % 20) + 1;
            Console.WriteLine("Testing Level: " + testVal);

            character.Level = testVal;
            int proficiencyMod = character.getProficiency();

            if (testVal <= 4)
                Assert.AreEqual(2, proficiencyMod);
            else if (testVal <= 8)
                Assert.AreEqual(3, proficiencyMod);
            else if (testVal <= 11)
                Assert.AreEqual(4, proficiencyMod);
            else if (testVal <= 16)
                Assert.AreEqual(5, proficiencyMod);
            else if (testVal <= 20)
                Assert.AreEqual(6, proficiencyMod);
            else
                Assert.AreEqual(1, proficiencyMod);
        } 

        [TestMethod]
        public void CheckSkillBonus()//Checks changes to Ability Score and Skill Bonues
        {
            Character character = new Character();
            character.changeClass("Warlock");

            character.PropertyChanged += CheckSkillBonusHandler;

            character.changeStat(Character.AbilityScore.Charisma, 18);

            if (character.SkillBonuses[14] != 4 || character.SkillBonuses[15] != 4 || character.SkillBonuses[16] != 4)
                Assert.IsTrue(false);

        }
        
        private void CheckSkillBonusHandler(object sender, PropertyChangedEventArgs e)//Helper method to determine if event is sucessfully called
        {
            if(e.PropertyName == "SkillBonuses")
                Assert.IsTrue(true);
        }

        [TestMethod]
        public void CheckArmorClass()
        {
            Character character = new Character();
            character.changeClass("Warlock");
            character.changeStat(Character.AbilityScore.Dexterity, 13);

            character.ArmorType = "System.Windows.Controls.ComboBoxItem: Half Plate";
            character.calculateAC();

            Assert.AreEqual(16, character.AC);
        }

        [TestMethod]
        public void CheckAbilityModifier()
        {
            AbilityModConverter abilityModConverter = new AbilityModConverter();
            int mod = int.Parse(abilityModConverter.Convert(17, typeof(String), null, System.Globalization.CultureInfo.CurrentCulture).ToString());
            Assert.AreEqual(3, mod);
        }
    }
}
