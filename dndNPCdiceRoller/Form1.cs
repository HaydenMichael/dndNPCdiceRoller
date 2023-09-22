using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dndNPCdiceRoller
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int HP, AC, strength, dexterity, constitution, intelligence, wisdom, charisma, spellSaveDC, proficiencyBonus, speed, rollResult, profAttackBonus, damageDiceQuantity, damageDiceSize, damageResult, spellDamageDiceSize, spellDamageDiceQuantity, spellRange, characterLevel, spellSlotLevel;
        string dndClass, weaponRanged, weaponMelee, weaponProficiencies, feats, proficientSkills, proficientSaves, rollInQuestion, damageType, weaponTags, abilities, weaponOffhand, saveAgainstSpell, spellDescription, spellDamageType, spellName, spellType;
        bool blessed, baned;
        string[] spellList;
        int[] testCase;

        string[] skillList = {"Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation", "Investigation", "Medicine", "Nature", "Perception",
        "Performance", "Persuasion", "Religion", "Sleight of Hand", "Stealth", "Survival"};
        //class saves
        string artificerSaves = "constitution, intelligence";
        string barbarianSaves = "strength, constitution";
        string bardSaves = "dexterity, charisma";
        string clericSaves = "wisdom, charisma";
        string druidSaves = "intelligence, wisdom";
        string fighterSaves = "strength, constitution";
        string monkSaves = "strength, dexterity";
        string paladinSaves = "wisdom, charisma";
        string rangerSaves = "strength, dexterity";
        string rogueSaves = "dexterity, intelligence";
        string sorcererSaves = "constitution, charisma";
        string warlockSaves = "wisdom, charisma";
        string wizardSaves = "intelligence, wisdom";

        //proficiency Bonus Progression

        int[] proficiencyBonusByLevel = { 0, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6 };

        private void NPCselectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            findCharacter();
            spellListActivator();
            spellListComboBox.Text = "";
            spellSaveDCtarget.Text = returnSpellSaveDC().ToString();
            targetAC.Text = AC.ToString();
            HPtarget.Text = HP.ToString();
            targetSpeed.Text = speed.ToString();
            featsTarget.Text = feats;  
            targetProfBonus.Text = proficiencyBonus.ToString();
        }

        public Form1()
        {
            InitializeComponent();
            defaultReset();
            spellListActivator();
            showSpellSlotLevels();
            ShowHideSneakAttackCheckBox();
            acolyte();
        }

        // this will be one of the most important functions as it will make rolls happen, so it will have a lot of functions that work off of it
        private void buttonRoll_Click(object sender, EventArgs e)
        {
            findRoll();

            if (rollSelectorComboBox.Text == "Spells") {resultTarget.Text = spellRead();}
            else if (rollSelectorComboBox.Text == "Skill Checks") { resultTarget.Text = SkillReader();  }
            else if (rollSelectorComboBox.Text == "Melee Attack" || rollSelectorComboBox.Text == "Ranged Attack")
            {
                resultTarget.Text = $"You rolled a {rollResult.ToString()} on your attack roll!  You dealt {damageResult.ToString()} {damageType} damage. {SneakAttackRead()}";
            }
            else
            {
                resultTarget.Text = "You rolled a " + rollResult.ToString() + " on your " + rollSelectorComboBox.Text + " roll!";
            }
        }

        private void spellListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            spellSelector();
            showSpellSlotLevels();
        }

        private void spellListActivator()
        {
            if (rollSelectorComboBox.Text == "Spells") { spellListComboBox.Show(); getCharacterSpells(); }
            else if (rollSelectorComboBox.Text == "Skill Checks") { spellListComboBox.Show(); GetSkillsList(); }
            else { spellListComboBox.Hide(); }
            
        }

        private void ShowHideSneakAttackCheckBox()
        {
            if (rollSelectorComboBox.Text == "Melee Attack" || rollSelectorComboBox.Text == "Ranged Attack") { sneakAttackCheckBox.Show(); }
            else
            {
                sneakAttackCheckBox.Checked = false;
                sneakAttackCheckBox.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        //                                                              ---SECTION 1: NPC's---
        //a list of all characters described as functions
        private void findCharacter()
        {
            if (NPCselectorComboBox.Text == "Acolyte") {acolyte();}
            if (NPCselectorComboBox.Text == "Bandit Rogue") { bandit_rogue(); }
            if (NPCselectorComboBox.Text == "Bandit Mastermind") { bandit_mastermind(); }
            if (NPCselectorComboBox.Text == "Tank Fighter") { tankFighter(); }
            if (NPCselectorComboBox.Text == "Duelist") { duelist(); }
            if (NPCselectorComboBox.Text == "Vrasza Yrm Shocktrooper") { vrasza_yrm_shocktrooper(); }
            if (NPCselectorComboBox.Text == "Vrasza Yrm Pike Guard") { vrasza_yrm_pikesguard(); }
            if (NPCselectorComboBox.Text == "Bandit Thug") { bandit_thug(); }
        }
        
        private void defaultReset()
        {
            HP = 0;
            AC = 0;
            strength = 10;
            dexterity = 10;
            constitution = 10;
            intelligence = 10;
            wisdom = 10;
            charisma = 10;
            proficiencyBonus = 2;
            dndClass = "fighter";
            spellList = new string[] { };
            weaponRanged = "";
            weaponMelee = "";
            weaponOffhand = "";
            speed = 25;
            feats = "";
            proficientSkills = "";
            proficientSaves = "";
            weaponProficiencies = "";
        }

        private void acolyte()
        {
            characterLevel = 5;
            HP = 15;
            AC = 10;  
            strength = 10;
            dexterity = 10;
            constitution = 10;
            intelligence = 10;
            wisdom = 10;
            charisma = 10;
            proficiencyBonus = proficiencyBonusByLevel[characterLevel];
            dndClass = "fighter";
            spellList = new string[] {};
            weaponRanged = "shortbow";
            weaponMelee = "dagger";
            weaponOffhand = "";
            speed = 25;
            feats = "";
            abilities = "";
            proficientSkills = "";
            proficientSaves = fighterSaves;            
        }

        private void bandit_mastermind()
        {
            characterLevel = 4;
            HP = 25;
            AC = 15;
            strength = 8;
            dexterity = 15;
            constitution = 12;
            intelligence = 14;
            wisdom = 10;
            charisma = 14;
            proficiencyBonus = proficiencyBonusByLevel[characterLevel];
            dndClass = "rogue";
            spellList = new string[] { };
            weaponRanged = "shortbow";
            weaponMelee = "scimitar";
            weaponOffhand = "";
            speed = 25;
            feats = "bonus action: help";
            proficientSkills = "athletics, intimidation, persuasion, deception, sleight of hand";
            proficientSaves = rogueSaves;
        }

        private void bandit_rogue()
        {
            characterLevel = 4;
            HP = 23;
            AC = 13;
            strength = 10;
            dexterity = 17;
            constitution = 12;
            intelligence = 12;
            wisdom = 10;
            charisma = 10;
            proficiencyBonus = proficiencyBonusByLevel[characterLevel];
            dndClass = "rogue";
            spellList = new string[] { };
            weaponRanged = "shortbow";
            weaponMelee = "dagger";
            weaponOffhand = "";
            speed = 25;
            feats = "sneak attack";
            proficientSkills = "sneak, deception, sleight of hand";
            proficientSaves = rogueSaves;
        }

        private void bandit_thug()
        {
            characterLevel = 4;
            HP = 28;
            AC = 14;
            strength = 16;
            dexterity = 10;
            constitution = 14;
            intelligence = 8;
            wisdom = 8;
            charisma = 10;
            proficiencyBonus = proficiencyBonusByLevel[characterLevel];
            dndClass = "fighter";
            spellList = new string[] { };
            weaponRanged = "shortbow";
            weaponMelee = "club";
            weaponOffhand = "";
            speed = 25;
            feats = "";
            proficientSkills = "athletics, intimidation";
            proficientSaves = fighterSaves;
        }

        private void duelist()
        {
            characterLevel = 4;
            HP = 45;
            AC = 16;
            strength = 10;
            dexterity = 18;
            constitution = 12;
            intelligence = 12;
            wisdom = 8;
            charisma = 14;
            proficiencyBonus = proficiencyBonusByLevel[characterLevel];
            dndClass = "fighter";
            spellList = new string[] {};
            weaponRanged = "shortbow";
            weaponMelee = "rapier";
            weaponOffhand = "";
            speed = 25;
            feats = "defensive duelist";
            proficientSkills = "athletics, intimidation";
            proficientSaves = fighterSaves;
        }

        private void tankFighter()
        {
            characterLevel = 4;
            HP = 30;
            AC = 14;
            strength = 14;
            dexterity = 12;
            constitution = 14;
            intelligence = 8;
            wisdom = 8;
            charisma = 10;
            proficiencyBonus = proficiencyBonusByLevel[characterLevel];
            dndClass = "fighter";
            spellList = new string[] { };
            weaponRanged = "shortbow";
            weaponMelee = "flail";
            speed = 25;
            feats = "";
            proficientSkills = "athletics";
            proficientSaves = fighterSaves;
        }

        private void vrasza_yrm_pikesguard()
        {
            characterLevel = 4;
            HP = 25;
            AC = 13;
            strength = 16;
            dexterity = 12;
            constitution = 14;
            intelligence = 10;
            wisdom = 10;
            charisma = 10;
            proficiencyBonus = 2;
            dndClass = "fighter";
            spellList = new string[] { "" };
            weaponRanged = "shortbow";
            weaponMelee = "pike";
            speed = 25;
            feats = "polearm master";
            proficientSkills = "athletics";
            proficientSaves = fighterSaves;
        }

        private void vrasza_yrm_shocktrooper()
        {
            characterLevel = 4;
            HP = 25;
            AC = 16;
            strength = 14;
            dexterity = 12;
            constitution = 14;
            intelligence = 16;
            wisdom = 8;
            charisma = 10;
            proficiencyBonus = 2;
            dndClass = "artificer";
            spellList = new string[] { "Ray of Sickness" };
            weaponRanged = "shortbow";
            weaponMelee = "thunder gauntlet";
            speed = 25;
            feats = "";
            proficientSkills = "athletics";
            proficientSaves = artificerSaves;
        }

        //                                                                  ---SECTION 2: Weapons---
        //a list of available weapons
        private void findMeleeWeapon()
        {
            if (weaponMelee == "dagger") { dagger(); }
            if (weaponMelee == "cutlass") { cutlass(); }
            if (weaponMelee == "club") { club(); }
            if (weaponMelee == "greatclub") { greatclub(); }
            if (weaponMelee == "handaxe") { handaxe(); }
            if (weaponMelee == "javelin") { javelin(); }
            if (weaponMelee == "light hammer") { lighthammer(); }
            if (weaponMelee == "mace") { mace(); }
            if (weaponMelee == "quarterstaff") { quarterstaff(); }
            if (weaponMelee == "spear") { spear(); }
            if (weaponMelee == "unarmed" || weaponMelee == "") { unarmed(); }
            if (weaponMelee == "battleaxe") { battleaxe(); }
            if (weaponMelee == "flail") { flail(); }
            if (weaponMelee == "glaive") { glaive(); }
            if (weaponMelee == "greataxe") { greataxe(); }
            if (weaponMelee == "greatsword") { greatsword(); }
            if (weaponMelee == "halberd") { halberd(); }
            if (weaponMelee == "lance") { lance(); }
            if (weaponMelee == "longsword") { longsword(); }
            if (weaponMelee == "maul") { maul(); }
            if (weaponMelee == "morningstar") { morningstar(); }
            if (weaponMelee == "pike") { pike(); }
            if (weaponMelee == "rapier") { rapier(); }
            if (weaponMelee == "scimitar") { scimitar(); }
            if (weaponMelee == "shortsword") { shortsword(); }
            if (weaponMelee == "thunder gauntlet") { thunder_gauntlet(); }
            if (weaponMelee == "trident") { trident(); }
            if (weaponMelee == "war pick") { warpick(); }
            if (weaponMelee == "warhammer") { warhammer(); }
            if (weaponMelee == "whip") { whip(); }
        }

        private void findRangedWeapon()
        {
            if (weaponRanged == "shortbow") { shortbow(); }
            if (weaponRanged == "blowgun") { blowgun(); }
            if (weaponRanged == "hand crossbow") { handcrossbow(); }
            if (weaponRanged == "heavy crossbow") { heavycrossbow(); }
            if (weaponRanged == "longbow") { longbow(); }
            if (weaponRanged == "net") { net(); }
        }

        //melee weapons
        private void club()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 4;
            damageType = "bludgeoning";
            weaponTags = "light";
        }

        private void cutlass()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 6;
            damageType = "slashing";
            weaponTags = "finesse";
        }

        private void dagger()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 4;
            damageType = "piercing";
            weaponTags = "finesse, light, thrown";
        }

        private void greatclub()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 8;
            damageType = "bludgeoning";
            weaponTags = "two-handed";
        }

        private void handaxe()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 6;
            damageType = "slashing";
            weaponTags = "light, thrown";
        }

        private void javelin()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 6;
            damageType = "slashing";
            weaponTags = "thrown";
        }

        private void lighthammer()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 4;
            damageType = "bludgeoning";
            weaponTags = "light, thrown";
        }

        private void mace()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 6;
            damageType = "bludgeoning";
            weaponTags = "";
        }

        private void quarterstaff()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 6;
            damageType = "bludgeoning";
            weaponTags = "light";
        }

        private void sickle()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 4;
            damageType = "slashing";
            weaponTags = "two-handed";
        }

        private void spear()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 6;
            damageType = "piercing";
            weaponTags = "thrown, versatile(1d8)";
        }

        private void thunder_gauntlet()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 8;
            damageType = "thunder";
            weaponTags = "taunt";
        }

        private void unarmed()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 1;
            damageType = "bludgeoning";
            weaponTags = "";
        }

        //martial
        private void battleaxe()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 8;
            damageType = "slashing";
            weaponTags = "two-handed";
        }

        private void flail()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 8;
            damageType = "bludgeoning";
            weaponTags = "";
        }

        private void glaive()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 10;
            damageType = "slashing";
            weaponTags = "heavy, reach, two-handed";
        }

        private void greataxe()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 12;
            damageType = "slashing";
            weaponTags = "heavy, two-handed";
        }

        private void greatsword()
        {
            damageDiceQuantity = 2;
            damageDiceSize = 6;
            damageType = "slashing";
            weaponTags = "heavy, two-handed";
        }

        private void halberd()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 10;
            damageType = "slashing";
            weaponTags = "heavy, reach, two-handed";
        }

        private void lance()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 12;
            damageType = "piercing";
            weaponTags = "reach, special";
        }

        private void longsword()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 8;
            damageType = "slashing";
            weaponTags = "versatile(1d10)";
        }
        private void maul()
        {
            damageDiceQuantity = 2;
            damageDiceSize = 6;
            damageType = "bludgeoning";
            weaponTags = "heavy, two-handed";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (blessedCheckbox.Checked == true){blessed = true;}
            else {blessed = false;}
        }

        private void morningstar()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 8;
            damageType = "piercing";
            weaponTags = "";
        }

        private void baneCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (baneCheckbox.Checked == true) { }
        }

        private void pike()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 10;
            damageType = "piercing";
            weaponTags = "heavy, reach, two-handed";
        }

        private void rollSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            spellListActivator();
            showSpellSlotLevels();
            ShowHideSneakAttackCheckBox();
        }

        private void rapier()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 8;
            damageType = "piercing";
            weaponTags = "finesse";
        }

        private void scimitar()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 6;
            damageType = "slashing";
            weaponTags = "finesse, light";
        }

        private void shortsword()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 6;
            damageType = "piercing";
            weaponTags = "finesse, light";
        }

        private void trident()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 6;
            damageType = "piercing";
            weaponTags = "thrown, versatile(1d8)";
        }

        private void warpick()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 8;
            damageType = "piercing";
            weaponTags = "";
        }

        private void warhammer()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 8;
            damageType = "bludgeoning";
            weaponTags = "versatile(1d10)";
        }

        private void whip()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 4;
            damageType = "slashing";
            weaponTags = "finesse, reach";
        }

        //ranged weapons
        private void shortbow()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 6;
            damageType = "piercing";
            weaponTags = "two-handed";
        }
        private void blowgun()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 1;
            damageType = "piercing";
            weaponTags = "loading";
        }

        private void handcrossbow()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 6;
            damageType = "piercing";
            weaponTags = "light, loading";
        }

        private void heavycrossbow()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 10;
            damageType = "piercing";
            weaponTags = "heavy, loading, two-handed";
        }

        private void longbow()
        {
            damageDiceQuantity = 1;
            damageDiceSize = 8;
            damageType = "piercing";
            weaponTags = "heavy, two-handed";
        }

        private void net()
        {
            damageDiceQuantity = 0;
            damageDiceSize = 0;
            damageType = "piercing";
            weaponTags = "special, thrown";
        }

        //create a die
        private int d20() { return rnd.Next(1, 21); }
        private int anyDice(int lowEnd, int highEnd) { return rnd.Next(lowEnd, (highEnd + 1)); }

        //all my roll functions should be organized here:
        private void findRoll()
        {
            if (rollSelectorComboBox.Text == "Initiative") { initiativeRoll(); }
            else if (rollSelectorComboBox.Text == "Strength Save") { savingThrow(strength, "strength"); }
            else if (rollSelectorComboBox.Text == "Dexterity Save") { savingThrow(dexterity, "dexterity"); }
            else if (rollSelectorComboBox.Text == "Constitution Save") { savingThrow(constitution, "constitution"); }
            else if (rollSelectorComboBox.Text == "Intelligence Save") { savingThrow(intelligence, "intelligence"); }
            else if (rollSelectorComboBox.Text == "Wisdom Save") { savingThrow(wisdom, "wisdom"); }
            else if (rollSelectorComboBox.Text == "Charisma Save") { savingThrow(charisma, "charisma"); }
            else if (rollSelectorComboBox.Text == "Melee Attack") { rollResult = meleeAttackRoll(weaponMelee); damageResult = meleeDamageRoll(); }
            else if (rollSelectorComboBox.Text == "Ranged Attack") { rollResult = rangedAttackRoll(weaponRanged); damageResult = rangedAttackDamage(); }
            else if (rollSelectorComboBox.Text == "Spell Attack") { rollResult = spellAttackRoll(); }
            else if (rollSelectorComboBox.Text == "Spells") { spellSelector(); spellRead(); }
        }

        public int initiativeRoll()
        {
            int initiative;
            initiative = returnAbilityModifier(dexterity) + d20() + Alert();
            return rollResult = initiative;
        }

        //dealing with spell lists :o

        private void getCharacterSpells()
        {
           spellListComboBox.Items.Clear();
           foreach (string element in spellList) { spellListComboBox.Items.Add(element); }
        }

        private void GetSkillsList()
        {
            spellListComboBox.Items.Clear();
            foreach (string element in skillList) { spellListComboBox.Items.Add(element); }
        }

        //spell effects

        public int sumAttackRollModifiers()
        {
            return baneEffect() + blessEffect();
        }


        public int blessEffect()
        {
            if (blessed == true) { return anyDice(1, 4); }
            else return 0;
        }

        public int baneEffect()
        {
            if (baned == true) { return -anyDice(1, 4); }
            else return 0;
        }

        //uses this basic formula for all saving throws
        public int savingThrow(int ability, string saveProficient)
        {
            int saveBonus;
            if (proficientSaves.Contains(saveProficient))
            {
                saveBonus = proficiencyBonus;
            } 
            else saveBonus= 0;
            return rollResult = d20() + returnAbilityModifier(ability) + saveBonus + blessEffect() + baneEffect();
        }


        //SECTION 3: Attack Rolls
        public int meleeAttackRoll(string weapon)
        {
            findMeleeWeapon();
            int meleeAttack;
            profAttackBonus = weaponProficiency(weapon);
            meleeAttack = d20() + finesseCheck() + profAttackBonus + sumAttackRollModifiers();
            return meleeAttack;
        }

        public int meleeDamageRoll()
        {
            findMeleeWeapon();
            int damageDice = 0;
            int n = 0;
            while (n < damageDiceQuantity)
            {
                damageDice += anyDice(1, damageDiceSize);
                n++;
            }
            return damageDice + finesseCheck();
        }

        public int rangedAttackRoll(string weapon)
        {
            findRangedWeapon();
            int rangedAttack;
            profAttackBonus = weaponProficiency(weapon);
            rangedAttack = d20() + returnAbilityModifier(dexterity) + profAttackBonus + sumAttackRollModifiers();
            return rangedAttack;
        }

        public int rangedAttackDamage()
        {
            findRangedWeapon();
            int rangedDamage;
            int damageDice = 0;
            int n = 0;
            while (n < damageDiceQuantity)
            {
                damageDice += anyDice(1, damageDiceSize);
                n++;
            }
            rangedDamage = damageDice + returnAbilityModifier(dexterity);
            return rangedDamage;
        }

        public int spellAttackRoll()
        {
            int spellAttack;
            spellAttack = d20() + proficiencyBonus + returnAbilityModifier(classSpellCastingModifier()) + sumAttackRollModifiers(); ;
            return spellAttack;
        }

        //functions that occur when the character selection is changed



        //grab other necessary information for calculations
        public int classSpellCastingModifier()
        {
            if (dndClass == "paladin" || dndClass == "warlock" || dndClass == "sorcerer" || dndClass == "bard")
            {
                return charisma;
            }
            else if (dndClass == "wizard" || dndClass == "fighter" || dndClass == "rogue" || dndClass == "artificer")
            {
                return intelligence;
            }
            else if (dndClass == "druid" || dndClass == "cleric" || dndClass == "monk" || dndClass == "ranger")
            {
                return wisdom;
            }

            else return 0;
        }

        public int returnAbilityModifier(int ability)
        {
            int abilityModifier;
            if (ability % 2 == 0)
            {
                abilityModifier = (ability - 10) / 2;
            }
            else
            {
                abilityModifier = (ability - 11) / 2;
            }           
            return abilityModifier;
        }

        //dealing with proficiencies
        public int weaponProficiency(string weapon)
        {
            if (weaponProficiencies.Contains(weapon)) { return proficiencyBonus; }
            else return 0;
        }

        public int skillProficiencyBonus(string skill)
        {
            if (proficientSkills.Contains(skill)) { return proficiencyBonus; }
            else return 0;
        }

        //dealing with finesse
        public int finesseCheck()
        {
            if (weaponTags.Contains("finesse")  && (dexterity >= strength))
            {
                return returnAbilityModifier(dexterity);
            }
            else return returnAbilityModifier(strength);
        }

        //perks

        public int Alert()
        {
            if (feats.Contains("alert")) { return 4; }
            else return 0;
        }

        //SECTION 4: Spell Casting

        //complete spell list
        private void spellSelector()
        {
            if (spellListComboBox.Text == "Fire Bolt") { firebolt(); }
            if (spellListComboBox.Text == "Ray of Sickness") { rayOfSickness(); }
            if (spellListComboBox.Text == "Burning Hands") { burningHands(); }
        }

        public int spellDamageRoll()
        {
            int n = 0;
            int totalDamage = 0;
            while (n < spellDamageDiceQuantity)
            {
                totalDamage += anyDice(1, spellDamageDiceSize);
                n++;
            }
            return totalDamage + upCastDamageModifier();
        }

        public int returnSpellSaveDC()
        {
            int spellCastMod = classSpellCastingModifier();
            int abilityModifierSpell = returnAbilityModifier(spellCastMod);
            int spellSave;
            spellSave = 8 + abilityModifierSpell + proficiencyBonus;
            return spellSave;
        }

        //return a string that gives user relevant information about the spell they just cast and the resulting roll
        public string spellRead()
        {
            string[] spellLvls = {"Cantrip", "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6" };
            if (saveAgainstSpell == "spellattack")
            {
                return "You cast " + spellName + " with a spell attack roll of " + spellAttackRoll().ToString() + ".  It deals " + spellDamageRoll().ToString() + " " + spellDamageType
                    + " damage to its target on hit! \n\nRange: " + spellRange.ToString() + "\n\n" + "Spell Description: \n\n" + spellLvls[spellSlotLevel]+ "\n\n" + spellDescription;
            }
            else if (saveAgainstSpell == "none")
            {
                return "";
            }
            else
            {
                return $"You cast {spellName} against the target's {saveAgainstSpell} saving throw.{stringCheckIfAttackSpell()}\n\nRange: {spellRange}" +
                    $"\n\nSpell Slot: {spellSlotLevel}\n\nDescription:{spellDescription}";
            }
        }

        public string stringCheckIfAttackSpell()
        {
            if (spellDamageDiceSize == 0 || spellDamageDiceQuantity == 0)
            {
                return "";
            }
            else return $"The spell deals {spellDamageRoll()} {spellDamageType} damage to the target on failed saving throw.";
        }

        //make combobox for selecting the spell slot used appear or disappear
        private void showSpellSlotLevels()
        {
            if (rollSelectorComboBox.Text == "Spells" && spellSlotLevel > 0) { comboBoxSpellSlotLevel.Show(); labelSpellSlotUsed.Show(); }
            else { comboBoxSpellSlotLevel.Hide(); labelSpellSlotUsed.Hide(); }           
        }

        //modifier for if the spell is upcast beyond its damage modifier level
        public int upCastDamageModifier()
        {
            int numberOfLevelsUpcast = (comboBoxSpellSlotLevel.SelectedIndex + 1) - spellSlotLevel;
            int n = 0;
            int damage = 0;
            while (n < numberOfLevelsUpcast)
            {
                damage += anyDice(1, spellDamageDiceSize);
                n++;
            }
            return damage;
        }

        private void spellTemplate()
        {
            spellName = "";
            spellType = "";
            spellDamageDiceQuantity = 0;
            spellDamageDiceSize = 0;            
            spellDamageType = "";
            saveAgainstSpell = "";
            spellDescription = "";
            spellRange = 0;
            spellSlotLevel = 0;
        }

        private void burningHands()
        {
            spellName = "burning hands";
            spellType = "damage";
            spellDamageDiceQuantity = 3;
            spellDamageDiceSize = 6;
            spellDamageType = "fire";
            saveAgainstSpell = "dexterity";
            spellDescription = "As you hold your hands with thumbs touching and fingers spread, a thin sheet of flames shoots forth from your outstretched" +
                " fingertips.  Each creature in a 15-foot cone must make a dexterity saving throw.  A creature takes 3d6 fire damage on a failed save, or " +
                "half as much on a successful one.  The fire ignites any flammable objects in the area that aren't being worn or carried.";
            spellRange = 15;
            spellSlotLevel = 1;
        }

        //this makes a good template for standard attack roll cantrips
        private void firebolt()
        {
            spellName = "fire bolt";
            spellType = "damage";
            spellDamageDiceQuantity = 1;
            spellDamageDiceSize = 10;
            //upgrades at certain levels (5, 11, & 17)
            if (characterLevel < 5) { spellDamageDiceQuantity = 1; }
            else if (characterLevel >= 5 && characterLevel < 11) { spellDamageDiceQuantity = 2; }
            else if (characterLevel >= 11 && characterLevel < 17) { spellDamageDiceQuantity = 3;}
            else { spellDamageDiceQuantity = 4; }
            spellDamageType = "fire";
            saveAgainstSpell = "spellattack";
            spellDescription = "You hurl a mote of fire at a creature or object within range.  Make a ranged spell atack against the target." +
                " On a hit, the target takes 1d10 fire damage.  A flammable object hit by this spell ignites if it isn't being worn or carried.  Upgrades " +
                "with an extra die at levels 5, 11, & 17.";
            spellRange = 120;
            spellSlotLevel = 0;
        }

        private void rayOfSickness()
        {
            spellName = "ray of sickness";
            spellType = "damage";
            spellDamageDiceQuantity = 2;
            spellDamageDiceSize = 8;            
            spellDamageType = "poison";
            saveAgainstSpell = "spellattack";
            spellDescription = "A ray of sickening energy lashes out toward a creature within range.  Make a ranged spell attack against the target" +
                ".  On hit, the target takes 2d8 poison damage and must make a Constitution saving throw.  On failed save, it is also poisoned until" +
                " the end of your next turn.";
            spellRange = 60;
            spellSlotLevel = 1;
        }





        //skill checks
        

        private string SkillReader()
        {
            string skill = (spellListComboBox.Text).ToLower();
            return $"You rolled a {SkillCheckInt(skill)} on your {skill} roll!";           
        }

        private int SkillCheckInt(string skillName)
        {
            int bonus;
            if (proficientSkills.Contains(skillName)) { bonus = proficiencyBonus; }
            else { bonus = 0; }
            return bonus + d20() + AbilityScoreBonusSkillCheck(skillName);
        }

        private int AbilityScoreBonusSkillCheck(string skillName)
        {
            if (skillName.Contains("acrobatics") || skillName.Contains("sleight of hand") || skillName.Contains("stealth")) { return returnAbilityModifier(dexterity); }
            else if (skillName.Contains("athletics")) { return returnAbilityModifier(strength); }
            else if (skillName.Contains("arcana") || skillName.Contains("history") || skillName.Contains("investigation") || skillName.Contains("nature") 
                || skillName.Contains("religion")) { return returnAbilityModifier(intelligence); }
            else if (skillName.Contains("animal handling") || skillName.Contains("insight") || skillName.Contains("medicine") ||
                skillName.Contains("perception") || skillName.Contains("survival")) { return returnAbilityModifier(wisdom); }
            else if (skillName.Contains("deception") || skillName.Contains("intimidation") || skillName.Contains("performance") || skillName.Contains("persuasion"))
                { return returnAbilityModifier(charisma); }
            else return 0;
        }


        //sneak attack data
        private string SneakAttackRead()
        {
            if (sneakAttackCheckBox.Checked == false) { return ""; }
            else
            {
                int sneakAttackDice;
                if (characterLevel % 2 == 0) { sneakAttackDice = characterLevel / 2; }
                else { sneakAttackDice = (characterLevel + 1) / 2; }

                return $"You dealt {sneakAttackDamageCalculator(sneakAttackDice)} from your sneak attack!";
            }
        }

        private int sneakAttackDamageCalculator(int sneakAttackDice)
        {
            int n = 0;
            int sneakAttackDamage = 0;
            while (n < sneakAttackDice)
            {
                sneakAttackDamage += anyDice(1, 6);
                n++;
            }
            return sneakAttackDamage;
        }
    }
}
