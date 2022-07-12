using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace RESUME_GENERATOR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvertToPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog myPDF = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                // The Objects created from the class Resume Information
                ResumeInformation myInformation = new ResumeInformation();
                myInformation.FirstName = txtFirstName.Text;
                myInformation.MiddleName = txtMiddleName.Text;
                myInformation.LastName = txtLastName.Text;
                myInformation.CareerObjectives = txtCareerObjectives.Text;
                myInformation.Address = txtAddress.Text;
                myInformation.EmailAddress = txtEmailAddress.Text;
                myInformation.PhoneNumber = txtPhoneNumber.Text;
                myInformation.CivilStatus = txtCivilStatus.Text;
                myInformation.Birthday = txtBirthday.Text;
                myInformation.SoftSkills = txtSoftSkills.Text;
                myInformation.HardSkills = txtHardSkills.Text;
                myInformation.Elementary = txtElementary.Text;
                myInformation.JuniorHighSchool = txtJuniorHighSchool.Text;
                myInformation.SeniorHighSchool = txtSeniorHighSchool.Text;
                myInformation.College = txtCollege.Text;
                myInformation.Experience = txtExperience.Text;

                // Reading JSON File
                string jsonDetails = JsonConvert.SerializeObject(myInformation);
                MessageBox.Show("The information you entered is succesfully stored", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.WriteAllText(@"C:\Users\ASUS DEMO\Downloads\Resume\resume.json", jsonDetails);

                jsonDetails = String.Empty;
                jsonDetails = File.ReadAllText(@"C:\Users\ASUS DEMO\Downloads\Resume\resume.json");
                ResumeInformation empty = JsonConvert.DeserializeObject<ResumeInformation>(jsonDetails);
                MessageBox.Show(empty.ToString());

                if (myPDF.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document files = new iTextSharp.text.Document(PageSize.A4.Rotate());
                    try
                    {
                        PdfWriter.GetInstance(files, new FileStream(myPDF.FileName, FileMode.Create));
                        files.Open();
                        files.Add(new iTextSharp.text.Paragraph(empty.ToString())); // The empty is from the 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        files.Close();
                    }
                }
            }
        }
    }
}
