using KieForms.Configurations;
using KieForms.Model;
using System;
using System.Windows.Forms;

namespace KieForms
{
    public partial class Form1 : Form
    {
        private Medicament medicament = new Medicament();
        private Question question = new Question();
        private Answer answer = new Answer();
        private Organe organe;
        private bool first= true;
        private static string next_item ="";
        private ExecuteRules rules = new ExecuteRules();
        private Configuration configuration = Configuration.GetConfiguration();
        private string name_container = Configuration.GetConfiguration().ContainerName1;
        
        public Form1()
        {
            InitializeComponent();
        }

        private async void Valider_Click(object sender, EventArgs e)
        {            
            var reponse = Convert.ToString(comboRep.SelectedItem);
            if (reponse != "") { 
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

                var json = await rules.ExecuteAsyncjson(insertObject, name_container);
                var result = json.SmartSingleResponse;
                labelQuestions.Text = result.question.description;

                LoadComboItems(result);

                if (result.medicament.nomMedic != null)
                {
                    MessageBox.Show(this, "Nom du medicament " + result.medicament.nomMedic, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Valider.Enabled = false;
                }
                next_item = result.answer.type;
            }
            else
            {
                MessageBox.Show("Sélectionner une réponse svp");
            }
        }

        private void LoadComboItems(Context result)
        {
            if(result.answer.descp != null)
            {
                comboRep.DataSource = result.answer.descp;

                foreach (var answerDesp in result.answer.descp)
                {
                    comboRep.DisplayMember = answerDesp;
                }
            }
            
        }
    }
}
