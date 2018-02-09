using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
	public class CreditInfo
	{
		public int Id { get; set; }

        [DisplayName("Сумма")]
        [Range(0, 1000000)]
        [Required(ErrorMessage = "Не заполнено поле")]
        public int Sum { get; set; }

        [DisplayName("Срок")]
        [Range(1, 36)]
        [Required(ErrorMessage = "Не заполнено поле")]
        public int Period { get; set; }

        [DisplayName("Ставка в год")]
        [Range(0, 100)]
        [Required(ErrorMessage = "Не заполнено поле")]
        public int RateYear { get; set; }

        [DisplayName("Задать шаг платежа")]
        public bool DayStep { get; set; }

        [DisplayName("Шаг платежа")]
        [Range(1, 30)]
        public int StepPayment { get; set; }
    }
}