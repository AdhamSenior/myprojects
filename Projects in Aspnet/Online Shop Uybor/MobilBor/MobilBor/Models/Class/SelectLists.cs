using MobilBor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilBor
{
    public class SelectLists
    {
        private static mobilborEntities db = new mobilborEntities();

        public static List<SelectListItem> Brands(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (lang == 1)
            {
                SelectList select = new SelectList(db.Brands, "ID", "BrandRu");
                list.Add(new SelectListItem { Text = "Выберите", Value = "" });
                list.AddRange(select);
            }
            if (lang == 2)
            {
                SelectList select = new SelectList(db.Brands, "ID", "BrandUzk");
                list.Add(new SelectListItem { Text = "Танланг", Value = "" });
                list.AddRange(select);
            }
            return list;
        }

        public static List<SelectListItem> Assignments(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (lang == 1)
            {
                SelectList select = new SelectList(db.Assignments, "ID", "assignmentNameRu");
                list.AddRange(select);
            }
            if (lang == 2)
            {
                SelectList select = new SelectList(db.Assignments, "ID", "assignmentName");
                list.AddRange(select);
            }
            return list;
        }

        public static List<SelectListItem> Faces(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (lang == 1)
            {
                SelectList select = new SelectList(db.Faces, "ID", "FaceRu");
                list.Add(new SelectListItem { Text = "Выберите", Value = "" });
                list.AddRange(select);
            }
            if (lang == 2)
            {
                SelectList select = new SelectList(db.Faces, "ID", "FaceUzk");
                list.Add(new SelectListItem { Text = "Танланг", Value = "" });
                list.AddRange(select);
            }
            return list;
        }

        public static List<SelectListItem> MoneyTypes(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (lang == 1)
            {
                SelectList select = new SelectList(db.MoneyTypes, "ID", "MoneyTypeRu");
                list.Add(new SelectListItem { Text = " ", Value = "" });
                list.AddRange(select);
            }
            if (lang == 2)
            {
                SelectList select = new SelectList(db.MoneyTypes, "ID", "MoneyTypeUzk");
                list.Add(new SelectListItem { Text = " ", Value = "" });
                list.AddRange(select);
            }
            return list;
        }


        public static List<SelectListItem> Prices(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (lang == 1)
            {
                SelectList select = new SelectList(db.Prices, "ID", "PriceRu");
                list.Add(new SelectListItem { Text = " ", Value = "" });
                list.AddRange(select);
            }
            if (lang == 2)
            {
                SelectList select = new SelectList(db.Prices, "ID", "PriceUzk");
                list.Add(new SelectListItem { Text = " ", Value = "" });
                list.AddRange(select);
            }
            return list;
        }

        public static List<SelectListItem> PriceTypes(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (lang == 1)
            {
                SelectList select = new SelectList(db.PriceTypes, "ID", "PriceTypeRu");
                list.Add(new SelectListItem { Text = "Выберите", Value = "" });
                list.AddRange(select);
            }
            if (lang == 2)
            {
                SelectList select = new SelectList(db.PriceTypes, "ID", "PriceTypeUzk");
                list.Add(new SelectListItem { Text = "Танланг", Value = "" });
                list.AddRange(select);
            }
            return list;
        }

        public static List<SelectListItem> States(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (lang == 1)
            {
                SelectList select = new SelectList(db.States, "ID", "StateRu");
                list.Add(new SelectListItem { Text = "Выберите", Value = "" });
                list.AddRange(select);
            }
            if (lang == 2)
            {
                SelectList select = new SelectList(db.States, "ID", "StateUzk");
                list.Add(new SelectListItem { Text = "Танланг", Value = "" });
                list.AddRange(select);
            }
            return list;
        }

        public static List<SelectListItem> Operations(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            //if (lang == 1)
            //{
                SelectList select = new SelectList(db.Operation_Types, "ID", "Name_Ru");
                list.AddRange(select);
            //}
            //if (lang == 2)
            //{
            //    SelectList select = new SelectList(db.Operation_Types, "ID", "Name_Uz");
            //    list.Add(new SelectListItem { Text = "Танланг", Value = "" });
            //    list.AddRange(select);
            //}
            return list;
        }

        public static List<SelectListItem> Property(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Property_Types, "ID", "Name_Ru");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> Area(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Areas, "ID", "Name_Ru");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> Zone(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Zones, "ID", "Name_Ru");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> Build(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Building_Type, "ID", "Name_Ru");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> State(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.State, "ID", "Name_Ru");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> Classification(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Classification_Type, "ID", "Name_Ru");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> Metro(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Metro, "ID", "Name_Ru");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> Contacts(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Contacts, "ID", "ContactRu");
            list.AddRange(select);
            return list;
        }

        public static List<SelectListItem> PriceType(int lang)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            SelectList select = new SelectList(db.Prices, "ID", "PriceRu");
            list.AddRange(select);
            return list;
        }

    }
}