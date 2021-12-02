using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ContosoAcuiculture.API.Models
{
    public class ContosoAcuiculture
    {
        //These are only samples until we recieve the database
            [Key]
            public int ShrimpNumber { get; set; }
            public string Name { get; set; }
            public int SiteID { get; set; }
        
    }
}
