// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML.Data;
using System.Web.Helpers;

namespace AirDropML.Model
{
    public class ModelInput
    {
        

        [ColumnName("Date"), LoadColumn(0)]
        public string Date { get; set; }


        [ColumnName("Price"), LoadColumn(1)]
        public float Price { get; set; }


        [ColumnName("Open"), LoadColumn(2)]
        public float Open { get; set; }


        [ColumnName("High"), LoadColumn(3)]
        public float High { get; set; }


        [ColumnName("Low"), LoadColumn(4)]
        public float Low { get; set; }


        [ColumnName("Vol."), LoadColumn(5)]
        public string Vol_ { get; set; }


        [ColumnName("Change"), LoadColumn(6)]
        public string Change { get; set; }


    }
}
