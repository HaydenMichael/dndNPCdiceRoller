namespace dndNPCdiceRoller
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRoll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NPCselectorComboBox = new System.Windows.Forms.ComboBox();
            this.rollSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.targetAC = new System.Windows.Forms.Label();
            this.spellSaveDCtarget = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.resultTarget = new System.Windows.Forms.Label();
            this.HPtarget = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.targetSpeed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.featsTarget = new System.Windows.Forms.Label();
            this.targetProfBonus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.blessedCheckbox = new System.Windows.Forms.CheckBox();
            this.baneCheckbox = new System.Windows.Forms.CheckBox();
            this.spellListComboBox = new System.Windows.Forms.ComboBox();
            this.comboBoxSpellSlotLevel = new System.Windows.Forms.ComboBox();
            this.labelSpellSlotUsed = new System.Windows.Forms.Label();
            this.sneakAttackCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonRoll
            // 
            this.buttonRoll.Location = new System.Drawing.Point(19, 111);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(132, 29);
            this.buttonRoll.TabIndex = 0;
            this.buttonRoll.Text = "Roll";
            this.buttonRoll.UseVisualStyleBackColor = true;
            this.buttonRoll.Click += new System.EventHandler(this.ButtonRoll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NPC:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Roll:";
            // 
            // NPCselectorComboBox
            // 
            this.NPCselectorComboBox.FormattingEnabled = true;
            this.NPCselectorComboBox.Items.AddRange(new object[] {
            "Acolyte",
            "Duelist"});
            this.NPCselectorComboBox.Location = new System.Drawing.Point(50, 29);
            this.NPCselectorComboBox.Name = "NPCselectorComboBox";
            this.NPCselectorComboBox.Size = new System.Drawing.Size(154, 21);
            this.NPCselectorComboBox.TabIndex = 3;
            this.NPCselectorComboBox.Text = "Acolyte";
            this.NPCselectorComboBox.SelectedIndexChanged += new System.EventHandler(this.NPCselectorComboBox_SelectedIndexChanged);
            // 
            // rollSelectorComboBox
            // 
            this.rollSelectorComboBox.FormattingEnabled = true;
            this.rollSelectorComboBox.Items.AddRange(new object[] {
            "Initiative",
            "Strength Save",
            "Dexterity Save",
            "Constitution Save",
            "Intelligence Save",
            "Wisdom Save",
            "Charisma Save",
            "Melee Attack",
            "Ranged Attack",
            "Spells",
            "Skill Checks"});
            this.rollSelectorComboBox.Location = new System.Drawing.Point(50, 61);
            this.rollSelectorComboBox.Name = "rollSelectorComboBox";
            this.rollSelectorComboBox.Size = new System.Drawing.Size(154, 21);
            this.rollSelectorComboBox.TabIndex = 4;
            this.rollSelectorComboBox.Text = "Initiative";
            this.rollSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.RollSelectorComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(936, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "AC:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(881, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Spell Save DC:";
            // 
            // targetAC
            // 
            this.targetAC.AutoSize = true;
            this.targetAC.Location = new System.Drawing.Point(966, 49);
            this.targetAC.Name = "targetAC";
            this.targetAC.Size = new System.Drawing.Size(0, 13);
            this.targetAC.TabIndex = 7;
            // 
            // spellSaveDCtarget
            // 
            this.spellSaveDCtarget.AutoSize = true;
            this.spellSaveDCtarget.Location = new System.Drawing.Point(966, 79);
            this.spellSaveDCtarget.Name = "spellSaveDCtarget";
            this.spellSaveDCtarget.Size = new System.Drawing.Size(0, 13);
            this.spellSaveDCtarget.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Result:";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // resultTarget
            // 
            this.resultTarget.AutoSize = true;
            this.resultTarget.BackColor = System.Drawing.SystemColors.Control;
            this.resultTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resultTarget.Location = new System.Drawing.Point(19, 191);
            this.resultTarget.MaximumSize = new System.Drawing.Size(400, 200);
            this.resultTarget.MinimumSize = new System.Drawing.Size(400, 200);
            this.resultTarget.Name = "resultTarget";
            this.resultTarget.Size = new System.Drawing.Size(400, 200);
            this.resultTarget.TabIndex = 10;
            // 
            // HPtarget
            // 
            this.HPtarget.AutoSize = true;
            this.HPtarget.Location = new System.Drawing.Point(966, 20);
            this.HPtarget.Name = "HPtarget";
            this.HPtarget.Size = new System.Drawing.Size(0, 13);
            this.HPtarget.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(936, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "HP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(920, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Speed:";
            // 
            // targetSpeed
            // 
            this.targetSpeed.AutoSize = true;
            this.targetSpeed.Location = new System.Drawing.Point(967, 111);
            this.targetSpeed.Name = "targetSpeed";
            this.targetSpeed.Size = new System.Drawing.Size(0, 13);
            this.targetSpeed.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(925, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Feats:";
            // 
            // featsTarget
            // 
            this.featsTarget.AutoSize = true;
            this.featsTarget.Location = new System.Drawing.Point(967, 170);
            this.featsTarget.Name = "featsTarget";
            this.featsTarget.Size = new System.Drawing.Size(0, 13);
            this.featsTarget.TabIndex = 16;
            // 
            // targetProfBonus
            // 
            this.targetProfBonus.AutoSize = true;
            this.targetProfBonus.Location = new System.Drawing.Point(966, 141);
            this.targetProfBonus.Name = "targetProfBonus";
            this.targetProfBonus.Size = new System.Drawing.Size(0, 13);
            this.targetProfBonus.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(865, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Proficiency Bonus:";
            // 
            // blessedCheckbox
            // 
            this.blessedCheckbox.AutoSize = true;
            this.blessedCheckbox.Location = new System.Drawing.Point(928, 339);
            this.blessedCheckbox.Name = "blessedCheckbox";
            this.blessedCheckbox.Size = new System.Drawing.Size(63, 17);
            this.blessedCheckbox.TabIndex = 19;
            this.blessedCheckbox.Text = "Blessed";
            this.blessedCheckbox.UseVisualStyleBackColor = true;
            this.blessedCheckbox.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // baneCheckbox
            // 
            this.baneCheckbox.AutoSize = true;
            this.baneCheckbox.Location = new System.Drawing.Point(928, 362);
            this.baneCheckbox.Name = "baneCheckbox";
            this.baneCheckbox.Size = new System.Drawing.Size(57, 17);
            this.baneCheckbox.TabIndex = 20;
            this.baneCheckbox.Text = "Baned";
            this.baneCheckbox.UseVisualStyleBackColor = true;
            this.baneCheckbox.CheckedChanged += new System.EventHandler(this.BaneCheckbox_CheckedChanged);
            // 
            // spellListComboBox
            // 
            this.spellListComboBox.FormattingEnabled = true;
            this.spellListComboBox.Items.AddRange(new object[] {
            "None"});
            this.spellListComboBox.Location = new System.Drawing.Point(210, 61);
            this.spellListComboBox.Name = "spellListComboBox";
            this.spellListComboBox.Size = new System.Drawing.Size(152, 21);
            this.spellListComboBox.TabIndex = 21;
            this.spellListComboBox.Text = "None";
            this.spellListComboBox.SelectedIndexChanged += new System.EventHandler(this.SpellListComboBox_SelectedIndexChanged);
            // 
            // comboBoxSpellSlotLevel
            // 
            this.comboBoxSpellSlotLevel.FormattingEnabled = true;
            this.comboBoxSpellSlotLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBoxSpellSlotLevel.Location = new System.Drawing.Point(368, 61);
            this.comboBoxSpellSlotLevel.Name = "comboBoxSpellSlotLevel";
            this.comboBoxSpellSlotLevel.Size = new System.Drawing.Size(57, 21);
            this.comboBoxSpellSlotLevel.TabIndex = 22;
            // 
            // labelSpellSlotUsed
            // 
            this.labelSpellSlotUsed.AutoSize = true;
            this.labelSpellSlotUsed.Location = new System.Drawing.Point(368, 32);
            this.labelSpellSlotUsed.Name = "labelSpellSlotUsed";
            this.labelSpellSlotUsed.Size = new System.Drawing.Size(51, 26);
            this.labelSpellSlotUsed.TabIndex = 23;
            this.labelSpellSlotUsed.Text = "Spell Slot\r\nUsed";
            // 
            // sneakAttackCheckBox
            // 
            this.sneakAttackCheckBox.AutoSize = true;
            this.sneakAttackCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sneakAttackCheckBox.Location = new System.Drawing.Point(50, 88);
            this.sneakAttackCheckBox.Name = "sneakAttackCheckBox";
            this.sneakAttackCheckBox.Size = new System.Drawing.Size(91, 17);
            this.sneakAttackCheckBox.TabIndex = 24;
            this.sneakAttackCheckBox.Text = "Sneak Attack";
            this.sneakAttackCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 450);
            this.Controls.Add(this.sneakAttackCheckBox);
            this.Controls.Add(this.labelSpellSlotUsed);
            this.Controls.Add(this.comboBoxSpellSlotLevel);
            this.Controls.Add(this.spellListComboBox);
            this.Controls.Add(this.baneCheckbox);
            this.Controls.Add(this.blessedCheckbox);
            this.Controls.Add(this.targetProfBonus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.featsTarget);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.targetSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.HPtarget);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.resultTarget);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.spellSaveDCtarget);
            this.Controls.Add(this.targetAC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rollSelectorComboBox);
            this.Controls.Add(this.NPCselectorComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRoll);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRoll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox NPCselectorComboBox;
        private System.Windows.Forms.ComboBox rollSelectorComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label targetAC;
        private System.Windows.Forms.Label spellSaveDCtarget;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label resultTarget;
        private System.Windows.Forms.Label HPtarget;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label targetSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label featsTarget;
        private System.Windows.Forms.Label targetProfBonus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox blessedCheckbox;
        private System.Windows.Forms.CheckBox baneCheckbox;
        private System.Windows.Forms.ComboBox spellListComboBox;
        private System.Windows.Forms.ComboBox comboBoxSpellSlotLevel;
        private System.Windows.Forms.Label labelSpellSlotUsed;
        private System.Windows.Forms.CheckBox sneakAttackCheckBox;
    }
}

