using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dndNPCdiceRoller
{
    public class RangedWeaponsList
    {
        public class RangedWeapon
        {
            public int DamageDiceQuantity;
            public int DamageDiceSize;
            public string DamageType = "piercing";
            public string[] WeaponTags = { };
            public int RangeMinimum;
            public int RangeMaximum;
        }

        //simple
        public RangedWeapon Light_Crossbow = new RangedWeapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 8,
            DamageType = "piercing",
            WeaponTags = new string[] { "ammunition", "loading", "two-handed"},
            RangeMinimum = 80,
            RangeMaximum = 320
        };

        public RangedWeapon Dart = new RangedWeapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 4,
            DamageType = "piercing",
            WeaponTags = new string[] { "finesse", "thrown" },
            RangeMinimum = 20,
            RangeMaximum = 60
        };

        public RangedWeapon Shortbow = new RangedWeapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 6,
            DamageType = "piercing",
            WeaponTags = new string[] { "ammunition", "two-handed" },
            RangeMinimum = 80,
            RangeMaximum = 320
        };

        public RangedWeapon Sling = new RangedWeapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 4,
            DamageType = "bludgeoning",
            WeaponTags = new string[] { "ammunition" },
            RangeMinimum = 30,
            RangeMaximum = 120
        };

        //martial
        public RangedWeapon Blowgun = new RangedWeapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 1,
            DamageType = "piercing",
            WeaponTags = new string[] { "ammunition", "loading" },
            RangeMinimum = 25,
            RangeMaximum = 100
        };

        public RangedWeapon Hand_Crossbow = new RangedWeapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 6,
            DamageType = "piercing",
            WeaponTags = new string[] { "ammunition", "light", "loading" },
            RangeMinimum = 30,
            RangeMaximum = 120
        };

        public RangedWeapon Heavy_Crossbow = new RangedWeapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 10,
            DamageType = "piercing",
            WeaponTags = new string[] { "ammunition", "heavy", "loading", "two-handed" },
            RangeMinimum = 100,
            RangeMaximum = 400
        };

        public RangedWeapon Longbow = new RangedWeapon()
        {
            DamageDiceQuantity = 1,
            DamageDiceSize = 8,
            DamageType = "piercing",
            WeaponTags = new string[] { "ammunition", "heavy", "two-handed" },
            RangeMinimum = 150,
            RangeMaximum = 600
        };

        public RangedWeapon Net = new RangedWeapon()
        {
            DamageDiceQuantity = 0,
            DamageDiceSize = 0,
            DamageType = "",
            WeaponTags = new string[] { "ammunition", "loading", "two-handed" },
            RangeMinimum = 5,
            RangeMaximum = 15
        };

    }

}
