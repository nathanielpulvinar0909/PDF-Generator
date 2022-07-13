using iTextSharp.text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using iTextSharp;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using PdfSharp.Drawing;
using System;
using System.IO;
using System.Windows.Forms;
using PdfSharp.Pdf;

namespace RESUME_GENERATOR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public  class ResumeInformation
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string CareerObjectives { get; set; }
            public string Address { get; set; }
            public string EmailAddress { get; set; }
            public string PhoneNumber { get; set; }
            public string CivilStatus { get; set; }
            public string Birthday { get; set; }
            public string Religion { get; set; }
            public string GitHubLink { get; set; }

            // SKills
            public string SoftSkills { get; set; }
            public string HardSkills { get; set; }

            // Education
            public string Elementary { get; set; }
            public string JuniorHighSchool { get; set; }
            public string SeniorHighSchool { get; set; }
            public string College { get; set; }

            // Experience
            public string Experience { get; set; }

            public override string ToString() // We are going to return a value.
            {
                return String.Format($"Personal Information:\nName: {FirstName} {MiddleName} {LastName}\nCareer Objectives: {CareerObjectives}\nAddress: {Address} \nEmail Address: {EmailAddress} \nPhone Number: {PhoneNumber} \nCivil Status: {CivilStatus} \nBirthday: {Birthday} \nSkills: \nSoft Skills:{SoftSkills} \nHard Skills: {HardSkills}\nEducation:\nElementary: {Elementary} \nJunior High School: {JuniorHighSchool}\nSenior High School: {SeniorHighSchool} \nCollege: {College} \nExperience: {Experience}");
            }
        }

        private void btnConvertToPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog myPDF = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                myPDF.InitialDirectory = @"C:\Users\ASUS DEMO\Downloads\Resume\" + txtLastName.Text.ToString() + "_" + txtFirstName.Text.ToString() + ".json";
                myPDF.FileName = txtLastName.Text.ToString() + "_" + txtFirstName.Text.ToString();

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
                myInformation.Religion = txtReligion.Text;
                myInformation.GitHubLink = txtGitHubLink.Text;
                myInformation.SoftSkills = txtSoftSkills.Text;
                myInformation.HardSkills = txtHardSkills.Text;
                myInformation.Elementary = txtElementary.Text;
                myInformation.JuniorHighSchool = txtJuniorHighSchool.Text;
                myInformation.SeniorHighSchool = txtSeniorHighSchool.Text;
                myInformation.College = txtCollege.Text;
                myInformation.Experience = txtExperience.Text;

                string jsonDetails = JsonConvert.SerializeObject(myInformation);

                ResumeInformation empty = JsonConvert.DeserializeObject<ResumeInformation>(jsonDetails);

                // Reading JSON File

                File.WriteAllText(@"C:\Users\ASUS DEMO\Downloads\Resume\.json", jsonDetails);

                jsonDetails = String.Empty;
                jsonDetails = File.ReadAllText(@"C:\Users\ASUS DEMO\Downloads\Resume\.json");
                var resultResume = JsonConvert.DeserializeObject<ResumeInformation>(jsonDetails);
                MessageBox.Show(resultResume.ToString());
                MessageBox.Show("The information you entered is succesfully stored", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
                if (myPDF.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document files = new iTextSharp.text.Document(PageSize.A4);
                    try
                    {
                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        PdfWriter.GetInstance(files, new FileStream(myPDF.FileName, FileMode.Create));

                        files.Open();

                        iTextSharp.text.Font line = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.HELVETICA.ToString(), 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        Paragraph linespace = new Paragraph($"______________________________________________________________________\n                                                                                ", line);
                        linespace.Alignment = Element.ALIGN_LEFT;
                        
                        // First Name Last Name
                        iTextSharp.text.Font line1 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 32, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        Paragraph header = new Paragraph(txtFirstName.Text.ToString().ToUpper() + " " + txtLastName.Text.ToString().ToUpper(), line1);
                        header.Alignment = Element.ALIGN_LEFT;
                        files.Add(header);
                        
                        // Career Objectives
                        iTextSharp.text.Font line2 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        Paragraph header2 = new Paragraph(txtCareerObjectives.Text, line2);
                        header2.Alignment = Element.ALIGN_LEFT;
                        files.Add(header2);
                        files.Add(linespace);

                        // Personal Information Title
                        iTextSharp.text.Font personalInformation = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.HELVETICA.ToString(), 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        Paragraph title1 = new Paragraph("PERSONAL INFORMATION: ", personalInformation);
                        title1.Alignment = Element.ALIGN_LEFT;
                        files.Add(title1);

                        // Details of Personal Information
                        iTextSharp.text.Font personalInformationDetails = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.HELVETICA.ToString(), 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        Paragraph content1 = new Paragraph($"   Address: {txtAddress.Text} \n   Email Address: {txtEmailAddress.Text}\n   Phone Number: {txtPhoneNumber.Text} \n   Civil Status: {txtCivilStatus.Text} \n   Birthday: {txtBirthday.Text} \n   Religion: {txtReligion.Text} \n   GitHubLink: {txtGitHubLink.Text}");
                        content1.Alignment = Element.ALIGN_LEFT;
                        files.Add(content1);
                        files.Add(linespace);

                        // Personal Skills Title
                        iTextSharp.text.Font skills = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.HELVETICA.ToString(), 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        Paragraph title2 = new Paragraph("SKILLS: ", skills);
                        title2.Alignment = Element.ALIGN_LEFT;
                        files.Add(title2);

                        // Details of Skills
                        iTextSharp.text.Font skillsDetails = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.HELVETICA.ToString(), 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        Paragraph content2 = new Paragraph($"Soft Skills: \n{txtSoftSkills.Text} \nHard Skills: \n{txtHardSkills.Text}", skillsDetails);
                        content2.Alignment = Element.ALIGN_LEFT;
                        files.Add(content2);
                        files.Add(linespace);

                        // Education Title
                        iTextSharp.text.Font education = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.HELVETICA.ToString(), 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        Paragraph title3 = new Paragraph("EDUCATION: ", education);
                        title3.Alignment = Element.ALIGN_LEFT;
                        files.Add(title3);

                        // Details of Education
                        iTextSharp.text.Font educationDetails = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.HELVETICA.ToString(), 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        Paragraph content3 = new Paragraph($"   Elementary: {txtElementary.Text} \n   Junior High School: {txtJuniorHighSchool.Text}\n   Senior High School: {txtSeniorHighSchool.Text} \n   College: {txtCollege.Text}", educationDetails);
                        content3.Alignment = Element.ALIGN_LEFT;
                        files.Add(content3);
                        files.Add(linespace);

                        // Experience Title
                        iTextSharp.text.Font experience = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.HELVETICA.ToString(), 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        Paragraph title4 = new Paragraph("EXPERIENCE: ", experience);
                        title4.Alignment = Element.ALIGN_LEFT;
                        files.Add(title4);

                        // Details of Experience
                        iTextSharp.text.Font experienceDetails = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.HELVETICA.ToString(), 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        Paragraph content4 = new Paragraph(txtExperience.Text, experienceDetails);
                        content4.Alignment = Element.ALIGN_LEFT;
                        files.Add(content4);
                        files.Add(linespace);

                        //files.Add(new iTextSharp.text.Paragraph(empty.ToString()));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        files.Close();
                        MessageBox.Show("Your File has been saved. Thank you!");
                        Application.Exit();
                    }
                }  
            }
        }
    }
}
