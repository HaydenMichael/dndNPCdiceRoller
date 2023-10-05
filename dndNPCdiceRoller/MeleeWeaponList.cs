using System;
using System.Windows.Forms;

namespace dndNPCdiceRoller
{
    public class MeleeWeaponsList
    {
        public class Weapon
        {
            public int DamageDiceQuantity = 1;
            public int DamageDiceSize = 1;            
            public string DamageType = "bludgeoning";
            public string[] WeaponTags = { };        
        }

        //Simple Melee Weapons
        public Weapon Club = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 4,
            DamageType = "bludgeoning",
            WeaponTags = new string[] {"light"}
        };

        public Weapon Cutlass = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 6,
            DamageType = "slashing",
            WeaponTags = new string[] { "finesse" }
        };

        public Weapon Dagger = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 4,
            DamageType = "piercing",
            WeaponTags = new string[] { "finesse", "light", "thrown" }
        };

        public Weapon Great_Club = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 8,
            DamageType = "bludgeoning",
            WeaponTags = new string[] { "two-handed" }
        };

        public Weapon Handaxe = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 6,
            DamageType = "slashing",
            WeaponTags = new string[] { "light", "thrown" }
        };

        public Weapon Javelin = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 6,
            DamageType = "slashing",
            WeaponTags = new string[] {"thrown"}
        };

        public Weapon Light_Hammer = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 4,
            DamageType = "bludgeoning",
            WeaponTags = new string[] { "light", "thrown" }
        };

        public Weapon Mace = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 6,
            DamageType = "bludgeoning",
            WeaponTags = new string[] { "" }
        };

        public Weapon Quarterstaff = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 6,
            DamageType = "bludgeoning",
            WeaponTags = new string[] { "light" }
        };

        public Weapon Sickle = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 4,
            DamageType = "slashing",
            WeaponTags = new string[] { "two-handed" }
        };

        public Weapon Spear = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 6,
            DamageType = "piercing",
            WeaponTags = new string[] { "thrown", "versatile(1d8)" }
        };

        public Weapon Thunder_Gauntlet = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 8,
            DamageType = "thunder",
            WeaponTags = new string[] { "taunt" }
        };

        public Weapon Unarmed = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 1,
            DamageType = "bludgeoning",
            WeaponTags = new string[] { }
        };

        //Martial Melee Weapons
        public Weapon Battle_Axe = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 1,
            DamageType = "slashing",
            WeaponTags = new string[] { "two-handed" }
        };

        public Weapon Flail = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 8,
            DamageType = "bludgeoning",
            WeaponTags = new string[] { "two-handed" }
        };

        public Weapon Glaive = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 10,
            DamageType = "slashing",
            WeaponTags = new string[] { "heavy", "reach", "two-handed" }
        };

        public Weapon Great_Axe = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 12,
            DamageType = "slashing",
            WeaponTags = new string[] { "heavy", "two-handed" }
        };

        public Weapon Great_Sword = new Weapon()
        {
            DamageDiceQuantity = 2,
            DamageDiceSize = 6,
            DamageType = "slashing",
            WeaponTags = new string[] { "heavy", "two-handed" }
        };

        public Weapon Halberd = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 10,
            DamageType = "slashing",
            WeaponTags = new string[] { "heavy", "reach", "two-handed" }
        };

        public Weapon Lance = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 12,
            DamageType = "piercing",
            WeaponTags = new string[] { "reach", "special" }
        };

        public Weapon Longsword = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 8,
            DamageType = "slashing",
            WeaponTags = new string[] { "versatile(1d10)" }
        };

        public Weapon Maul = new Weapon()
        {
            DamageDiceQuantity = 2,
            DamageDiceSize = 6,
            DamageType = "bludgeoning",
            WeaponTags = new string[] { "heavy", "two-handed" }
        };

        public Weapon Morning_Star = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 8,
            DamageType = "piercing",
            WeaponTags = new string[] { }
        };

        public Weapon Pike = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 10,
            DamageType = "piercing",
            WeaponTags = new string[] { "heavy", "reach", "two-handed" }
        };

        public Weapon Rapier = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 8,
            DamageType = "piercing",
            WeaponTags = new string[] { "finesse" }
        };

        public Weapon Scimitar = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 6,
            DamageType = "slashing",
            WeaponTags = new string[] { "finesse", "light" }
        };

        public Weapon Shortsword = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 6,
            DamageType = "piercing",
            WeaponTags = new string[] { "finesse", "light" }
        };

        public Weapon Trident = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 6,
            DamageType = "piercing",
            WeaponTags = new string[] { "thrown", "versatile(1d8)" }
        };

        public Weapon War_Pick = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 8,
            DamageType = "piercing",
            WeaponTags = new string[] { }
        };

        public Weapon Warhammer = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 8,
            DamageType = "bludgeoning",
            WeaponTags = new string[] { "versatile(1d10)" }
        };

        public Weapon Whip = new Weapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 4,
            DamageType = "slashing",
            WeaponTags = new string[] { "finesse", "reach" }
        };


    }




}



