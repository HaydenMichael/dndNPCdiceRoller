using System;
using dndNPCdiceRoller;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


//<Summary>
//      To make a new npc:  (1) Add the NPC to this list as a new npc following the format public NPC Name = new NPC() {};
//                          (2) Add the name of the NPC to the NPCselectorComboBox in Form1.cs [Design] (Properties -> Items -> Collection -> Click 3 dots on the right)
//                          (3) Go to the Form1.cs document and to the FindCharacter method and add the npc's name from the combobox in all lowercase letters
//                          ------------------------------------------------------------------------------------------------------------------------------------------
//                          EXTRA (4) Make sure that you've added the spells the NPC uses to SpellList.cs
//</Summary>

namespace dndNPCdiceRoller
{

    public class NPClist
    {
        public static MeleeWeaponsList mwl = new MeleeWeaponsList();
        public static RangedWeaponsList rwl = new RangedWeaponsList();

        //can pass these into the proficient saving throws without having to remember
        ///what the saves are for each class
        static public string[] FighterSaves = { "Strength", "Constitution" };

        public class NPC
        {
            public int[] ProfBonuses = { 0, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7 };
            public int HP = 10;
            public int AC = 10;
            public string DnDClass = "";
            public int Level = 1;
            public int Strength = 10;
            public int Dexterity = 10;
            public int Constitution = 10;
            public int Intelligence = 10;
            public int Wisdom = 10;
            public int Charisma = 10;
            public string[] SpellList = { };
            public MeleeWeaponsList.Weapon WeaponMelee;
            public RangedWeaponsList.RangedWeapon WeaponRanged;
            public MeleeWeaponsList.Weapon WeaponOffhand;
            public int Speed = 25;
            public string[] Feats = { };
            public string[] ProficientSkills = { };
            public string[] ProficientSaves = FighterSaves;
            public string[] ProficientWeapons = { };
            
        }


        public NPC Acolyte = new NPC()
        {
            HP = 15,
            AC = 12,
            DnDClass = "fighter",
            Level = 1,
            Strength = 12,
            Dexterity = 10,
            Constitution = 12,
            Intelligence = 10,
            Wisdom = 8,
            Charisma = 10,
            SpellList = new string[] { },
            WeaponMelee = mwl.Club,
            WeaponRanged = rwl.Shortbow,
            Speed = 25,
            Feats = new string[] { "Defensive Duelist" },
            ProficientSkills = new string[] { "Athletics", "Intimidation" },
            ProficientSaves = new string[] { "Constitution", "Strength" },
            ProficientWeapons = new string[] { }
        };


        public NPC Duelist = new NPC()
        {
            HP = 45,
            AC = 14,
            DnDClass = "Fighter",
            Level = 4,
            Strength = 10,
            Dexterity = 18,
            Constitution = 14,
            Intelligence = 12,
            Wisdom = 8,
            Charisma = 14,
            SpellList = new string[] {"Ray of Sickness", "Burning Hands"},
            WeaponMelee = mwl.Rapier,
            WeaponRanged = rwl.Shortbow,
            Speed = 25,
            Feats = new string[] {"Defensive Duelist"},
            ProficientSkills = new string[] { "Athletics", "Intimidation"},
            ProficientSaves = FighterSaves,
            ProficientWeapons = new string[] {}
        };



    }




}