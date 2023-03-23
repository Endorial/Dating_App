using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations; // [Key] comes from here 
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    
    public class AppUser
    {
       public int Id { get; set; } 
       public string UserName { get; set; }
       

    }
    
}