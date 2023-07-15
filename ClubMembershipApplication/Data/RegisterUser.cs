using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.FieldValidators;

namespace ClubMembershipApplication.Data
{
    public class RegisterUser : IRegister
    {
        public bool EmailExists(string emailAddress)
        {
            bool emailExists = false;

            using (var dbContext = new ClubMembershipDbContext())
            {
                emailExists = dbContext.User.Any(u => u.EMailAdress.ToLower().Trim() == emailAddress.Trim().ToLower());
            }
            return emailExists;
        }

        public bool Register(string[] fields)
        {
            using var dbContext = new ClubMembershipDbContext();
            {
                User user = new User
                {
                    EMailAdress = fields[(int)FieldConstants.UserRegistrationField.EMailAddress],
                    FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                    Password = fields[(int)FieldConstants.UserRegistrationField.Passwort],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                    AddressFirstLine = fields[(int)FieldConstants.UserRegistrationField.AddressFirstLine],
                    AddressSecondLine = fields[(int)FieldConstants.UserRegistrationField.AddressSecondLine],
                    AddressCity = fields[(int)FieldConstants.UserRegistrationField.AddressCity],
                    PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode]
                };
                dbContext.User.Add(user);
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}
