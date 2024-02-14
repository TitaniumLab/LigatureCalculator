using System;
using System.IO;
using System.Windows.Forms;
using static LigatureCalculator.MainForm;
using Newtonsoft.Json;

namespace LigatureCalculator
{
    public partial class CreateLigForm : Form
    {
        //contains a list of all ligature files
        string[] allFiles;
        //contains the path to the folder with ligatures
        string ligFolderPath;
        //min and max values of each element
        private float[] minMaxTi = new float[2];
        private float[] minMaxAl = new float[2];
        private float[] minMaxMo = new float[2];
        private float[] minMaxZr = new float[2];
        private float[] minMaxNb = new float[2];
        private float[] minMaxW = new float[2];
        private float[] minMaxSn = new float[2];
        private float[] minMaxSi = new float[2];
        private float[] minMaxFe = new float[2];
        private float[] minMaxV = new float[2];
        private float[] minMaxC = new float[2];
        private float[] minMaxCr = new float[2];
        private float[] minMaxO = new float[2];
        private float[] minMaxN = new float[2];
        //determines which element is designated as the main one
        private CheckBox[] checkBoxes;

        SelectLigForm chooseLigForm;


        public CreateLigForm()
        {
            InitializeComponent();
        }

        private void createLigForm_Load(object sender, EventArgs e)
        {
            chooseLigForm = this.Owner as SelectLigForm;

            ligFolderPath = Application.StartupPath;
            ligFolderPath += "\\Maindata";
            allFiles = Directory.GetFiles(ligFolderPath);

            checkBoxes = new CheckBox[]
            {
                tiCheckBox,
                alCheckBox,
                moCheckBox,
                zrCheckBox,
                nbCheckBox,
                wCheckBox,
                snCheckBox,
                siCheckBox,
                feCheckBox,
                vCheckBox,
                cCheckBox,
                crCheckBox,
                oCheckBox,
                nCheckBox
            };
        }

