using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dndNPCdiceRoller
{

    public class SpellRolls
    {
        readonly Random rand = new Random();
        
        //Mostly for a spell description string so I can make it look a little nicer than just passing whatever level it is through as a raw number
        readonly string[] SpellLevels = { "Cantrip", "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6" };

        public string SpellReader(SpellList.Spell x, NPClist.NPC y, int CastLevelIndex)
        {
            if (x != null)
            {
                //if the spell is an attack spell
                if (x.SpellSaveAbilityScore == "attack roll")
                {
                    return $"You rolled a {SpellAttackRoll(y)} on your spell attack roll! On a successful hit, you'll deal {SpellDamage(x, CastLevelIndex)} {x.SpellDamageType} " +
                        $"damage to your target! \n\n{SpellDescription(x)}";
                }

                //if the spell is resisted by an ability score instead and the spell deals damage do this read
                else if (x.SpellSaveAbilityScore != "attack roll" && x.SpellDamageSize != 0)
                {
                    return $"You cast {x.SpellName} and your opponent must resist with a {x.SpellSaveAbilityScore} saving " +
                        $"throw against your spell save DC of {8 + AbilityModifier(SpellAttackModifier(y)) + y.ProfBonuses[y.Level]}!  " +
                        $"On a successful hit, you'll deal {SpellDamage(x, CastLevelIndex)} {x.SpellDamageType} damage! \n\n{SpellDescription(x)}";
                }
                //for non combat spells just read off the spell description
                else return SpellDescription(x);
            }
            //if nothing is selected prompt user to make a selection
            else return "Select a spell!";
           
        }

        //generic spell description string so I don't have to write it out every time
        public string SpellDescription(SpellList.Spell x)
        {
            return $"{x.SpellName}\n\n{SpellLevels[x.SpellSlotLevel]} \n\n{x.SpellDescription}";
        }

        public int SpellAttackModifier(NPClist.NPC x)
        {
            int SpellModifier = 0;
            //Find the relevant stat for casting for the relevant class
            if (x.DnDClass.ToLower() == "fighter" || x.DnDClass.ToLower() == "wizard" || x.DnDClass.ToLower() == "rogue" || x.DnDClass.ToLower() == "artificer") { SpellModifier = x.Intelligence; }
            else if (x.DnDClass.ToLower() == "paladin" || x.DnDClass.ToLower() == "warlock" || x.DnDClass.ToLower() == "sorcerer" || x.DnDClass.ToLower() == "bard") { SpellModifier = x.Charisma; }
            else if (x.DnDClass.ToLower() == "druid" || x.DnDClass.ToLower() == "cleric" || x.DnDClass.ToLower() == "monk" || x.DnDClass.ToLower() == "ranger") { SpellModifier = x.Wisdom; }
            return SpellModifier;            
        }

        //calculate bonus from Ability score
        public int AbilityModifier(int Ability)
        {
            if (Ability % 2 == 0) { return (Ability - 10) / 2; }
            else return (Ability - 11) / 2;
        }

        //roll for a spell to hit its target
        public int SpellAttackRoll(NPClist.NPC x)
        {
            return rand.Next(1, 21) + AbilityModifier(SpellAttackModifier(x)) + x.ProfBonuses[x.Level];
        }

        //damage done if it hits
        public int SpellDamage(SpellList.Spell x, int CastLevelIndex)
        {
            int n = 0;
            int Damage = 0;
            while (n < x.SpellDamageQuantity)
            {
                Damage += rand.Next(1, x.SpellDamageSize + 1);
                n++;
            }
            return Damage + Overcasting(x, CastLevelIndex);
        }

        //extra damage if the spell is cast with a spell slot above its spell level
        public int Overcasting(SpellList.Spell x, int CastLevelIndex)
        {
            int n = 0;
            int Damage = 0;
            int LevelsOvercast = (CastLevelIndex + 1) - x.SpellSlotLevel;
            while (n < LevelsOvercast) 
            {
                Damage += rand.Next(1, x.SpellDamageSize + 1);
                n++;
            }
            return Damage;
        }
    }
}
