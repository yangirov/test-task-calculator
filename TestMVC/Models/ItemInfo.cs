using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace TestMVC.Models
{
	public class Item
	{
        [DisplayName("Номер платежа")]
        public int Id { get; set; }

        [DisplayName("Дата платежа")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DisplayName("Размер платежа по %")]
        public int SumBody { get; set; }

        [DisplayName("Размер платежа по %")]
        public double SumPercent { get; set; }
    }
}