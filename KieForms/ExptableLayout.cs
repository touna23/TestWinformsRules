using KieForms.Configurations;
using KieForms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KieForms.Utils;

namespace KieForms
{
    public partial class ExptableLayout : Form
    {
        private Medicament medicament = new Medicament();
        private Question question = new Question();
        private Answer answer = new Answer();
        private Organe organe;
        private bool first = true;
        private static string next_item = "";
        private ExecuteRules rules = new ExecuteRules();
        private Configuration configuration = Configuration.GetConfiguration();
        private string name_container = Configuration.GetConfiguration().ContainerName1;
        int columnCount, rowCount;

        public ExptableLayout()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string reponse = (sender as Button).Text;

            if (reponse != "")
            {
                if (first)
                {
                    organe = new Organe { nomOrgane = reponse };
                    first = false;
                }

                if (next_item != "")
                {
                    if (next_item == AnswerTypeEnum.typeMaux.ToString())
                        organe.typeMaux = reponse;
                    else
                        if (next_item == AnswerTypeEnum.localisation.ToString())
                        organe.localisation = reponse;
                }

                Context insertObject = new Context(medicament, organe, answer, question);

                var json_result = await rules.ExecuteAsyncjson(insertObject, name_container);
                var result = json_result.SmartSingleResponse;

                if (result.question.description != null)
                    LoadLayout(result, tableLayoutQuestion, 2, 1);

                if (result.answer.descp != null)
                {
                    int nbResult = result.answer.descp.Count;
                    columnCount = 2;
                    rowCount = nbResult / 2;
                    LoadLayout(result, tableLayoutResponse, columnCount, rowCount);
                }

                if (result.medicament.nomMedic != null)
                {
                    MessageBox.Show(this, "Nom du medicament " + result.medicament.nomMedic, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form_controls form_controls = new Form_controls();
                    form_controls.EnableDisableButtonControls(false, this);
                }
                next_item = result.answer.type;
            }
            else
            {
                MessageBox.Show("Sélectionner une réponse svp");
            }
        }

        private void LoadLayout(Context result, TableLayoutPanel tableLayout, int columnCount, int rowCount)
        {
            int compteurResult = 0;
            int nbResult = result.answer.descp.Count;
            //Clear out the existing controls, we are generating a new table layout
            tableLayout.Controls.Clear();

            //Clear out the existing row and column styles
            tableLayout.ColumnStyles.Clear();
            tableLayout.RowStyles.Clear();

            tableLayout.ColumnCount = columnCount;
            if (rowCount != 0)
                tableLayout.RowCount = rowCount;
            else
                tableLayout.RowCount = 1;

            for (int x = 0; x < columnCount; x++)
            {
                //First add a column
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                for (int y = 0; y < rowCount; y++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x == 0)
                    {
                        tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }

                    if (tableLayout == tableLayoutQuestion)
                    {
                        tableLayoutQuestion.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        labelQuestions.Text = result.question.description;
                        tableLayoutQuestion.Controls.Add(labelQuestions, x, y);
                    }
                    else if (tableLayout == tableLayoutResponse)
                    {
                        //Create the control, in this case we will add a button
                        if (nbResult > compteurResult)
                        {
                            Button cmd = new Button();
                            cmd.AutoSize = true;
                            cmd.Text = result.answer.descp[compteurResult];
                            cmd.Click += new System.EventHandler(this.button2_Click);
                            compteurResult++;        
                            //Finally, add the control to the correct location in the table                            
                            tableLayoutResponse.Controls.Add(cmd, x, y);
                        }
                    }
                }
            }
            tableLayout.Padding = new Padding(0, 0, System.Windows.Forms.SystemInformation.VerticalScrollBarWidth, 0);
        }
        //private void loadQuestion(Context result)
        //{
        //    tableLayoutQuestion.Controls.Clear();

        //    //Clear out the existing row and column styles
        //    tableLayoutQuestion.ColumnStyles.Clear();
        //    tableLayoutQuestion.RowStyles.Clear();
        //    tableLayoutQuestion.RowCount = 1;
        //    tableLayoutQuestion.ColumnCount = 2;

        //        for (int x = 0; x < 2; x++)
        //        {                
        //            tableLayoutQuestion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        //            for (int y = 0; y < 1; y++)
        //            {
        //                if (x == 0)
        //                {
        //                    tableLayoutQuestion.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        //                }
        //                tableLayoutQuestion.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        //                labelQuestions.Text = result.question.description;
        //                tableLayoutQuestion.Controls.Add(labelQuestions, x, y);
        //            }
        //        }                     
        //}

        //private void loadResponse(Context result)
        //{
        //    //Clear out the existing controls, we are generating a new table layout
        //    tableLayoutResponse.Controls.Clear();

        //    //Clear out the existing row and column styles
        //    tableLayoutResponse.ColumnStyles.Clear();
        //    tableLayoutResponse.RowStyles.Clear();            

        //        int compteurResult = 0;
        //        int nbResult = result.answer.descp.Count;
        //        //Now we will generate the table, setting up the row and column counts first
        //        columnCount = 3;
        //        rowCount = nbResult / 3;
        //        tableLayoutResponse.ColumnCount = columnCount;

        //        if (rowCount != 0)
        //            tableLayoutResponse.RowCount = rowCount;
        //        else
        //        {
        //            rowCount = 1;
        //            tableLayoutResponse.RowCount = rowCount;
        //        }                    

        //        for (int x = 0; x < columnCount; x++)
        //        {
        //            //First add a column
        //            tableLayoutResponse.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

        //            for (int y = 0; y < rowCount; y++)
        //            {
        //                //Next, add a row.  Only do this when once, when creating the first column
        //                if (x == 0)
        //                {
        //                    tableLayoutResponse.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        //                }

        //                //Create the control, in this case we will add a button
        //                if (nbResult > compteurResult)
        //                {
        //                    Button cmd = new Button();
        //                    cmd.Text = result.answer.descp[compteurResult];
        //                    using (Graphics cg = this.CreateGraphics())
        //                    {
        //                        SizeF size = cg.MeasureString(cmd.Text, cmd.Font);
        //                        cmd.Width = (int)size.Width;
        //                    }
        //                    cmd.Click += new System.EventHandler(this.button2_Click);
        //                    compteurResult++;        //Finally, add the control to the correct location in the table
        //                    tableLayoutResponse.Controls.Add(cmd, x, y);
        //                }

        //            }
        //        }

        //}   
    }
}
