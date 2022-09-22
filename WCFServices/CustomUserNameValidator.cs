using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WCFServices {
    public class CustomUserNameValidator : System.IdentityModel.Selectors.UserNamePasswordValidator {
        // This method validates users. It allows in two users, test1 and test2 
        // with passwords 1tset and 2tset respectively.
        // This code is for illustration purposes only and 
        // MUST NOT be used in a production environment because it is NOT secure.	
        public override void Validate(string userName, string password) {
            if (null == userName || null == password) {
                throw new ArgumentNullException();
            }

            if (!(userName == "test1" && password == "12345") && !(userName == "test2" && password == "12345")) {
                throw new FaultException("Unknown Username or Incorrect Password");
            }
        }
    }
}