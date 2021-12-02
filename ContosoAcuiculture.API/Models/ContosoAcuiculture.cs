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
        
            [Key]
            public int OfficeID { get; set; }
            public string Name { get; set; }
            public int SiteID { get; set; }
        
    }
}
