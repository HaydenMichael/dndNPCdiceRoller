using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dndNPCdiceRoller
{
    public class SkillRolls
    {
        readonly Random rand = new Random();

        readonly string[] DexteritySkills = {"acrobatics", "sleight of hand", "stealth" };
        readonly string[] StrengthSkills = { "athletics" };
        readonly string[] IntelligenceSkills = {"arcana", "history", "investigation", "nature", "religion" };
        readonly string[] WisdomSkills = { "animal handling", "insight", "medicine", "perception", "survival" };
        readonly string[] CharismaSkills = { "deception", "intimidation", "performance", "persuasion"};

        public string SkillRead(string Skill, NPClist.NPC n)
        {
            return $"You rolled a {SkillCheck(Skill, n)} on your {Skill} roll!";
        }

        public string Initiative(NPClist.NPC n)
        {
            return $"You rolled {rand.Next(1,21) + Calc(n.Dexterity)} on your initiative roll!";
        }

        private int AbilityScore(string Skill, NPClist.NPC n)
        {
            Skill = Skill.ToLower();
            int x = 0;
            if (DexteritySkills.Contains(Skill)) { x = n.Dexterity; }
            else if (StrengthSkills.Contains(Skill)) { x = n.Strength; }
            else if (IntelligenceSkills.Contains(Skill)) { x = n.Intelligence; }
            else if (WisdomSkills.Contains(Skill)) { x = n.Wisdom; }
            else if (CharismaSkills.Contains(Skill)) { x = n.Charisma; }
            return Calc(x);          
        }

        private int Calc(int x)
        {
            if (x % 2 == 0) { return ((x - 10) / 2); }
            else { return ((x - 11) / 2); }
        }

        private int SkillCheck(string Skill, NPClist.NPC n)
        {
            int[] ProfBonuses = { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6 };
            int Prof = 0;
            if (n.ProficientSkills.Contains(Skill))
            {
                Prof = ProfBonuses[n.Level];
            }
            return rand.Next(1, 21) + Prof + AbilityScore(Skill, n);
        }



    }
}
