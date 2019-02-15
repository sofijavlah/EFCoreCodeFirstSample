using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EFCoreCodeFirstSample.Models
{
    public class Employee
    {
        //We have decorated the EmployeeId property with Key and DatabaseGenerated attributes.
        //We did this because we will be converting this class into a database table
        //and the column EmployeeId will serve as our primary key
        //with the auto-incremented identity.

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        
        //public static List<Employee> Employees
        //{
        //    get
        //    {
        //        var jsonLoad = File.ReadAllText("zaposleni.json");
        //        var list = JsonConvert.DeserializeObject<List<Employee>>(jsonLoad);
        //        return list;
        //    }
        //}
    }
}
