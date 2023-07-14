using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public class UserLoginView : IView
    {
        ILogin _login = null;
        public IFieldValidator FieldValidator => null;

        public UserLoginView(ILogin login)
        {
            _login = login;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter you email address");
            string? emailAddress = Console.ReadLine();
            Console.WriteLine("Please enter you password");
            string? password = Console.ReadLine();

            User user = _login.Login(emailAddress, password);
            if (user != null)
            {
                // ToDo: Run Welcome View
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credentials that you entered do not match our records");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }
        }
    }
}
