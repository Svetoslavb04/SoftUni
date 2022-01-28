using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class BuyerDTO
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("boughtCars")]

        public int BoughtCars { get; set; }

        [JsonProperty("spentMoney")]

        public decimal SpentMoney { get; set; }
    }
}
