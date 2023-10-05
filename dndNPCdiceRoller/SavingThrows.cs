using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dndNPCdiceRoller
{
    public class SavingThrows
    {
        readonly int[] Prof = { 0, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7 };
        readonly Random rand = new Random();

        //puts all the pieces together into a string
        public string SaveRead(NPClist.NPC x, string Save, int Ability)
        {
            return $"You roll a {Throw(x, Save, Ability)} on your {Save} roll!";

        }

        //add together a dice roll, Proficiency bonus, and the appropriate ability modifier
        public int Throw(NPClist.NPC x, string Save, int Ability)
        {
            int Bonus;
            if (x.ProficientSaves.Contains(Save)) { Bonus = Prof[x.Level]; }
            else { Bonus = 0; }
            return rand.Next(1,21) + Bonus + AbilityModifier(Ability);
        }

        //turn an ability score into a modifier
        public int AbilityModifier(int Ability)
        {

            if (Ability % 2 == 0) { return (Ability - 10) / 2;}
            else { return (Ability - 11) / 2; }
        }


    }
}
