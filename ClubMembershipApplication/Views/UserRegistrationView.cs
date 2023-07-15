using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public class UserRegistrationView : IView
    {
        IFieldValidator? _fieldValidator = null;
        IRegister? _register = null;

        public IFieldValidator FieldValidator { get => _fieldValidator; }
        public UserRegistrationView(IRegister register, IFieldValidator fieldValidator)
        {
            _register = register;
            _fieldValidator = fieldValidator;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteRegistrationHeading();

            if (_fieldValidator != null)
            {
                _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.EMailAddress] = GetInputFromUser(FieldConstants.UserRegistrationField.EMailAddress, "Please enter you email address: ");
                _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.FirstName] = GetInputFromUser(FieldConstants.UserRegistrationField.FirstName, "Please enter you first name: ");
                _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.LastName] = GetInputFromUser(FieldConstants.UserRegistrationField.LastName, "Please enter you last name: ");
                _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Passwort] = GetInputFromUser(FieldConstants.UserRegistrationField.Passwort, $"Please enter you password.{Environment.NewLine}You password must contain at leas 1 small-case letter,{Environment.NewLine}1 Captital letter, 1 digit, 1 special character{Environment.NewLine} and the length should be between 6-10 characters: ");
                _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PasswortCompare] = GetInputFromUser(FieldConstants.UserRegistrationField.PasswortCompare, "Please re-enter you password: ");
                _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.DateOfBirth] = GetInputFromUser(FieldConstants.UserRegistrationField.DateOfBirth, "Please enter you day of birth: ");
                _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PhoneNumber] = GetInputFromUser(FieldConstants.UserRegistrationField.PhoneNumber, "Please enter you phone number: ");
                _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressFirstLine] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressFirstLine, "Please enter your first line of your address: ");
                _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressSecondLine] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressSecondLine, "Please enter your second line of your address: ");
                _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressCity] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressCity, "Please enter the city where you live: ");
                _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PostCode] = GetInputFromUser(FieldConstants.UserRegistrationField.PostCode, "Please enter the post code of your city: ");

                RegisterUser();
            }
            else
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("Registration failed. Missing fieldValidator object.");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }
        }

        private void RegisterUser()
        {
            if ((_register != null) && (_fieldValidator != null))
            {
                _register.Register(_fieldValidator.FieldArray);
                CommonOutputFormat.ChangeFontColor(FontTheme.Success);
                Console.WriteLine("You have successfully registered. Please press any key to login");
            }
            else
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("Registration failed. Missing fieldValidator & register object.");
            }
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);

            Console.ReadKey();
        }

        private string GetInputFromUser(FieldConstants.UserRegistrationField field, string promptText)
        {
            string? fieldVal = "";

            do
            {
                Console.Write(promptText);
                fieldVal = Console.ReadLine();

            } while (!FieldValid(field, ((fieldVal != null) ? fieldVal : "")));

            return ((fieldVal != null) ? fieldVal : "");
        }

        private bool FieldValid(FieldConstants.UserRegistrationField field, string fieldValue) 
        {
            if (_fieldValidator != null)
            {
                if (!_fieldValidator.ValidatorDel((int)field, fieldValue, _fieldValidator.FieldArray, out string invalidMessage))
                {
                    CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                    Console.WriteLine(invalidMessage);
                    CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                    return false;
                }
            }
            else
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("Registration failed. Missing fieldValidator object.");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                return false;
            }
            return true;
        }
    }
}
