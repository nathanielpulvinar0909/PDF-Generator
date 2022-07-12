using System;

public class Class1
{
    public class ResumeInformation
    {
        // Personal Information
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string CareerObjectives;
        public string Address;
        public string EmailAddress;
        public string PhoneNumber;
        public string CivilStatus;
        public string Birthday;

        // SKills
        public string SoftSkills;
        public string HardSkills;

        // Education
        public string Elementary;
        public string JuniorHighSchool;
        public string SeniorHighSchool;
        public string College;

        // Experience
        public string Experience;

        public override string ToString() // We are going to return a value.
        {
            return ($"Personal Information:\n\tName: {FirstName} {MiddleName} {LastName}\n\tCareer Objectives: {CareerObjectives}\n\tAddress: {Address} \n\tEmail Address: {EmailAddress} \n\tPhone Number: {PhoneNumber} \n\tCivil Status: {CivilStatus} \n\tBirthday: {Birthday} \n\tSkills: \n\tSoft Skills:{SoftSkills} \n\tHard Skills: {HardSkills}\n\tEducation:\n\tElementary: {Elementary} \n\tJunior High School: {JuniorHighSchool}\n\tSenior High School: {SeniorHighSchool} \n\tCollege: {College} \n\tExperience: {Experience}");
        }
    }

    public Class1()
	{
	}
}
