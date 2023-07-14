using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FieldValidators
{
    public class FieldConstants
    {
        public enum UserRegistrationField
        {
            EMailAddress,
            FirstName,
            LastName,
            Passwort,
            PasswortCompare,
            DateOfBirth,
            PhoneNumber,
            AddressFirstLine,
            AddressSecondLine,
            AddressCity,
            PostCode
        }
    }
}
