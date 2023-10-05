using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace dndNPCdiceRoller
{
    public partial class Form1 : Form
    {        
        readonly NPClist npc = new NPClist();
        readonly AttackRolls atkr = new AttackRolls();
        readonly SavingThrows st = new SavingThrows();
        readonly SpellList sl = new SpellList();
        readonly SpellRolls sr = new SpellRolls();
        readonly SkillRolls skill = new SkillRolls();

        RangedWeaponsList.RangedWeapon SelectedRangedWeapon;
        NPClist.NPC SelectedNPC;
        MeleeWeaponsList.Weapon SelectedMeleeWeapon;
        SpellList.Spell SelectedSpell;



        readonly string[] skillList = {"Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation", "Investigation", "Medicine", "Nature", "Perception",
        "Performance", "Persuasion", "Religion", "Sleight of Hand", "Stealth", "Survival"};

        public string SendNPC() { return NPCselectorComboBox.Text; }
        public int SendCastLevel() { return comboBoxSpellSlotLevel.SelectedIndex + 1; }

        //proficiency Bonus Progression

        readonly int[] proficiencyBonusByLevel = { 0, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6 };

        private void NPCselectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            FindCharacter(NPCselectorComboBox.Text);
            SpellListActivator();
            spellListComboBox.Text = "";
            spellSaveDCtarget.Text = (7 + sr.AbilityModifier(sr.SpellAttackModifier(SelectedNPC)) + proficiencyBonusByLevel[SelectedNPC.Level]).ToString();
            NPCGrabAllStats(SelectedNPC);
            //featsTarget.Text = feats[0].ToString();
            ShowSpellSlotLevels(SelectedSpell);
            

        }

        public Form1()
        {
            
            SpellListActivator();
            InitializeComponent();
            FindCharacter("Acolyte");
            rollSelectorComboBox.Text = "Initiative";           
            FindMeleeWeapon(SelectedNPC);
            ShowHideSneakAttackCheckBox();
            NPCGrabAllStats(SelectedNPC);
            ShowSpellSlotLevels(SelectedSpell);
        }


        // this will be one of the most important functions as it will make rolls happen, so it will have a lot of functions that work off of it
        private void ButtonRoll_Click(object sender, EventArgs e)
        {
            FindCharacter(NPCselectorComboBox.Text);
            FindRoll();
        }

        private void SpellListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectSpell(spellListComboBox.Text);
            ShowSpellSlotLevels(SelectedSpell);
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

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        //                                                              ---SECTION 1: NPC's---
        //a list of all characters described as functions
        public void NPCGrabAllStats(NPClist.NPC x)
        {
            HPtarget.Text = x.HP.ToString();
            targetAC.Text = x.AC.ToString();

            targetSpeed.Text = x.Speed.ToString();
            //featsTarget.Text = x.Feats.ToString();
        }

        private void FindCharacter(string x)
        {
            string y = x.ToLower();
            if (y == "acolyte") { SelectedNPC = npc.Acolyte; }
            if (y == "duelist") { SelectedNPC = npc.Duelist; }

            FindMeleeWeapon(SelectedNPC);
            FindRangedWeapon(SelectedNPC);
            ReadFeats();
        }
        private void FindMeleeWeapon(NPClist.NPC x)
        {
            SelectedMeleeWeapon = x.WeaponMelee;
        }

        private void FindRangedWeapon(NPClist.NPC x)
        {
            SelectedRangedWeapon = x.WeaponRanged;
        }
  
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void BaneCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void RollSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpellListActivator();
            SelectSpell(spellListComboBox.Text);
            ShowHideSneakAttackCheckBox();
            ShowSpellSlotLevels(SelectedSpell);
        }

        //all my roll functions should be organized here:
        private void FindRoll()
        {
            if (rollSelectorComboBox.Text == "Initiative") { resultTarget.Text = skill.Initiative(SelectedNPC); }
            else if (rollSelectorComboBox.Text == "Strength Save") { resultTarget.Text = st.SaveRead(SelectedNPC, "strength", SelectedNPC.Strength); }
            else if (rollSelectorComboBox.Text == "Dexterity Save") { resultTarget.Text = st.SaveRead(SelectedNPC, "dexterity", SelectedNPC.Dexterity); }
            else if (rollSelectorComboBox.Text == "Constitution Save") { resultTarget.Text = st.SaveRead(SelectedNPC, "constitution", SelectedNPC.Constitution); }
            else if (rollSelectorComboBox.Text == "Intelligence Save") { resultTarget.Text = st.SaveRead(SelectedNPC, "intelligence", SelectedNPC.Intelligence); }
            else if (rollSelectorComboBox.Text == "Wisdom Save") { resultTarget.Text = st.SaveRead(SelectedNPC, "wisdom", SelectedNPC.Wisdom); }
            else if (rollSelectorComboBox.Text == "Charisma Save") { resultTarget.Text = st.SaveRead(SelectedNPC, "charisma", SelectedNPC.Charisma); }
            else if (rollSelectorComboBox.Text == "Melee Attack") { resultTarget.Text = atkr.MeleeReader(SelectedNPC, SelectedMeleeWeapon) + "" + atkr.SneakAttack(SelectedNPC, sneakAttackCheckBox.Checked); }
            else if (rollSelectorComboBox.Text == "Ranged Attack") { resultTarget.Text = atkr.RangedReader(SelectedNPC, SelectedRangedWeapon) + atkr.SneakAttack(SelectedNPC, sneakAttackCheckBox.Checked); }
            else if (rollSelectorComboBox.Text == "Spells") { SelectSpell(spellListComboBox.Text); resultTarget.Text = sr.SpellReader(SelectedSpell, SelectedNPC, comboBoxSpellSlotLevel.SelectedIndex); }
            else if (rollSelectorComboBox.Text == "Skill Checks") { resultTarget.Text = skill.SkillRead(spellListComboBox.Text, SelectedNPC); }
        }

        public void ReadFeats()
        {
            string x = string.Empty;
            foreach (string item in SelectedNPC.Feats)
            {
                x += item + ", ";
            }
            featsTarget.Text = x;
        }

        //dealing with spell lists :o

        private void GetCharacterSpells()
        {
           spellListComboBox.Items.Clear();
           foreach (string element in SelectedNPC.SpellList) { spellListComboBox.Items.Add(element); }
        }

        private void SelectSpell(string x)
        {
            if (x.ToLower() == "burning hands") { SelectedSpell = sl.Burning_Hands; }
            else if (x.ToLower() == "ray of sickness") { SelectedSpell = sl.Ray_of_Sickness; }
            else if (x.ToLower() == "fire bolt") { SelectedSpell = sl.Firebolt; }
            else { SelectedSpell = sl.None; }
        }

        private void SpellListActivator()
        {
            if (rollSelectorComboBox != null)
            {
                if (rollSelectorComboBox.Text == "Spells") { spellListComboBox.Show(); GetCharacterSpells(); }
                else if (rollSelectorComboBox.Text == "Skill Checks") { spellListComboBox.Show(); GetSkillsList(); }
                else { spellListComboBox.Hide(); }
            }
            //else if (string.IsNullOrEmpty(spellListComboBox.Text)){ spellListComboBox.Hide(); }
        }

        public void ShowSpellSlotLevels(SpellList.Spell y)
        {
            if (y != null)
            {
                if (y.SpellSlotLevel != 0 && spellListComboBox.Visible == true)
                {
                    comboBoxSpellSlotLevel.SelectedIndex = 0;
                    comboBoxSpellSlotLevel.Show();
                    labelSpellSlotUsed.Show();
                }
                else if (y.SpellSlotLevel == 0 || spellListComboBox.Visible == false) { comboBoxSpellSlotLevel.Hide(); }
            }
            else { comboBoxSpellSlotLevel.Hide(); labelSpellSlotUsed.Hide(); }
        }

        private void GetSkillsList()
        {
            spellListComboBox.Items.Clear();
            foreach (string element in skillList) { spellListComboBox.Items.Add(element); }
        }

    }

}
