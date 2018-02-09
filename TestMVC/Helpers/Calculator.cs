using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMVC.Models;

namespace TestMVC.Helpers
{
    public class Calculator
    {
        /// <summary>
        /// Рассчет ежемесячного аннуитетного платёж
        /// </summary>
        /// <param name="S">Сумма кредита</param>
        /// <param name="period">Срок в месяцах</param>
        /// <param name="yearRate">Годовая ставка (в процентах)</param>
        /// <returns>Ежемесячный аннуитетный платёж</returns>
        public double Annuity(int S, int period, int yearRate)
        {
            double A; // Ежемесячный аннуитетный платёж
            double K; // Коэффициент аннуитета
            int n = period;
            double i = (double)(yearRate * 0.01) / 12; // Месячная процентная ставка по кредиту

            K = (i * Math.Pow(1 + i, n)) / (Math.Pow(1 + i, n) - 1); // Формула расчета коэффициента аннуитета
            A = K * S; // Формула расчёта ежемесячного аннуитетного платёжа

            return Math.Round(A, 2);
        }

        /// <summary>
        /// Расчет переплаты по кредиту
        /// </summary>
        /// <param name="S">Сумма кредита</param>
        /// <param name="period">Срок в месяцах</param>
        /// <param name="annuity">Ежемесячный аннуитетный платёж</param>
        /// <returns>Переплата по кредиту</returns>
        public double OverPayments(int S, int period, double annuity)
        {
            return Math.Round(period * annuity - S, 2);
        }

        /// <summary>
        /// Расчет итоговой суммы
        /// </summary>
        /// <param name="S">Сумма кредита</param>
        /// <param name="period">Срок в месяцах</param>
        /// <param name="annuity">Ежемесячный аннуитетный платёж</param>
        /// <returns>Итого</returns>
        public double Total(int S, int period, double annuity)
        {
            return Math.Round(S + (period * annuity - S), 2);
        }

        /// <summary>
        /// Расчёт графика платежей (по месяцам)
        /// </summary>
        /// <param name="A">Ежемесячный аннуитетный платёж</param>
        /// <param name="S">Сумма кредита</param>
        /// <param name="period">Срок в месяцах</param>
        /// <returns>График платежей</returns>
        public List<Item> GetItemsByMonth(int S, int period, double A)
        {
            List<Item> items = new List<Item>();
            DateTime date = DateTime.Now.Date;

            for (int j = 0; j < period; j++)
            {
                items.Add(new Item() { Id = j + 1, Date = date, SumBody = S / period, SumPercent = Math.Round(A, 2) });
                date = date.Date.AddMonths(1);
            }

            return items;
        }

        /// <summary>
        /// Расчёт графика платежей (по дням)
        /// </summary>
        /// <param name="A">Ежемесячный аннуитетный платёж</param>
        /// <param name="S">Сумма кредита</param>
        /// <param name="period">Срок в месяцах</param>
        /// <returns>График платежей</returns>
        public List<Item> GetItemsByDays(int S, int period, double A, int step)
        {
            List<Item> items = new List<Item>();
            DateTime date = DateTime.Now.Date;
            int n = (period * 30) / step;

            for (int j = 0; j < n; j++)
            {
                items.Add(new Item() { Id = j + 1, Date = date, SumBody = S / n, SumPercent = Math.Round((A / 30) * step, 2) });
                date = date.Date.AddDays(step);
            }

            return items;
        }
    }
}