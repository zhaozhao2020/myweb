using Git.Framework.Controller;
using Git.Storage.Entity.ZaiLiuKa;
using Git.Storage.Provider.ZaiLiuKa;
using Git.Storage.Web.Lib;
using Git.Framework.DataTypes;
using Git.Framework.DataTypes.ExtensionMethods;
using Git.Framework.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Git.Framework.Json;
using Git.Storage.Provider;
using Git.Storage.Common;
using System.Text;
using Git.Framework.Controller.Mvc;
using Git.Storage.Common.Excel;
using System.Data;
using Storage.Common;
using Git.Storage.Web.Lib.Filter;
using Git.Storage.Entity.Order;
using Git.Storage.Provider.Order;
using Git.Framework.Cache;
using Git.Storage.Provider.Base;

namespace Git.Storage.Web.Areas.ZaiLiuKa.Controllers
{
    public class ZaiLiuKaAjaxController : AjaxPage
    {
        ZaiLiuKaProvider zaiLiuKaProvider = new ZaiLiuKaProvider();

        [LoginAjaxFilter]
        public ActionResult Register()
        {
            string zaiLiuKaNo = WebUtil.GetFormValue<string>("zaiLiuKaNo", string.Empty);
            string userName = WebUtil.GetFormValue<string>("userName", string.Empty);
            string sex = WebUtil.GetFormValue<string>("sex", string.Empty);
            string birthday = WebUtil.GetFormValue<string>("birthday", string.Empty);
            string permitStart = WebUtil.GetFormValue<string>("permitStart", string.Empty);
            string permitEnd = WebUtil.GetFormValue<string>("permitEnd", string.Empty);
            string adress = WebUtil.GetFormValue<string>("adress", string.Empty);
            string qualification = WebUtil.GetFormValue<string>("qualification", string.Empty);
            string motivation = WebUtil.GetFormValue<string>("motivation", string.Empty);


            ZailiukaDto dto = new ZailiukaDto();
            dto.ZaiLiuKaNo = zaiLiuKaNo;
            dto.UserName = userName;
            dto.Sex = sex;//Enum.GetName(typeof(Sex), Convert.ToInt32(sex));
            dto.Birthday = birthday;
            dto.PermitDay = permitStart + "~" + permitEnd;
            dto.Adress = adress;
            dto.Qualification = qualification;
            dto.Motivation = motivation;

            int line = zaiLiuKaProvider.Add(dto);
            //ViewBag.ZaiLiuKa = dto;

            if (line > 0)
            {
                this.ReturnJson.AddProperty("add", "success");
            }

            return Content(this.ReturnJson.ToString());
        }


        [LoginAjaxFilter]
        public ActionResult Edit()
        {
            string zaiLiuKaNo = WebUtil.GetFormValue<string>("zaiLiuKaNo", string.Empty);
            string userName = WebUtil.GetFormValue<string>("userName", string.Empty);
            string sex = WebUtil.GetFormValue<string>("sex", string.Empty);
            string birthday = WebUtil.GetFormValue<string>("birthday", string.Empty);
            string permitStart = WebUtil.GetFormValue<string>("permitStart", string.Empty);
            string permitEnd = WebUtil.GetFormValue<string>("permitEnd", string.Empty);
            string adress = WebUtil.GetFormValue<string>("adress", string.Empty);
            string qualification = WebUtil.GetFormValue<string>("qualification", string.Empty);
            string motivation = WebUtil.GetFormValue<string>("motivation", string.Empty);



            ZailiukaDto dto = new ZailiukaDto();
            dto.ZaiLiuKaNo = zaiLiuKaNo;
            dto.UserName = userName;
            dto.Sex = sex;//Enum.GetName(typeof(Sex), Convert.ToInt32(sex));
            dto.Birthday = birthday;
            dto.PermitDay = permitStart + "~" + permitEnd;
            dto.Adress = adress;
            dto.Qualification = qualification;
            dto.Motivation = motivation;
            int line = zaiLiuKaProvider.Update(dto);
            if (line > 0)
            {
                this.ReturnJson.AddProperty("update", "success");
            }
            else
            {
                this.ReturnJson.AddProperty("update", "notExist");
            }

            return Content(this.ReturnJson.ToString());
        }


   



        [LoginAjaxFilter]
        public ActionResult Delete()
        {
            string zaiLiuKaNo = WebUtil.GetQueryStringValue<string>("zaiLiuKaNo");
            if (!zaiLiuKaNo.IsEmpty())
            {
                int line = zaiLiuKaProvider.Delete(zaiLiuKaNo);
                if (line > 0)
                {
                    this.ReturnJson.AddProperty("delete", "success");
                }
                else
                {
                    this.ReturnJson.AddProperty("delete", "error");
                }

            }
            return Content(this.ReturnJson.ToString());
        }


        [LoginAjaxFilter]
        public ActionResult BatchDel()
        {

            string list = WebUtil.GetQueryStringValue<string>("zaiLiuKaNo");
            int line = 0;
            string[] newList = list.Split(',');
            foreach (string t in newList)
            {
                line += zaiLiuKaProvider.Delete(t);
            }
            if (line > 0)
            {
                this.ReturnJson.AddProperty("delChecked", "success");
            }
            else
            {
                this.ReturnJson.AddProperty("delChecked", "error");
            }
            return Content(this.ReturnJson.ToString());

        }


        public ActionResult SearchBySex(string sex)
        {
           
                List<ZailiukaDto> list = zaiLiuKaProvider.SearchBySex(sex);

                return this.Json(list);

        }


         public ActionResult SearchAll()
        {
            List<ZailiukaDto> listAll = zaiLiuKaProvider.SearchAll();
            return this.Json(listAll);
        }

    }
}
        

