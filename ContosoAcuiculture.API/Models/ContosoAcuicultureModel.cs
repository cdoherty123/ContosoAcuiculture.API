using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace ContosoAcuiculture.API.Models

{
    public class ContosoAcuicultureModel
    {
        //These are only samples until we recieve the database
            [Key]
            [JsonProperty(PropertyName = "id")]
            public int ID { get; set; }
            [JsonProperty(PropertyName = "shrimpid")]
            public int ShrimpID { get; set; }
            [JsonProperty(PropertyName = "shrimpcolor")]
            public string ShrimpColor{ get; set; }
            [JsonProperty(PropertyName = "averageweight")]
            public float AverageWeight { get; set; }
            [JsonProperty(PropertyName = "dailyfeed")]
            public int DailyFeed { get; set; }
            [JsonProperty(PropertyName = "estimatedsurvival")]
            public int EstimatedSurvival { get; set; }
            [JsonProperty(PropertyName = "observations")]
            public string Observations { get; set; }
        
    }
}
