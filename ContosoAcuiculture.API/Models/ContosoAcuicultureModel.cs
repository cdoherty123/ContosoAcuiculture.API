using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Cosmos;

namespace ContosoAcuiculture.API.Models

{
    public class ContosoAcuicultureModel
    {
        //These are only samples until we recieve the database
            [Key]
            public int ID { get; set; }
            public int ShrimpID { get; set; }
            public float AverageWeight { get; set; }
            public int DailyFeed { get; set; }
            public int EstimatedSurvival { get; set; } 
            public string Observations { get; set; }
        
    }
}
