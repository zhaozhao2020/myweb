using Git.Framework.Controller;
using Git.Framework.DataTypes.ExtensionMethods;
using Git.Framework.DataTypes;
using Git.Framework.ORM;
using Git.Framework.Json;
using Git.Storage.Web.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Git.Storage.Entity.ZaiLiuKa;
using Git.Storage.Provider.ZaiLiuKa;
using Git.Storage.Common;
using Git.Storage.Web.Lib.Filter;
using Git.Storage.Entity.Order;
using Git.Storage.Provider.Order;

namespace Git.Storage.Web.Areas.ZaiLiuKa.Controllers
{
    //enum Qualification { 技術・人文知識・国際業務 = 0, 留学, 定住者, 永住者, 家族滞在, 経営・管理 }
    //enum Motivation { 旅行する = 0, 留学する, 研修する, 仕事する, 投資貿易, 外交行政 }
    //enum Sex { 男 = 0, 女=1 }
    //Enum.GetName(typeof(Motivation), Convert.ToInt32(motivation))
    public class ZaiLiuKaController : MasterPage
    {

        ZaiLiuKaProvider zaiLiuKaProvider = new ZaiLiuKaProvider();
        
             
     
        public ActionResult Index()
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
            Dictionary<string, string> columnDic = new Dictionary<string, string>();

            if (zaiLiuKaNo.IsNotEmpty())
            {
                columnDic.Add("zaiLiuKaNo", zaiLiuKaNo);

            }
            if (userName.IsNotEmpty())
            {
                columnDic.Add("userName", userName);

            }
            if (sex.IsNotEmpty())
            {
                columnDic.Add("sex", sex);

            }
            if (birthday.IsNotEmpty())
            {
                columnDic.Add("birthday", birthday);
            }
            if (permitStart.IsNotEmpty())
            {
                columnDic.Add("permitStart", permitStart);

            }

            if (permitEnd.IsNotEmpty())
            {
                columnDic.Add("permitEnd", permitEnd);

            }

            if (adress.IsNotEmpty())
            {
                columnDic.Add("adress", adress);
            }
            if (qualification.IsNotEmpty())
            {
                columnDic.Add("qualification", qualification);
            }
            if (motivation.IsNotEmpty())
            {
                columnDic.Add("motivation", motivation);
            }

            List<ZailiukaDto> list = zaiLiuKaProvider.GetListByColumns(columnDic);
            ViewBag.List = list;


            return View();
        }



        public ActionResult Change(string zaiLiuKaNo)
        {
            //string zaiLiuKaNo = WebUtil.GetQueryStringValue<string>("zaiLiuKaNo");
            ZailiukaDto dto = zaiLiuKaProvider.SelectByNo(zaiLiuKaNo);
            //ViewBag.Dto = dto;
            return this.Json(dto);

        }

  
    //新規登録
        public ActionResult Register()
        {
            
            return View();
        }

        public ActionResult Edit(string zaiLiuKaNo, string userName, string birthday, string sex, string qualification, string adress, string motivation, string permitDay)
        {
            ZailiukaDto dto = new ZailiukaDto();           
            //string data = WebUtil.GetQueryStringValue<string>("json");
            dto.ZaiLiuKaNo = zaiLiuKaNo;
            dto.UserName = userName;
            dto.Birthday = birthday;
            dto.Sex = sex;
            dto.Qualification = qualification;
            dto.Adress = adress;
            dto.Motivation = motivation;
            dto.PermitDay = permitDay;
            
            //dto.ZaiLiuKaNo = WebUtil.GetQueryStringValue<string>("zaiLiuKaNo");
            //dto.UserName = WebUtil.GetQueryStringValue<string>("userName");
            //dto.Birthday = WebUtil.GetQueryStringValue<string>("birthday");
            //dto.Sex = WebUtil.GetQueryStringValue<string>("sex");
            //dto.Qualification = WebUtil.GetQueryStringValue<string>("qualification");
            //dto.Adress = WebUtil.GetQueryStringValue<string>("adress");
            //dto.Motivation = WebUtil.GetQueryStringValue<string>("motivation");
            //dto.PermitDay = WebUtil.GetQueryStringValue<string>("permitDay");
            ViewBag.Dto = dto;
            return View();
        }

   

       
    }
}
