using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace RatesHandler
{
    public class CurRate
    {
        /// <summary>
        /// Закодированное строковое обозначение валюты
        /// Например: USD, EUR и т.д.
        /// </summary>
        public string CurCode;

        /// <summary>
        /// Курс
        /// </summary>
        public double Rate;
    }

    public class CurRates
    {
        public class ValCurs
        {
            [XmlElementAttribute("Valute")]
            public ValCursValute[] ValuteList;
        }

        public class ValCursValute
        {

            [XmlElementAttribute("CharCode")]
            public string CurCode;

            [XmlElementAttribute("Value")]
            public string Rate;
        }
        
        /// <summary>
        /// Получить список котировок ЦБ на дату
        /// </summary>
        /// <param name="DateFormat">Дата в формате dd.MM.yyyy</param>
        /// <returns>список котировок ЦБ</returns>
        public static List<CurRate> GetExchangeRates(string DateFormat)
        {
            if (string.IsNullOrEmpty(DateFormat))
                DateFormat = DateTime.Now.ToString("dd.MM.yyyy");
            List<CurRate> result = new List<CurRate>();
            XmlSerializer xs = new XmlSerializer(typeof(ValCurs));
            //http://www.cbr.ru/scripts/XML_daily.asp?date_req=21.08.2019
            XmlReader xr = new XmlTextReader(@"http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + DateFormat);
            foreach (ValCursValute valute in ((ValCurs)xs.Deserialize(xr)).ValuteList)
            {
                result.Add(new CurRate()
                {
                    CurCode = valute.CurCode,
                    Rate = Convert.ToDouble(valute.Rate)
                });
            }
            return result;
        }
    }
}
