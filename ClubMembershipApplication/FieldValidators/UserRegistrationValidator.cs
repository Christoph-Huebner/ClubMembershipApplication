using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FieldValidators
{
    public class UserRegistrationValidator
    {
        const int FirstName_Min_Length = 2;
        const int FirstName_Max_Length = 100;
        const int LastName_Min_Length = 2;
        const int LastName_Max_Length = 100;

        delegate bool EmailExistsDel (string emailAddress);

        FieldValidatorDel? _fieldValidatorDel = null;

        RequiredValidDel? _requiredValidDel = null;
        StringLengthValidDel? _stringLengthValidDel = null;
        DateValidDel? _dateValidDel = null;
        PatternMatchDel? _patternMatchDel = null;
        CompareFieldsValidDel? _compareFieldsValidDel = null;

    }
}
