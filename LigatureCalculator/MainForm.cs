using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LigatureCalculator
{
    public partial class MainForm : Form
    {
        //fundamental constants
        private readonly float[] elementsDensity = { 4.5f, 2.68f, 10.22f, 6.45f, 8.57f, 19.3f, 5.85f, 2.33f, 7.87f, 5.96f, 2.26f, 7.18f, 1.43f, 1.25f }; //g/sm^3
        private readonly float[] atomicWeight = { 47.88f, 26.98f, 95.9f, 91.22f, 92.91f, 183.85f, 118.71f, 28.085f, 55.85f, 50.94f, 0, 51.99f, 0, 0 };
        private readonly float[] boCoef = { 2.79f, 2.43f, 3.05f, 3.086f, 3.099f, 3.125f, 2.283f, 2.561f, 2.42f, 2.78f, 0, 2.65f, 0, 0 };
        private readonly float[] mdCoef = { 2.45f, 2.15f, 1.95f, 2.934f, 2.424f, 2.072f, 2.1f, 2.2f, 0.95f, 1.95f, 0, 1.45f, 0, 0 };
        // values of all already calculated elements
        float[] sumOfCalcElements;
        //inputed alloy
        private ChemComp mainAlloy = new ChemComp();
        //stores data about ligatures and their elements range
        public List<SaveLoadLigature> mainLigList = new List<SaveLoadLigature>();
        //Easter Egg
        private int lab608call = 0;


        //class in which ligatures with valid ranges are stored
        [Serializable]
        public class SaveLoadLigature
        {
            public string ligName;
            public List<float[]> ligList;
            public SaveLoadLigature(string ligName, float[] minMaxTi, float[] minMaxAl, float[] minMaxMo, float[] minMaxZr, float[] minMaxNb, float[] minMaxW
            , float[] minMaxSn, float[] minMaxSi, float[] minMaxFe, float[] minMaxV, float[] minMaxC, float[] minMaxCr, float[] minMaxO, float[] minMaxN)
            {
                this.ligName = ligName;
                ligList = new List<float[]>()
                {
                     minMaxTi,  minMaxAl,  minMaxMo,  minMaxZr,  minMaxNb,  minMaxW,  minMaxSn,
                     minMaxSi,  minMaxFe,  minMaxV,  minMaxC,  minMaxCr,  minMaxO,  minMaxN
                };
            }

            /// <summary>
            /// returns an array to fill the data grid
            /// </summary>
            /// <returns></returns>
            public string[] GetNameAndValuesArray()
            {
                List<string> valuesArr = new List<string>();
                valuesArr.Add(ligName);
                foreach (float[] i in ligList)
                {
                    if (i[0] == 0 && i[1] == 0)
                        valuesArr.Add(null);
                    else if (i[0] == i[1])
                        valuesArr.Add($"{i[0]}");
                    else if (i[0] == 0 && i[1] == 100)
                        valuesArr.Add("Ост.");
                    else
                        valuesArr.Add($"{i[0]}-{i[1]}");
                }

                valuesArr.ToArray();
                return valuesArr.ToArray();
            }
        }

        // class used in calculation
        public class ChemComp
        {
            private const float maxValue = 100;//maximum sum for all elements
            public float remainChem = maxValue;//for correct calculation on data input
            public float[] allElements;//array of all elements
            public float outMass = 0;//output mass of calculated ligature
            public float minMaxMass = 1.0f;//maximum permissible weight when calculating
            public bool isCalculated = false; //is alredy calculated

            //inputed alloy
            public ChemComp()
            {
                allElements = new float[] { maxValue, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }

            //ligatures
            public ChemComp(float[] elementsArr)
            {
                this.allElements = elementsArr;
            }

            /// <summary>
            /// set titanium value on input
            /// </summary>
            /// <param name="dontCount"></param>
            public void CalcTi(float dontCount)
            {
                remainChem = maxValue;
                allElements[0] = maxValue;
                for (int i = 1; i < allElements.Length; i++)
                {
                    remainChem -= allElements[i];
                    allElements[0] -= allElements[i];
                }
                remainChem += dontCount;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            ToolTip helpToolTip = new ToolTip();
            //help tip(Strength)
            helpToolTip.SetToolTip(helpStrLinkLabel, "O и N берутся из требуемого состава, а не расчетного!");
            //help tip (Tpp)
            helpToolTip.SetToolTip(helpTppLink, "Без учета C, O и N.");
        }


        //calc values of inputed alloy
        private void AlTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[1]);
        }
        private void MoTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[2]);
        }
        private void ZrTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[3]);
        }
        private void NbTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[4]);
        }
        private void WTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[5]);
        }
        private void SnTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[6]);
        }
        private void SiTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[7]);
        }
        private void FeTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[8]);
        }
        private void VTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[9]);
        }
        private void CTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[10]);
        }
        private void CrTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[11]);
        }
        private void OTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[12]);
        }
        private void NTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcInputValues(sender, e, ref mainAlloy.allElements[13]);
        }


        /// <summary>
        /// calculates the chemical composition and weight of ligatures
        /// </summary>
        private void EliminationMethod()
        {
            int ligaturesCount; // total number of ligatures
            int eleCount = mainAlloy.allElements.Length; // total number of elements
            int iterationCount = 0; // iteration number
            int ligToEliminateCount = 1; // counts how many ligatures will be counted in this iteration
            int otherEleCount = 0;// counts how many ligatures remain for the next iteration
            float[] remainingEle = new float[eleCount]; // contains data about uncalculated elements
            sumOfCalcElements = new float[eleCount]; // values of all already calculated elements
            float[] mass; // output mass of each ligature
            string[] elementsOutput; // for conversion and output of chemical composition


            List<ChemComp> ligaturesList = new List<ChemComp>();

            //reads all the data from the data grid and adds it to the list
            foreach (DataGridViewRow dataGridViewRow in mainLigatureDataGridView.Rows)
            {
                List<float> elementsList = new List<float>();
                for (int i = 1; i < dataGridViewRow.Cells.Count - 1; i++)
                {
                    if (dataGridViewRow.Cells[i].Value == null)
                        elementsList.Add(0);
                    else if (float.TryParse(dataGridViewRow.Cells[i].Value.ToString(), out float result))
                        elementsList.Add(result);
                    else //checking that all fields are numbers
                    {
                        MessageBox.Show("Одно или несколько полей содержат не числа");
                        return;
                    }
                }
                ligaturesList.Add(new ChemComp(elementsList.ToArray()));
            }

            ligaturesCount = ligaturesList.Count;

            //checking if the list of ligatures is empty
            if (ligaturesCount == 0)
            {
                MessageBox.Show("Список лигатур пуст");
                return;
            }

            // main calc loop
            while (ligToEliminateCount != 0)
            {
                //reset values
                ligToEliminateCount = 0;
                otherEleCount = 0;
                int[] repeatedEle = new int[eleCount]; // how many times each element is repeated in uncalculated ligatures

                //Sum of all elements which will be calculated in this iteration
                for (int i = 0; i < eleCount; i++)
                {
                    remainingEle[i] = mainAlloy.allElements[i];
                    remainingEle[i] -= sumOfCalcElements[i];
                }

                //finds all elements that are controlled by only one ligature
                for (int i = 0; i < ligaturesCount; i++)
                {
                    for (int j = 0; j < eleCount; j++)
                    {
                        if (remainingEle[j] > 0 && ligaturesList[i].allElements[j] != 0 && !ligaturesList[i].isCalculated)
                        {
                            float maxMass = remainingEle[j] / ligaturesList[i].allElements[j];
                            ligaturesList[i].minMaxMass = Math.Min(ligaturesList[i].minMaxMass, maxMass);

                            repeatedEle[j]++;
                        }
                    }
                }

                //sets the number of elements that will and will not be calculated in this iteration
                foreach (int item in repeatedEle)
                {
                    if (item == 1)
                        ligToEliminateCount++;
                    if (item > 1)
                        otherEleCount += item;
                }

                //checking necessary ligatures by elements
                if (iterationCount == 0)
                {
                    for (int i = 0; i < eleCount; i++)
                    {
                        if (remainingEle[i] != 0 && repeatedEle[i] == 0)
                        {
                            MessageBox.Show("В лигатурах отсутствует необходимый набор химических элементов");
                            return;
                        }
                    }
                }


                //mark all ligatures which affect only 1 element
                for (int i = 0; i < ligaturesCount; i++)
                {
                    for (int j = 0; j < eleCount; j++)
                    {
                        if (repeatedEle[j] == 1 && ligaturesList[i].allElements[j] != 0)
                        {
                            ligaturesList[i].isCalculated = true;
                            ligaturesList[i].outMass = ligaturesList[i].minMaxMass;
                            j = eleCount;
                        }
                    }
                }

                //reset the array
                Array.Clear(sumOfCalcElements, 0, eleCount);

                //calculates ouput chemical composition
                for (int i = 0; i < ligaturesCount; i++)
                {
                    for (int j = 0; j < eleCount; j++)
                    {
                        if (ligaturesList[i].isCalculated)
                            sumOfCalcElements[j] += ligaturesList[i].allElements[j] * ligaturesList[i].outMass;
                    }
                }

                //number of next iteration
                iterationCount++;
            }

            // if uncounted ligatures remain, return a warning
            if (otherEleCount > 0)
            {
                string textToShow = "Невозможно рассчитать следующие лигатуры:";
                for (int i = 0; i < ligaturesList.Count; i++)
                {
                    if (!ligaturesList[i].isCalculated)
                    {
                        string nextTextRow = mainLigatureDataGridView.Rows[i].Cells[0].Value.ToString();
                        textToShow += $"\n{nextTextRow}";
                    }
                }
                MessageBox.Show($"{textToShow}");
            }

            mass = new float[ligaturesCount];
            // mass data output
            for (int i = 0; i < ligaturesCount; i++)
            {
                mass[i] = (float)Math.Round(ligaturesList[i].outMass * 1000, 3);
                mainLigatureDataGridView.Rows[i].Cells[mainLigatureDataGridView.Columns.Count - 1].Value = mass[i];
            }

            elementsOutput = new string[eleCount];
            for (int i = 0; i < eleCount; i++)
            {
                elementsOutput[i] = $"{Math.Round(sumOfCalcElements[i], 3)}";
            }

            outDataGridView.Rows.Clear();
            outDataGridView.Rows.Add(elementsOutput);
        }

        /// <summary>
        /// obtain the polymorphic transformation temperature
        /// </summary>
        /// <param name="elementsMass"></param>
        private void GetTpp(float[] elementsMass)
        {
            float[] bo = new float[elementsMass.Length];
            float[] md = new float[elementsMass.Length];
            float[] atomicFraction = new float[elementsMass.Length];
            float atomicFractionSum = 0;
            float[] atomicPersent = new float[elementsMass.Length];
            float tpp;

            float boSum = 0;
            float mdSum = 0;
            for (int i = 0; i < elementsMass.Length; i++)
            {
                if (atomicWeight[i] > 0)
                {
                    atomicFraction[i] = elementsMass[i] / atomicWeight[i];
                    atomicFractionSum += atomicFraction[i];
                }
                else
                    atomicFraction[i] = 0;
            }

            for (int i = 0; i < atomicFraction.Length; i++)
            {
                atomicPersent[i] = atomicFraction[i] / atomicFractionSum * 100;
                bo[i] = boCoef[i] * atomicPersent[i] / 100;
                md[i] = mdCoef[i] * atomicPersent[i] / 100;
                boSum += bo[i];
                mdSum += md[i];
            }
            tpp = ((0.326f * mdSum + 2.217f - boSum) * 10000) / 1.95f - 272.16f;
            tpp = (float)Math.Round(tpp, 2);
            tppText.Text = "Тпп: " + tpp.ToString() + " °C";
        }

        /// <summary>
        /// calculates strength and equivalents
        /// </summary>
        /// <param name="elementsMass"></param>
        private void CalcAlMoEqStrength(float[] elementsMass)
        {
            float alEqStrength = (float)Math.Round(elementsMass[1] + (0.33f * elementsMass[3]) + (0.5f * elementsMass[6]) + (20 * mainAlloy.allElements[12]) +
                (12 * elementsMass[10]) + (33 * mainAlloy.allElements[13]) + (3.34 * elementsMass[7]), 3);
            float moEqStrength = (float)Math.Round(elementsMass[2] + (elementsMass[9] / 1.7f) + (elementsMass[11] / 0.8) +
                (elementsMass[8] / 0.7f) + (elementsMass[4] / 3.3f) + (elementsMass[5] / 2.5f), 3);
            alMoEqStrengthText.Text = $"Прочностные эквиваленты: [Al]eq = {alEqStrength}, [Mo]eq = {moEqStrength}.";
            float strengthLevel = (235 + alEqStrength * 60 + moEqStrength * 50);
            strengthLevelText.Text = "Уровень прочности: " + strengthLevel.ToString() + " МПа";
        }

        /// <summary>
        /// calculates structural equivalents
        /// </summary>
        /// <param name="elementsMass"></param>
        private void CalcAlMoEqStructural(float[] elementsMass)
        {
            float alEqStruct = (float)Math.Round(elementsMass[1] + (0.17f * elementsMass[3]) + (0.33f * elementsMass[6]) + (10 * elementsMass[12]) +
                (2 * elementsMass[10]) + (3 * elementsMass[13]) + (4 * elementsMass[7]), 3);
            float moEqStruct = (float)Math.Round(elementsMass[2] + (0.28f * elementsMass[4]) + (0.4f * elementsMass[5]) + (0.67f * elementsMass[9]) +
                (1.25f * elementsMass[8]) + (elementsMass[11] / 0.6), 3);
            alMoEqPhaseText.Text = $"Фазовые эквиваленты: [Al]eq = {alEqStruct}, [Mo]eq = {moEqStruct}.";
        }

        /// <summary>
        /// design alloy density
        /// </summary>
        /// <param name="elementsMass"></param>
        private void CalcDensity(float[] elementsMass)
        {
            float outDensity = 0;
            for (int i = 0; i < elementsMass.Length; i++)
            {
                if (i > 0)
                    outDensity += (elementsMass[i] / 100) * elementsDensity[i] * 0.92f;
                else
                    outDensity += (elementsMass[i] / 100) * elementsDensity[i];
            }
            outDensity = (float)Math.Round(outDensity, 3);

            densityText.Text = "Расчетная плотность: " + outDensity.ToString() + "г/см\u00B3";
        }

        /// <summary>
        /// limits input values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="elemnt"></param>
        private void CalcInputValues(object sender, EventArgs e, ref float elemnt)
        {
            string textBoxText = (sender as TextBox).Text;

            if (textBoxText == ",")
            {
                (sender as TextBox).Text = "0,";
                (sender as TextBox).SelectionStart = 2;
            }
            else if (textBoxText.Length > 0 && float.Parse(textBoxText) > mainAlloy.remainChem)
            {
                (sender as TextBox).Text = $"{mainAlloy.remainChem}";
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
                elemnt = mainAlloy.remainChem;
                mainAlloy.CalcTi(elemnt);
                TiTextValue.Text = $"{mainAlloy.allElements[0]}";
            }
            else if (textBoxText.Length == 0 || float.Parse(textBoxText) == 0)
            {
                elemnt = 0;
                mainAlloy.CalcTi(elemnt);
                TiTextValue.Text = $"{mainAlloy.allElements[0]}";
            }
            else
            {
                elemnt = float.Parse(textBoxText);
                mainAlloy.CalcTi(elemnt);
                TiTextValue.Text = $"{mainAlloy.allElements[0]}";
            }
        }

        /// <summary>
        /// controls data input into the data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainLigatureDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.KeyPress += new KeyPressEventHandler(CheckNumbersOnly);
            tb.TextChanged += new EventHandler(InputZero);
            tb.LostFocus += new EventHandler(InputBounds);
        }

        /// <summary>
        /// allows you to enter only numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckNumbersOnly(object sender, KeyPressEventArgs e)
        {
            string textBoxText = (sender as TextBox).Text;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && textBoxText.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// allows you to start input with a char ','
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputZero(object sender, EventArgs e)
        {
            string textBoxText = (sender as TextBox).Text;
            if (textBoxText == ",")
            {
                (sender as TextBox).Text = "0,";
                (sender as TextBox).SelectionStart = 2;
            }
        }

        /// <summary>
        /// define input boundaries for dimensions in a data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputBounds(object sender, EventArgs e)
        {
            int LigIndex = mainLigatureDataGridView.CurrentCell.RowIndex;
            int elementIndex = mainLigatureDataGridView.CurrentCell.ColumnIndex - 1;

            string ligName = mainLigatureDataGridView.Rows[LigIndex].Cells[0].Value.ToString();
            string value = (sender as TextBox).Text;

            float minValue = 0;
            float maxValue = 0;

            foreach (SaveLoadLigature load in mainLigList)
            {
                if (load.ligName == ligName)
                {
                    minValue = load.ligList[elementIndex][0];
                    maxValue = load.ligList[elementIndex][1];
                }
            }

            if (float.TryParse(value, out float result))
            {
                float floatValue = float.Parse(value);
                if (floatValue < minValue)
                    mainLigatureDataGridView.Rows[LigIndex].Cells[elementIndex + 1].Value = minValue.ToString();
                else if (floatValue > maxValue)
                    mainLigatureDataGridView.Rows[LigIndex].Cells[elementIndex + 1].Value = maxValue.ToString();

                mainLigatureDataGridView.Rows[LigIndex].Cells[elementIndex + 1].Style.BackColor = Color.Green;
            }
        }

        /// <summary>
        /// start calcultion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calcButton_MouseClick(object sender, MouseEventArgs e)
        {
            EliminationMethod();
            CalcDensity(sumOfCalcElements);
            CalcAlMoEqStructural(sumOfCalcElements);
            CalcAlMoEqStrength(sumOfCalcElements);
            GetTpp(sumOfCalcElements);
        }

        /// <summary>
        /// open ligatures menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ligatureButton_Click(object sender, EventArgs e)
        {
            SelectLigForm chooseLigForm = new SelectLigForm();
            chooseLigForm.Owner = this;
            chooseLigForm.ShowDialog();
        }

        /// <summary>
        /// transferring ligatures from the ligatures menu
        /// </summary>
        /// <param name="addedToList"></param>
        /// <param name="renovedList"></param>
        /// <param name="removedRowsList"></param>
        public void GetSelectedLigatures(List<SaveLoadLigature> addedToList, List<SaveLoadLigature> renovedList, List<DataGridViewRow> removedRowsList)
        {
            mainLigList.AddRange(addedToList);
            foreach (SaveLoadLigature lig in addedToList)
            {
                mainLigatureDataGridView.Rows.Add(lig.GetNameAndValuesArray());
                int gridRowsIndex = mainLigatureDataGridView.Rows.Count - 1;

                for (int j = 0; j < mainLigatureDataGridView.Columns.Count; j++)
                {
                    string cellString = (string)mainLigatureDataGridView.Rows[gridRowsIndex].Cells[j].Value;
                    if (j == 0 || cellString == null || float.TryParse(cellString, out float number))
                    {
                        mainLigatureDataGridView.Rows[gridRowsIndex].Cells[j].ReadOnly = true;
                    }
                    else
                    {
                        mainLigatureDataGridView.Rows[gridRowsIndex].Cells[j].Style.BackColor = Color.Red;
                    }
                }
            }

            foreach (SaveLoadLigature removedString in renovedList)
                mainLigList.Remove(removedString);
            foreach (DataGridViewRow dataGridViewRow in removedRowsList)
                mainLigatureDataGridView.Rows.Remove(dataGridViewRow);
        }

        private void aboutProgrammButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The program was created using Microsoft Visual Studio C#.\nChuchman Oleg Victorovich © 2024");
        }

        private void helpTppLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lab608call++;
            if (lab608call == 8)
            {
                Lab608Form lab608Form = new Lab608Form();
                lab608Form.ShowDialog();
            }
        }
    }
}
