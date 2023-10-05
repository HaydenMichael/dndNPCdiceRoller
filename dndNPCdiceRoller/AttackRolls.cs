using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dndNPCdiceRoller
{
    public class AttackRolls
    {
        readonly Random rand = new Random();
        readonly int[] Prof = { 0, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7 };

        //melee attack rolls, takes into account finesse (whether or not a weapon uses dexterity or strength for its attack roll and damage bonus
        public string MeleeReader(NPClist.NPC x, MeleeWeaponsList.Weapon y)
        {
            return $"You rolled a {MeleeAttackRoll(x,y)} on your attack roll!  On a successful hit you will deal {MeleeDamageRoll(x, y)} {y.DamageType} damage!";
        }
        
        public int MeleeAttackRoll(NPClist.NPC x, MeleeWeaponsList.Weapon y)
        {            
            int ProfBonus = Prof[x.Level];

            return rand.Next(1, 21) + AbilityScoreBonus(AttackAbilityScore(x, y)) + ProfBonus;
        }


        public int MeleeDamageRoll(NPClist.NPC x, MeleeWeaponsList.Weapon y)
        {
            int DamageDiceQuantity = y.DamageDiceQuantity;
            int DamageDiceSize = y.DamageDiceSize;
            int n = 0;
            int Damage = 0;
            while (n < DamageDiceQuantity)
            {
                Damage += rand.Next(1, DamageDiceSize + 1);
                n++;
            }
            return Damage + AbilityScoreBonus(AttackAbilityScore(x, y));
        }

        public int AttackAbilityScore(NPClist.NPC x, MeleeWeaponsList.Weapon y)
        {
            if (y.WeaponTags.Contains("finesse") && x.Dexterity >= x.Strength)
            {
                return x.Dexterity;
            }
            else return x.Strength;
        }

        //Ranged attack rolls, Attack Roll and Damage both feed into the reader which is then used in the main form

        public string RangedReader(NPClist.NPC x, RangedWeaponsList.RangedWeapon y)
        {
            return $"You roll a {RangedAttackRoll(x)} on your ranged attack roll!  On hit the attack will deal {RangedAttackDamage(x, y)} {y.DamageType} damage!";
        }

        public int RangedAttackRoll(NPClist.NPC x)
        {
            return rand.Next(1,21) + AbilityScoreBonus(x.Dexterity) + Prof[x.Level];
        }

        public int RangedAttackDamage(NPClist.NPC x, RangedWeaponsList.RangedWeapon y)
        {
            int n = 0;
            int Damage = 0;
            while (n < y.DamageDiceQuantity)
            {
                Damage += rand.Next(1, y.DamageDiceSize);
                n++;
            }
            return Damage + AbilityScoreBonus(x.Dexterity);
        }

        // Ability Score => Ability Score Modifier
        public int AbilityScoreBonus(int x)
        {
            if (x % 2 == 0)
            {
                return (x - 10) / 2;
            }
            else return (x - 11) / 2;
        }

        //pass an extra bit on the end for sneak attack damage
        public string SneakAttack(NPClist.NPC x, bool SneakAttackBoxChecked)
        {
            int Damage = 0;
            int[] SneakAttackDice = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10}; //how many Sneak Attack dice you get per level
            if (SneakAttackBoxChecked == false) { return ""; }
            else
            {
                int n = 0;
                while (n < SneakAttackDice[x.Level-1])
                {
                    Damage += rand.Next(1, 6);
                    n++;
                }
                return $"\n\nYou deal an additional {Damage} damage from your sneak attack!";
            }

        }
    }

}
