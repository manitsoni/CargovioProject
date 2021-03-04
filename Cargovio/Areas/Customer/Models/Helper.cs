using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
namespace Cargovio.Areas.Customer.Models
{
    public class Helper
    {
        CargovioDbEntities db = new CargovioDbEntities();
        private static Random random = new Random();
        public string GetShipmentNumber()
        {
            string ShipmentId = "";

            var ShipmentIdList = db.tblBookings.ToList();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            string str = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());

            string ShipMentNumber = "CRGVO" + str + DateTime.Now.Year;

            foreach (var item in ShipmentIdList)
            {
                if (item.ShipmentId == ShipMentNumber)
                {
                    const string chars1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                    string str1 = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());

                    string ShipMentNumber1 = "CRGVO" + str + DateTime.Now.Year;
                    ShipmentId = ShipMentNumber1;
                    break;
                }
            }
            ShipmentId = ShipMentNumber;
            return ShipmentId;
        }
    }
}