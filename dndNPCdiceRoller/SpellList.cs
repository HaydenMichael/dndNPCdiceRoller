using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dndNPCdiceRoller.SpellList;
using System.Windows.Forms;

namespace dndNPCdiceRoller
{
    public class SpellList
    {

        public class Spell
        {
            public string SpellName;
            public string SpellType;
            public int SpellDamageQuantity;
            public int SpellDamageSize;
            public string SpellDamageType;
            public string SpellSaveAbilityScore;
            public string SpellDescription;
            public int SpellRange;
            public int SpellSlotLevel;
        }

        public Spell None = new Spell()
        {
            SpellName = "None",
            SpellType = "None",
            SpellDamageQuantity = 0,
            SpellDamageSize = 0,
            SpellDamageType = "None",
            SpellSaveAbilityScore = "None",
            SpellDescription = "None",
            SpellRange = 0,
            SpellSlotLevel = 0,
        };



        public Spell Burning_Hands = new Spell()
        {
            SpellName = "Burning Hands",
            SpellType = "damage",
            SpellDamageQuantity = 3,
            SpellDamageSize = 6,
            SpellDamageType = "fire",
            SpellSaveAbilityScore = "dexterity",
            SpellDescription = "As you hold your hands with thumbs touching and fingers spread, a thin sheet of flames shoots forth from your outstretched" +
                " fingertips.  Each creature in a 15-foot cone must make a dexterity saving throw.  A creature takes 3d6 fire damage on a failed save, or " +
                "half as much on a successful one.  The fire ignites any flammable objects in the area that aren't being worn or carried.",
            SpellRange = 15,
            SpellSlotLevel = 1
        };

        public Spell Firebolt = new Spell()
        {
            SpellName = "Firebolt",
            SpellType = "damage",
            SpellDamageQuantity = 1,
            SpellDamageSize = 10,
            SpellDamageType = "fire",
            SpellSaveAbilityScore = "spell attack",
            SpellDescription = "You hurl a mote of fire at a creature or object within range.  Make a ranged spell atack against the target." +
                " On a hit, the target takes 1d10 fire damage.  A flammable object hit by this spell ignites if it isn't being worn or carried.  Upgrades " +
                "with an extra die at levels 5, 11, & 17.",
            SpellRange = 120,
            SpellSlotLevel = 0
        };


        public Spell Ray_of_Sickness = new Spell()
        {
            SpellName = "Ray of Sickness",
            SpellType = "damage",
            SpellDamageQuantity = 2,
            SpellDamageSize = 8,
            SpellDamageType = "poision",
            SpellSaveAbilityScore = "spell attack",
            SpellDescription = "A ray of sickening energy lashes out toward a creature within range.  " +
            "Make a ranged spell attack against the target.  On hit, the target takes 2d8 poison damage and must make a Constitution saving throw." +
            "  On failed save, it is also poisoned until the end of your next turn.",
            SpellRange = 120,
            SpellSlotLevel = 1
        };

    }
}