        private void maxTiTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minTiTextBox);
            SetValuesForSaving(sender, ref minMaxTi[1]);
        }
        private void maxAlTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minAlTextBox);
            SetValuesForSaving(sender, ref minMaxAl[1]);
        }
        private void maxMoTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minMoTextBox);
            SetValuesForSaving(sender, ref minMaxMo[1]);
        }
        private void maxZrTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minZrTextBox);
            SetValuesForSaving(sender, ref minMaxZr[1]);
        }
        private void maxNbTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minNbTextBox);
            SetValuesForSaving(sender, ref minMaxNb[1]);
        }
        private void maxWTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minWTextBox);
            SetValuesForSaving(sender, ref minMaxW[1]);
        }
        private void maxSnTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minSnTextBox);
            SetValuesForSaving(sender, ref minMaxSn[1]);
        }
        private void maxSiTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minSiTextBox);
            SetValuesForSaving(sender, ref minMaxSi[1]);
        }
        private void maxFeTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minFeTextBox);
            SetValuesForSaving(sender, ref minMaxFe[1]);
        }
        private void maxVTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minVTextBox);
            SetValuesForSaving(sender, ref minMaxV[1]);
        }
        private void maxCTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minCTextBox);
            SetValuesForSaving(sender, ref minMaxC[1]);
        }
        private void maxCrTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minCrTextBox);
            SetValuesForSaving(sender, ref minMaxCr[1]);
        }
        private void maxOTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minOTextBox);
            SetValuesForSaving(sender, ref minMaxO[1]);
        }
        private void maxNTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMaxValueBound(sender, e, ref minNTextBox);
            SetValuesForSaving(sender, ref minMaxN[1]);
        }


        private void minTiTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxTiTextBox);
            SetValuesForSaving(sender, ref minMaxTi[0]);
        }
        private void minAlTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxAlTextBox);
            SetValuesForSaving(sender, ref minMaxAl[0]);
        }
        private void minMoTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxMoTextBox);
            SetValuesForSaving(sender, ref minMaxMo[0]);
        }
        private void minZrTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxZrTextBox);
            SetValuesForSaving(sender, ref minMaxZr[0]);
        }
        private void minNbTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxNbTextBox);
            SetValuesForSaving(sender, ref minMaxNb[0]);
        }
        private void minWTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxWTextBox);
            SetValuesForSaving(sender, ref minMaxW[0]);
        }
        private void minSnTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxSnTextBox);
            SetValuesForSaving(sender, ref minMaxSn[0]);
        }
        private void minSiTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxSiTextBox);
            SetValuesForSaving(sender, ref minMaxSi[0]);
        }
        private void minFeTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxFeTextBox);
            SetValuesForSaving(sender, ref minMaxFe[0]);
        }
        private void minVTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxVTextBox);
            SetValuesForSaving(sender, ref minMaxV[0]);
        }
        private void minCTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxCTextBox);
            SetValuesForSaving(sender, ref minMaxC[0]);
        }
        private void minCrTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxCrTextBox);
            SetValuesForSaving(sender, ref minMaxCr[0]);
        }
        private void minOTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxOTextBox);
            SetValuesForSaving(sender, ref minMaxO[0]);
        }
        private void minNTextBox_TextChanged(object sender, EventArgs e)
        {
            InputMinValueBound(sender, e, maxNTextBox);
            SetValuesForSaving(sender, ref minMaxN[0]);
        }


        private void tiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minTiTextBox, maxTiTextBox, ref minMaxTi);
        }
        private void alCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minAlTextBox, maxAlTextBox, ref minMaxAl);
        }
        private void moCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minMoTextBox, maxMoTextBox, ref minMaxMo);
        }
        private void zrCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minZrTextBox, maxZrTextBox, ref minMaxZr);
        }
        private void nbCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minNbTextBox, maxNbTextBox, ref minMaxNb);
        }
        private void wCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minWTextBox, maxWTextBox, ref minMaxW);
        }
        private void snCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minSnTextBox, maxSnTextBox, ref minMaxSn);
        }
        private void siCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minSiTextBox, maxSiTextBox, ref minMaxSi);
        }
        private void feCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minFeTextBox, maxFeTextBox, ref minMaxFe);
        }
        private void vCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minVTextBox, maxVTextBox, ref minMaxV);
        }
        private void cCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minCTextBox, maxCTextBox, ref minMaxC);
        }
        private void crCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minCrTextBox, maxCrTextBox, ref minMaxCr);
        }
        private void oCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minOTextBox, maxOTextBox, ref minMaxO);
        }
        private void nCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSwitch(sender, e, minNTextBox, maxNTextBox, ref minMaxN);
        }


        /// <summary>
        /// sets the values of element variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="minOrMaxValue"></param>
        private void SetValuesForSaving(object sender, ref float minOrMaxValue)
        {
            if ((sender as TextBox).Text.Length == 0)
                minOrMaxValue = 0;
            else if ((sender as TextBox).Text.Length > 0)
                minOrMaxValue = float.Parse((sender as TextBox).Text);
        }

        /// <summary>
        /// allows only 1 element to be main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="minTextBox"></param>
        /// <param name="maxTextBox"></param>
        /// <param name="minMaxValue"></param>
        private void CheckBoxSwitch(object sender, EventArgs e, TextBox minTextBox, TextBox maxTextBox, ref float[] minMaxValue)
        {
            CheckBox checkBox = (sender as CheckBox);
            if (checkBox.Checked)
            {
                foreach (CheckBox check in checkBoxes)
                    if (checkBox != check)
                        check.Checked = false;

                minTextBox.Enabled = false;
                maxTextBox.Enabled = false;
                minMaxValue = new float[] { 0, 100 };
            }
            else
            {
                minTextBox.Enabled = true;
                maxTextBox.Enabled = true;
                minTextBox.Text = "0";
                maxTextBox.Text = "0";
                minMaxValue = new float[] { float.Parse(minTextBox.Text), float.Parse(maxTextBox.Text) };
            }
        }

        /// <summary>
        /// saves new ligature
        /// </summary>
        private void SaveNewLigature()
        {
            string ligName = nameLigTextBox.Text;
            SaveLoadLigature saveLigature = new SaveLoadLigature(ligName, minMaxTi, minMaxAl, minMaxMo, minMaxZr, minMaxNb, minMaxW,
                minMaxSn, minMaxSi, minMaxFe, minMaxV, minMaxC, minMaxCr, minMaxO, minMaxN);
            ligFolderPath += $"\\{ligName}.json";
            string json = JsonConvert.SerializeObject(saveLigature);
            File.WriteAllText(ligFolderPath, json);
        }

        /// <summary>
        /// allows you to input only numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckNumbersOnly(object sender, KeyPressEventArgs e)
        {
            string textBoxText = (sender as TextBox).Text;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if (textBoxText.Length > 1 && (e.KeyChar == ',') && textBoxText.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// limiting the maximum value input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="minTextBox"></param>
        private void InputMaxValueBound(object sender, EventArgs e, ref TextBox minTextBox)
        {
            string textBoxText = (sender as TextBox).Text;
            string minTextBoxText = (minTextBox as TextBox).Text;
            if (textBoxText == ",")
            {
                (sender as TextBox).Text = "0,";
                (sender as TextBox).SelectionStart = 2;
            }
            else if (textBoxText.Length > 0 && float.Parse(textBoxText) > 100)
            {
                (sender as TextBox).Text = "100";
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            }
            else if (textBoxText.Length > 0 && minTextBoxText.Length > 0 && float.Parse(textBoxText) < float.Parse(minTextBoxText))
                minTextBox.Text = textBoxText;
        }

        /// <summary>
        /// limiting the minimum value input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="maxTextBox"></param>
        private void InputMinValueBound(object sender, EventArgs e, TextBox maxTextBox)
        {
            string textBoxText = (sender as TextBox).Text;
            if (textBoxText == ",")
            {
                (sender as TextBox).Text = "0,";
                (sender as TextBox).SelectionStart = 2;
            }
            else if (textBoxText.Length > 0 && maxTextBox.Text.Length == 0)
                (sender as TextBox).Text = "0";
            else if (textBoxText.Length > 0 && float.Parse(textBoxText) > float.Parse(maxTextBox.Text))
            {
                (sender as TextBox).Text = maxTextBox.Text;
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            }

        }


        private void acceptButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckAllTextBoxes())
                MessageBox.Show("Введите химический состав.");
            else if (nameLigTextBox.Text.Length == 0)
                MessageBox.Show("Введите название лигратуры.");
            else if (CheckRepeatedName(nameLigTextBox.Text))
                MessageBox.Show("Лигатура уже существует.");
            else
            {
                SaveNewLigature();
                chooseLigForm.UpdateDataGridViev();
                MessageBox.Show("Лигатура успешно создана.");
                this.Close();
            }
        }

        /// <summary>
        /// returns to the selection menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// does not allow creating empty ligatures
        /// </summary>
        /// <returns></returns>
        private bool CheckAllTextBoxes()
        {
            TextBox[] maxValues =
            {
                maxTiTextBox,
                maxAlTextBox,
                maxMoTextBox,
                maxZrTextBox,
                maxNbTextBox,
                maxWTextBox,
                maxSnTextBox,
                maxSiTextBox,
                maxFeTextBox,
                maxVTextBox,
                maxCTextBox,
                maxCrTextBox,
                maxOTextBox,
                maxNTextBox
            };

            foreach (TextBox t in maxValues)
            {
                if (t.Text.Length != 0 && float.Parse(t.Text) != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// prohibits the creation of existing ligatures
        /// </summary>
        /// <param name="ligName"></param>
        /// <returns></returns>
        private bool CheckRepeatedName(string ligName)
        {
            foreach (string name in allFiles)
            {
                if (ligFolderPath + "\\" + ligName + ".json" == name) return true;
            }
            return false;
        }
    }
}
