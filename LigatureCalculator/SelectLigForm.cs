using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static LigatureCalculator.MainForm;

namespace LigatureCalculator
{
    public partial class SelectLigForm : Form
    {
        //contains the path to the folder with ligatures
        private string filesPath;

        private MainForm mainForm;


        public SelectLigForm()
        {
            InitializeComponent();
        }


        public void ChooseLigForm_Load(object sender, EventArgs e)
        {
            mainForm = this.Owner as MainForm;
            filesPath = Application.StartupPath + "\\Maindata";
            if (!Directory.Exists(filesPath))
                Directory.CreateDirectory(filesPath);
            UpdateDataGridViev();

        }

        /// <summary>
        /// updates the grid when data changes
        /// </summary>
        public void UpdateDataGridViev()
        {
            selectGridView.Rows.Clear();
            string[] allFiles = Directory.GetFiles(filesPath);

            foreach (string file in allFiles)
            {
                string json = File.ReadAllText(file);
                SaveLoadLigature loadLigature = JsonConvert.DeserializeObject<SaveLoadLigature>(json);
                selectGridView.Rows.Add(loadLigature.GetNameAndValuesArray());
            }

            foreach (DataGridViewRow row in mainForm.mainLigatureDataGridView.Rows)
            {
                foreach (DataGridViewRow thisRow in selectGridView.Rows)
                {
                    if (row.Cells[0].Value.ToString() == thisRow.Cells[0].Value.ToString())
                        (thisRow.Cells[thisRow.Cells.Count - 1] as DataGridViewCheckBoxCell).Value = true;
                }
            }
        }

        /// <summary>
        /// opens the ligature creation window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createLig_MouseClick(object sender, MouseEventArgs e)
        {
            CreateLigForm createLigForm = new CreateLigForm();
            createLigForm.Owner = this;
            createLigForm.ShowDialog();
        }

        /// <summary>
        /// remove ligature from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteLigature(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Уверены, что ходите удалить эти элементы из базы данных", "Удалить", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                for (int i = 0; i < selectGridView.Rows.Count; i++)
                    if (Convert.ToBoolean(selectGridView.Rows[i].Cells[selectGridView.Columns.Count - 1].Value))
                    {
                        string deletePath = filesPath + "\\" + selectGridView.Rows[i].Cells[0].Value.ToString() + ".json";
                        File.Delete(deletePath);
                    }
                UpdateDataGridViev();
            }
        }


        /// <summary>
        /// transferring data to main class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectButton_Click(object sender, EventArgs e)
        {
            List<SaveLoadLigature> addedToLigList = new List<SaveLoadLigature>();
            List<SaveLoadLigature> removedLig = new List<SaveLoadLigature>();
            List<DataGridViewRow> removedRowsList = new List<DataGridViewRow>();


            for (int i = 0; i < selectGridView.Rows.Count; i++)
            {
                if (Convert.ToBoolean(selectGridView.Rows[i].Cells[selectGridView.Columns.Count - 1].Value))
                {
                    bool nonRepeated = true;

                    foreach (DataGridViewRow lig in mainForm.mainLigatureDataGridView.Rows)
                    {
                        if (nonRepeated && selectGridView.Rows[i].Cells[0].Value.ToString() == lig.Cells[0].Value.ToString())
                            nonRepeated = false;
                    }
                    if (nonRepeated)
                    {
                        string ligName = filesPath + $"\\{selectGridView.Rows[i].Cells[0].Value}" + ".json";
                        string json = File.ReadAllText(ligName);
                        SaveLoadLigature ligatureToAdd = JsonConvert.DeserializeObject<SaveLoadLigature>(json);
                        addedToLigList.Add(ligatureToAdd);
                    }
                }
                else
                    foreach (DataGridViewRow lig in mainForm.mainLigatureDataGridView.Rows)
                    {
                        if (selectGridView.Rows[i].Cells[0].Value.ToString() == lig.Cells[0].Value.ToString())
                        {
                            string ligName = filesPath + $"\\{selectGridView.Rows[i].Cells[0].Value}" + ".json";
                            string json = File.ReadAllText(ligName);
                            SaveLoadLigature ligatureToAdd = JsonConvert.DeserializeObject<SaveLoadLigature>(json);
                            removedLig.Add(ligatureToAdd);

                            removedRowsList.Add(lig);
                        }
                    }
            }
            mainForm.GetSelectedLigatures(addedToLigList, removedLig, removedRowsList);

            this.Close();
        }

        /// <summary>
        /// returns back without saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cencelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
