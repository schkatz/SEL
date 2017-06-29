using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Model
{
   public  class Users
    {
       

        public int User_ID { get; set; }
        public int UserRole_ID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserNick { get; set; }
        public Nullable<int> UserAge { get; set; }
        public string UserSchool { get; set; }
        public string UserPassword { get; set; }
        public string UserEmailAdress { get; set; }

        
    }
}
