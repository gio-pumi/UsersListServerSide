using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using Users.Models;

namespace Users.Controllers
{
    [RoutePrefix("api/getAllUSers")]
    [EnableCors("*", "*", "*")]

    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("")]
        public List<List<User>> getAllUsers()
        {
            //Get JSON File
            string jsonString = File.ReadAllText(@"C:\Users\Pumi\source\repos\Users\Users\App_Start\config\users.json");

            //Sort JSON File
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<User> listOfUsers = (List<User>)javaScriptSerializer.Deserialize(jsonString,typeof(List<User>));
            listOfUsers.Sort();
            
            int sizeOfTheList = listOfUsers.Count();
            List<List<User>> finalList = new List<List<User>>();
            User user;

            //Create A Users Groups
            List<User> Firstgroup  =  new List<User>();
            List<User> Secondgroup =  new List<User>();
            List<User> ThirdGroup  =  new List<User>();
            List<User> FourthGroup =  new List<User>();


            //Grouping the Users
            for (int i = 0; i < sizeOfTheList; i++)
            {
                List<User> dividedList = new List<User>();
                user = listOfUsers[i];

                if (user.birthdate.Month >= 1 && user.birthdate.Month <= 3)
                {
                    Firstgroup.Add(user);
                }
                else if (user.birthdate.Month >= 4 && user.birthdate.Month <= 6)
                {
                    Secondgroup.Add(user);
                }
                else if (user.birthdate.Month >= 7 && user.birthdate.Month <= 9)
                {
                    ThirdGroup.Add(user);
                }
                else if (user.birthdate.Month >= 10 && user.birthdate.Month <= 12)
                {
                    FourthGroup.Add(user);
                }
            }

            //Check the Lists, if it's empty don't add to finalList
            if(Firstgroup.Any())
            finalList.Add(Firstgroup);
            if(Secondgroup.Any())
            finalList.Add(Secondgroup);
            if(ThirdGroup.Any())
            finalList.Add(ThirdGroup);
            if(FourthGroup.Any())
            finalList.Add(FourthGroup);

            return finalList;
        }
    }
}
