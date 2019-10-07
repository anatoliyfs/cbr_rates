using dbHanler;
using RatesHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace cbrHanler
{
    public partial class fCurHandler : Form
    {
        public fCurHandler()
        {
            InitializeComponent();
        }

        private void btnUpdCur_Click(object sender, EventArgs e)
        {
            //получаем курсы валют на выбранную дату
            List<CurRate> rates = CurRates.GetExchangeRates(dtGet.Value.Date.ToString("dd.MM.yyyy"));

            //получаем все валюты которые надо обновить
            var dtCurrency = new PD_Data().GetData("select валюта, кодвалюты from Валюты");

            //если нет записей с валютами, обновлять не будем
            if (dtCurrency.Rows.Count == 0)
            {
                lblUpdateCur.Text = "В БД нет информации о валютах";
                return;
            }

            //формируем sql строку для обновления
            StringBuilder sqlCommand = new StringBuilder(dtCurrency.Rows.Count);
            foreach (DataRow row in dtCurrency.Rows)
            {
                var cCode = "" + row["валюта"];
                sqlCommand.AppendFormat("if not Exists (select 1 from Курс where дата = '{0}' and валюта = '{1}') insert into Курс (дата, валюта, курс) values ('{0}', '{1}', {2}){3}", dtGet.Value.Date, cCode, rates.FindLast(s => s.CurCode == cCode).Rate.ToString().Replace(",", "."), Environment.NewLine);
            }

            //обновляем в бд
            if (new PD_Data().ExecCommand(sqlCommand.ToString()))
                lblUpdateCur.Text = "обновили";
            else
                lblUpdateCur.Text = "ошибка обновления";
        }

        private void btnGetCur_Click(object sender, EventArgs e)
        {
            var oRate = new PD_Data().ExecCommandWithResult(string.Format("select top 1 курс from Курс where дата = '{0}' and валюта = '{1}'", dtGet.Value.Date, curGet.Text));
            if (oRate == null)
                lblGetCur.Text = "Что-то пошло не так)";
            else
                lblGetCur.Text = "курс = " + oRate;
        }
    }
}
