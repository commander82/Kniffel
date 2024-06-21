using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kniffel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int w_w1, w_w2, w_w3, w_w4, w_w5 = 0;
        int versuche = 0;
        int rest;
        int game = 0;
        int runden;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["selectt1"].Index && e.RowIndex >= 0)
            {
                int sum = 0;
                switch (e.RowIndex)
                {
                    case 0: // Einser
                        if (w_w1 == 1) sum += 1;
                        if (w_w2 == 1) sum += 1;
                        if (w_w3 == 1) sum += 1;
                        if (w_w4 == 1) sum += 1;
                        if (w_w5 == 1) sum += 1;
                        break;
                    case 1:// Zweier
                        if (w_w1 == 2) sum += 2;
                        if (w_w2 == 2) sum += 2;
                        if (w_w3 == 2) sum += 2;
                        if (w_w4 == 2) sum += 2;
                        if (w_w5 == 2) sum += 2;
                        break;
                    case 2:// Dreier
                        if (w_w1 == 3) sum += 3;
                        if (w_w2 == 3) sum += 3;
                        if (w_w3 == 3) sum += 3;
                        if (w_w4 == 3) sum += 3;
                        if (w_w5 == 3) sum += 3;
                        break;
                    case 3:// Vierer
                        if (w_w1 == 4) sum += 4;
                        if (w_w2 == 4) sum += 4;
                        if (w_w3 == 4) sum += 4;
                        if (w_w4 == 4) sum += 4;
                        if (w_w5 == 4) sum += 4;
                        break;
                    case 4:// Fünfer
                        if (w_w1 == 5) sum += 5;
                        if (w_w2 == 5) sum += 5;
                        if (w_w3 == 5) sum += 5;
                        if (w_w4 == 5) sum += 5;
                        if (w_w5 == 5) sum += 5;
                        break;
                    case 5://Sechser
                        if (w_w1 == 6) sum += 6;
                        if (w_w2 == 6) sum += 6;
                        if (w_w3 == 6) sum += 6;
                        if (w_w4 == 6) sum += 6;
                        if (w_w5 == 6) sum += 6;
                        break;
                }
                if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + game].Value != null)
                {
                    MessageBox.Show("Das hast du schon eingetragen", "Schon belegt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + game].Value = sum;
                    reset();
                }


            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["selectt2"].Index && e.RowIndex >= 0)
            {
                int sum = 0;
                switch (e.RowIndex)
                {
                    case 0: // DreierPash
                        int[] array = { w_w1, w_w2, w_w3, w_w4, w_w5 };
                        for (int i = 0; i < array.Length; i++)
                        {
                            for (int j = i + 1; j < array.Length; j++)
                            {
                                for (int k = j + 1; k < array.Length; k++)
                                {
                                    if (array[i] == array[j] && array[j] == array[k])
                                    {
                                        sum = w_w1 + w_w2 + w_w3 + w_w4 + w_w5;
                                        break;
                                    }

                                }
                            }
                        }
                        break;
                    case 1: // Vierepasch
                        int[] array4er = { w_w1, w_w2, w_w3, w_w4, w_w5 };
                        for (int i = 0; i < array4er.Length; i++)
                        {
                            for (int j = i + 1; j < array4er.Length; j++)
                            {
                                for (int k = j + 1; k < array4er.Length; k++)
                                {
                                    for (int l = k + 1; l < array4er.Length; l++)
                                    {
                                        if (array4er[i] == array4er[j] && array4er[j] == array4er[k] && array4er[k] == array4er[l] )
                                        {
                                            sum = w_w1 + w_w2 + w_w3 + w_w4 + w_w5;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case 2: // Full House
                        var counts = new Dictionary<int, int>();

                        foreach (var w in new[] { w_w1, w_w2, w_w3, w_w4, w_w5 })
                        {
                            if (counts.ContainsKey(w))
                            {
                                counts[w]++;
                            }
                            else
                            {
                                counts[w] = 1;
                            }
                        }

                        // Überprüfe, ob ein Full House vorliegt
                        bool isFullHouse = counts.ContainsValue(3) && counts.ContainsValue(2);

                        if (isFullHouse)
                        {
                            sum = 25;
                        }
                        break;
                    case 3: // Kleine Straße
                        bool[] numbk = { false, false, false, false, false};
                        for (int i = 1; i <= 5; i++)
                        {
                            if(w_w1 == i) { numbk[i - 1] = true; }
                            if(w_w2 == i) { numbk[i - 1] = true; }
                            if(w_w3 == i) { numbk[i - 1] = true; }
                            if(w_w4 == i) { numbk[i - 1] = true; }
                            if(w_w5 == i) { numbk[i - 1] = true; }
                        }
                        if (numbk[0] && numbk[1] && numbk[2] && numbk[3] && numbk[4]) sum = 30;

                        break;
                    case 4: // Große Straße
                        bool[] numbG = { false, false, false, false, false };
                        for (int i = 2; i <= 6; i++)
                        {
                            if (w_w1 == i) { numbG[i-2] = true; }
                            if (w_w2 == i) { numbG[i-2] = true; }
                            if (w_w3 == i) { numbG[i-2] = true; }
                            if (w_w4 == i) { numbG[i-2] = true; }
                            if (w_w5 == i) { numbG[i-2] = true; }
                        }
                        if (numbG[0] && numbG[1] && numbG[2] && numbG[3] && numbG[4]) sum = 40;
                        break;
                    case 5:// Kniffel
                        if(w_w1 == w_w2 && w_w2 == w_w3 && w_w3 == w_w4 && w_w4 == w_w5)
                        { 
                            sum = 50;
                        }
                        break;
                    case 6: // Chance
                        sum = w_w1 + w_w2 + w_w3 + w_w4 + w_w5;
                        break;
                }
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex + game].Value != null)
                {
                    MessageBox.Show("Das hast du schon eingetragen", "Schon belegt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (sum != 0)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex + game].Value = sum;
                        reset();
                    }
                    else
                    {
                        DialogResult Dialog = MessageBox.Show("Willst dur wirklich \"" + dataGridView2.Rows[e.RowIndex].Cells[0].Value + "\" Streichen", "Streichen", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if(Dialog == DialogResult.Yes)
                        {
                            dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex + game].Value = 0;
                            reset();
                        }
                    }
                    
                }


            }
        }

        private void Form1_Load(object sender, EventArgs e)       {
           // deaktiverien vom Würfelkopf und aktivieren Neues Spiel
            bttn_newGame.Enabled = true;
            bttn_newGame.Visible = true;
            bttn_wuerfeln.Enabled = false;
            bttn_wuerfeln.Visible = false;

            pBox_W1.Load(Application.StartupPath + "/wuerfel/w0.png");
            pBox_W2.Load(Application.StartupPath + "/wuerfel/w0.png");
            pBox_W3.Load(Application.StartupPath + "/wuerfel/w0.png");
            pBox_W4.Load(Application.StartupPath + "/wuerfel/w0.png");
            pBox_W5.Load(Application.StartupPath + "/wuerfel/w0.png");
            dataGridView1.Rows.Insert(0,"Einser");
            dataGridView1.Rows.Insert(1,"Zweier");
            dataGridView1.Rows.Insert(2,"Dreier");
            dataGridView1.Rows.Insert(3,"Vierer");
            dataGridView1.Rows.Insert(4,"Fünfer");
            dataGridView1.Rows.Insert(5,"Sechser");

            dataGridView2.Rows.Insert(0, "Dreierpasch");
            dataGridView2.Rows.Insert(1, "Viererpasch");
            dataGridView2.Rows.Insert(2, "Fullhouse");
            dataGridView2.Rows.Insert(3, "Klein Straße");
            dataGridView2.Rows.Insert(4, "Große Straße");
            dataGridView2.Rows.Insert(5, "Kniffel");
            dataGridView2.Rows.Insert(6, "Chance");
        }

        private void bttn_newGame_Click(object sender, EventArgs e)
        { // neues Spiel starten 
            // Button deaktivieren und spiel Beginnen
            bttn_newGame.Enabled = false;
            bttn_newGame.Visible = false;
            bttn_wuerfeln.Enabled = true;
            bttn_wuerfeln.Visible = true;
            rest = 3 - versuche;
            bttn_wuerfeln.Text = "Würfeln \n (" + rest + " Versuche noch)"; 
            game++;
            runden = 1;
        }

        private void pBox_W1_Click(object sender, EventArgs e)
        {
            // auf welche Box wurde geklick speicheren in pictureBox
            PictureBox pictureBox = (PictureBox) sender;

            // if(pictureBox.Name=="pBox_W1") ... Die Anweisung
            // if(pictureBox.Name=="pBox_W2") ... Die Anweisung
            // if(pictureBox.Name=="pBox_W3") ... Die Anweisung
            // if(pictureBox.Name=="pBox_W4") ... Die Anweisung
            // if(pictureBox.Name=="pBox_W5") ... Die Anweisung


            switch (pictureBox.Name)
            {
                case "pBox_W1":
                    if (!cBox_W1.Checked) 
                    {
                        cBox_W1.Checked = true;
                    }
                    else
                    {
                        cBox_W1.Checked = false;
                    }
                    break;

                case "pBox_W2":
                    if (!cBox_W2.Checked)
                    {
                        cBox_W2.Checked = true;
                    }
                    else
                    {
                        cBox_W2.Checked = false;
                    }
                    break;

                case "pBox_W3":
                    if (!cBox_W3.Checked)
                    {
                        cBox_W3.Checked = true;
                    }
                    else
                    {
                        cBox_W3.Checked = false;
                    }
                    break;

                case "pBox_W4":
                    if (!cBox_W4.Checked)
                    {
                        cBox_W4.Checked = true;
                    }
                    else
                    {
                        cBox_W4.Checked = false;
                    }
                    break;

                case "pBox_W5":
                    if (!cBox_W5.Checked)
                    {
                        cBox_W5.Checked = true;
                    }
                    else
                    {
                        cBox_W5.Checked = false;
                    }
                    break;
            }
        }

        private void bttn_wuerfeln_Click(object sender, EventArgs e)
        {
            if (versuche < 3)
            {
                var random = new Random();

                if (!cBox_W1.Checked)
                {
                    w_w1 = random.Next(1, 7);
                    pBox_W1.Load(Application.StartupPath + "/wuerfel/W" + w_w1 + ".png");
                }
                if (!cBox_W2.Checked)
                {
                    w_w2 = random.Next(1, 7);
                    pBox_W2.Load(Application.StartupPath + "/wuerfel/W" + w_w2 + ".png");
                }
                if (!cBox_W3.Checked)
                {
                    w_w3 = random.Next(1, 7);
                    pBox_W3.Load(Application.StartupPath + "/wuerfel/W" + w_w3 + ".png");
                }
                if (!cBox_W4.Checked)
                {
                    w_w4 = random.Next(1, 7);
                    pBox_W4.Load(Application.StartupPath + "/wuerfel/W" + w_w4 + ".png");
                }
                if (!cBox_W5.Checked)
                {
                    w_w5 = random.Next(1, 7);
                    pBox_W5.Load(Application.StartupPath + "/wuerfel/W" + w_w5 + ".png");
                }
                versuche++;
                if (versuche > 0)
                {
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView2.Columns[1].Visible = true;
                }
                rest = 3 - versuche;
                bttn_wuerfeln.Text = "Würfeln \n (" + rest + " Versuche noch)";
            }
            else
            {
                MessageBox.Show("Maximale Versuche erreicht", "Versuche", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void reset()
        {

            dataGridView1.Columns[1].Visible = false;
            dataGridView2.Columns[1].Visible = false;
            versuche = 0;
            cBox_W1.Checked = false;
            cBox_W2.Checked = false;
            cBox_W3.Checked = false;
            cBox_W4.Checked = false;
            cBox_W5.Checked = false;
            rest = 3 - versuche;
            bttn_wuerfeln.Text = "Würfeln \n (" + rest + " Versuche noch)";
            runden++;
            if(runden >= 14)
            {
                bttn_newGame.Enabled = true;
                bttn_newGame.Visible = true;
                bttn_wuerfeln.Enabled = false;
                bttn_wuerfeln.Visible = false;
            }
        }
    }
}
