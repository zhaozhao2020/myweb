/*******************************************************************************
 * Copyright (C) Git Corporation. All rights reserved.
 *
 * Author: 情缘
 * Create Date: 2014-01-01 14:56:42
 *
 * Description: Git.Framework
 * http://www.cnblogs.com/qingyuan/
 * Revision History:
 * Date         Author               Description
 * 2014-01-01 14:56:42       情缘
*********************************************************************************/

using Git.Framework.Log;
using Git.Framework.DataTypes;
using Git.Framework.DataTypes.ExtensionMethods;
using Git.Framework.ORM;
using Git.Storage.Entity.ZaiLiuKa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Git.Framework.Cache;
using Git.Storage.Common;
using System.Transactions;
using Git.Storage.Entity.Procedure;
using Git.Storage.Entity.Order;

namespace Git.Storage.Provider.ZaiLiuKa
{
    enum Qualification { 技術・人文知識・国際業務 = 0, 留学, 定住者, 永住者, 家族滞在, 経営・管理 }
    enum Motivation { 旅行する = 0, 留学する, 研修する, 仕事する, 投資貿易, 外交行政 }
    enum Sex { 男 = 0, 女 }
    public partial class ZaiLiuKaProvider : DataFactory
    {
        private Log log = Log.Instance(typeof(ZaiLiuKaProvider));

        public ZaiLiuKaProvider() { }

        public int Add(ZailiukaDto dto)
        {

            ZailiukaInfoEntity zaiLiuKaInfoEntity = new ZailiukaInfoEntity();
            QualificationEntity qualificationEntity = new QualificationEntity();
            MotivationEntity motivationEntity = new MotivationEntity();
            zaiLiuKaInfoEntity.IncludeAll();
            qualificationEntity.IncludeAll();
            motivationEntity.IncludeAll();


            zaiLiuKaInfoEntity.ZaiLiuKaNo = dto.ZaiLiuKaNo;
            qualificationEntity.ZaiLiuKaNo = dto.ZaiLiuKaNo;
            motivationEntity.ZaiLiuKaNo = dto.ZaiLiuKaNo;

            zaiLiuKaInfoEntity.UserName = dto.UserName;

            zaiLiuKaInfoEntity.Sex = dto.Sex;
            zaiLiuKaInfoEntity.Birthday = Convert.ToDateTime(dto.Birthday);
            zaiLiuKaInfoEntity.PermitDay = dto.PermitDay;
            zaiLiuKaInfoEntity.Adress = dto.Adress;
            zaiLiuKaInfoEntity.UpdateTime = DateTime.Now;
            zaiLiuKaInfoEntity.Flg = "1";



            qualificationEntity.Type = dto.Qualification;
            qualificationEntity.UpdateTime = DateTime.Now;
            qualificationEntity.Memo = "無し";
            qualificationEntity.Flg = "1";


            motivationEntity.Type = dto.Motivation;
            motivationEntity.UpdateTime = DateTime.Now;
            motivationEntity.Memo = "無し";
            motivationEntity.Flg = "1";

            //DTO to entity
            this.ZailiukaInfo.Add(zaiLiuKaInfoEntity);
            this.Qualification.Add(qualificationEntity);
            int line = this.Motivation.Add(motivationEntity);

            return line;
        }

        public int Update(ZailiukaDto dto)
        {
            ZailiukaInfoEntity zaiLiuKaInfoEntity = new ZailiukaInfoEntity();
            QualificationEntity qualificationEntity = new QualificationEntity();
            MotivationEntity motivationEntity = new MotivationEntity();
            zaiLiuKaInfoEntity.IncludeAll();
            qualificationEntity.IncludeAll();
            motivationEntity.IncludeAll();


            zaiLiuKaInfoEntity.ZaiLiuKaNo = dto.ZaiLiuKaNo;
            qualificationEntity.ZaiLiuKaNo = dto.ZaiLiuKaNo;
            motivationEntity.ZaiLiuKaNo = dto.ZaiLiuKaNo;

            zaiLiuKaInfoEntity.UserName = dto.UserName;

            zaiLiuKaInfoEntity.Sex = dto.Sex;
            zaiLiuKaInfoEntity.Birthday = Convert.ToDateTime(dto.Birthday);
            zaiLiuKaInfoEntity.PermitDay = dto.PermitDay;
            zaiLiuKaInfoEntity.Adress = dto.Adress;
            zaiLiuKaInfoEntity.UpdateTime = DateTime.Now;
            zaiLiuKaInfoEntity.Flg = "1";



            qualificationEntity.Type = dto.Qualification;
            qualificationEntity.UpdateTime = DateTime.Now;
            qualificationEntity.Memo = "無し";
            qualificationEntity.Flg = "1";


            motivationEntity.Type = dto.Motivation;
            motivationEntity.UpdateTime = DateTime.Now;
            motivationEntity.Memo = "無し";
            motivationEntity.Flg = "1";
            zaiLiuKaInfoEntity.Include(a => new { a.ZaiLiuKaNo, a.UserName, a.Sex, a.Birthday, a.PermitDay, a.Adress, a.UpdateTime, a.Memo, a.Flg });
            zaiLiuKaInfoEntity.Where(a => a.ZaiLiuKaNo == dto.ZaiLiuKaNo);
            this.ZailiukaInfo.Update(zaiLiuKaInfoEntity);

            qualificationEntity.Include(a => new { a.ZaiLiuKaNo, a.Type, a.Memo, a.Flg });
            qualificationEntity.Where(a => a.ZaiLiuKaNo == dto.ZaiLiuKaNo);
            this.Qualification.Update(qualificationEntity);

            motivationEntity.Include(a => new { a.ZaiLiuKaNo, a.Type, a.Memo, a.Flg });
            motivationEntity.Where(a => a.ZaiLiuKaNo == dto.ZaiLiuKaNo);
            int line = this.Motivation.Update(motivationEntity);

            return line;
        }


        public List<ZailiukaDto> SearchBySex(string sex)
        {
            ZailiukaInfoEntity zaiLiuKaInfoEntity = new ZailiukaInfoEntity();
            QualificationEntity qualificationEntity = new QualificationEntity();
            MotivationEntity motivationEntity = new MotivationEntity();
            zaiLiuKaInfoEntity.IncludeAll();
            qualificationEntity.IncludeAll();
            motivationEntity.IncludeAll();

            List<ZailiukaDto> dtoList = new List<ZailiukaDto>();
            List<ZailiukaInfoEntity> zaiLiuKaList = this.ZailiukaInfo.GetList();
            List<QualificationEntity> qualificationList = this.Qualification.GetList();
            List<MotivationEntity> motivationList = this.Motivation.GetList();

            List<ZailiukaInfoEntity> sexList = new List<ZailiukaInfoEntity>();
            foreach (ZailiukaInfoEntity zEntity in zaiLiuKaList)
            {
                if (zEntity.Sex == sex)
                {
                    sexList.Add(zEntity);
                }
            }

            foreach (ZailiukaInfoEntity infoEntity in sexList)
            {
                
                ZailiukaDto dto = new ZailiukaDto();
                if (infoEntity.Flg == "1")
                {
                    dto.ZaiLiuKaNo = infoEntity.ZaiLiuKaNo;
                    dto.UserName = infoEntity.UserName;
                    dto.Sex = Enum.GetName(typeof(Sex), Convert.ToInt32(infoEntity.Sex));
                    dto.Birthday = infoEntity.Birthday.ToString();
                    dto.PermitDay = infoEntity.PermitDay;
                    dto.Adress = infoEntity.Adress;



                    foreach (QualificationEntity qEntity in qualificationList)
                    {
                        if (qEntity.ZaiLiuKaNo == dto.ZaiLiuKaNo)
                        {
                            dto.Qualification = Enum.GetName(typeof(Qualification), Convert.ToInt32(qEntity.Type));
                        }
                    }

                    foreach (MotivationEntity mEntity in motivationList)
                    {
                        if (mEntity.ZaiLiuKaNo == dto.ZaiLiuKaNo)
                        {
                            
                            if (mEntity.Type.Contains(','))
                            {
                                string[] moti = mEntity.Type.Split(',');
                                foreach (string m in moti)
                                {
                                    dto.Motivation = "";
                                    dto.Motivation += Enum.GetName(typeof(Motivation), Convert.ToInt32(m)) + ",";
                                }

                                dto.Motivation = dto.Motivation.Substring(0, dto.Motivation.Length - 1);
                            }
                            else
                            {
                                dto.Motivation = Enum.GetName(typeof(Motivation), Convert.ToInt32(mEntity.Type));
                            }

                        }
                    }
                    dtoList.Add(dto);
                }

                
            }

            if (!dtoList.ToString().IsEmpty())
            {
                return dtoList;
            }
            else
            {
                return null;
            }
            
 
        }


        public List<ZailiukaDto> SearchAll()
        {
            ZailiukaInfoEntity zaiLiuKaInfoEntity = new ZailiukaInfoEntity();
            QualificationEntity qualificationEntity = new QualificationEntity();
            MotivationEntity motivationEntity = new MotivationEntity();
            zaiLiuKaInfoEntity.IncludeAll();
            qualificationEntity.IncludeAll();
            motivationEntity.IncludeAll();

            List<ZailiukaDto> dtoList = new List<ZailiukaDto>();
            List<ZailiukaInfoEntity> zaiLiuKaList = this.ZailiukaInfo.GetList();
            List<QualificationEntity> qualificationList = this.Qualification.GetList();
            List<MotivationEntity> motivationList = this.Motivation.GetList();

           // List<ZailiukaInfoEntity> allList = new List<ZailiukaInfoEntity>();
           
            foreach (ZailiukaInfoEntity zEntity in zaiLiuKaList)
            {
                          
                ZailiukaDto dto = new ZailiukaDto();
                if (zEntity.Flg == "1")
                {
                    dto.ZaiLiuKaNo = zEntity.ZaiLiuKaNo;
                    dto.UserName = zEntity.UserName;
                    dto.Sex = Enum.GetName(typeof(Sex), Convert.ToInt32(zEntity.Sex));
                    dto.Birthday = zEntity.Birthday.ToString();
                    dto.PermitDay = zEntity.PermitDay;
                    dto.Adress = zEntity.Adress;



                    foreach (QualificationEntity qEntity in qualificationList)
                    {
                        if (qEntity.ZaiLiuKaNo == dto.ZaiLiuKaNo)
                        {
                            dto.Qualification = Enum.GetName(typeof(Qualification), Convert.ToInt32(qEntity.Type));
                        }
                    }

                    foreach (MotivationEntity mEntity in motivationList)
                    {
                        if (mEntity.ZaiLiuKaNo == dto.ZaiLiuKaNo)
                        {
                           
                            if (mEntity.Type.Contains(',')) 
                            {
                                string[] moti = mEntity.Type.Split(',');
                                foreach (string m in moti)
                                {
                                    dto.Motivation = "";
                                    dto.Motivation += Enum.GetName(typeof(Motivation), Convert.ToInt32(m)) + ",";
                                }

                                dto.Motivation = dto.Motivation.Substring(0, dto.Motivation.Length - 1);
                            }
                            else
                            {
                                dto.Motivation = Enum.GetName(typeof(Motivation), Convert.ToInt32(mEntity.Type));
                            }
                            
                        }
                    }

                    dtoList.Add(dto); 
                }
                
            }

            if (!dtoList.ToString().IsEmpty())
            {
                return dtoList;
            }
            else
            {
                return null;
            }
            

        }



        public List<ZailiukaDto> GetListByColumns(Dictionary<string, string> columnDic)
        {
            ZailiukaInfoEntity zaiLiuKaInfoEntity = new ZailiukaInfoEntity();
            QualificationEntity qualificationEntity = new QualificationEntity();
            MotivationEntity motivationEntity = new MotivationEntity();
            zaiLiuKaInfoEntity.IncludeAll();
            qualificationEntity.IncludeAll();
            motivationEntity.IncludeAll();


            List<ZailiukaDto> dtoList = new List<ZailiukaDto>();

            //zaiLiuKaInfoEntity.Include(a => new { a.ZaiLiuKaNo, a.UserName, a.Sex, a.Birthday, a.PermitDay, a.Adress, a.UpdateTime, a.Memo, a.Flg });
            //qualificationEntity.Include(a => new { a.ZaiLiuKaNo, a.Type, a.UpdateTime, a.Memo, a.Flg });
            //motivationEntity.Include(a => new { a.ZaiLiuKaNo, a.Type, a.UpdateTime, a.Memo, a.Flg });

            List<ZailiukaInfoEntity> zaiLiuKaList = this.ZailiukaInfo.GetList();
            List<QualificationEntity> qualificationList = this.Qualification.GetList();
            List<MotivationEntity> motivationList = this.Motivation.GetList();

            //zaiLiuKaInfoEntity.Inner<QualificationEntity>(qualificationEntity, new Params<string, string>() { Item1 = "ZaiLiuKaNo", Item2 = "Type"  });
            //zaiLiuKaInfoEntity.Inner<MotivationEntity>(motivationEntity, new Params<string, string>() { Item1 = "ZaiLiuKaNo", Item2 = "Type" });
            if (columnDic.ContainsKey("sex"))
            {
                List<ZailiukaInfoEntity> sexList = new List<ZailiukaInfoEntity>();
                foreach (ZailiukaInfoEntity zEntity in zaiLiuKaList)
                {
                    if (zEntity.Sex == columnDic["sex"])
                    {
                        sexList.Add(zEntity);
                    }
                }

                foreach (ZailiukaInfoEntity infoEntity in sexList)
                {
                    ZailiukaDto dto = new ZailiukaDto();
                    if (infoEntity.Flg == "1")
                    {
                        dto.ZaiLiuKaNo = infoEntity.ZaiLiuKaNo;
                        dto.UserName = infoEntity.UserName;
                        dto.Sex = Enum.GetName(typeof(Sex), Convert.ToInt32(infoEntity.Sex));
                        dto.Birthday = infoEntity.Birthday.ToString();
                        dto.PermitDay = infoEntity.PermitDay;
                        dto.Adress = infoEntity.Adress;



                        foreach (QualificationEntity qEntity in qualificationList)
                        {
                            if (qEntity.ZaiLiuKaNo == dto.ZaiLiuKaNo)
                            {
                                dto.Qualification = Enum.GetName(typeof(Qualification), Convert.ToInt32(qEntity.Type));
                            }
                        }

                        foreach (MotivationEntity mEntity in motivationList)
                        {
                            if (mEntity.ZaiLiuKaNo == dto.ZaiLiuKaNo)
                            {
                                
                                if (mEntity.Type.Contains(','))
                                {
                                    string[] moti = mEntity.Type.Split(',');
                                    foreach (string m in moti)
                                    {
                                        dto.Motivation = "";
                                        dto.Motivation += Enum.GetName(typeof(Motivation), Convert.ToInt32(m)) + ",";
                                    }

                                    dto.Motivation = dto.Motivation.Substring(0, dto.Motivation.Length - 1);
                                }
                                else
                                {
                                    dto.Motivation = Enum.GetName(typeof(Motivation), Convert.ToInt32(mEntity.Type));
                                }

                            }
                        }

                        dtoList.Add(dto);
                    }

                   
                }

                if (!dtoList.ToString().IsEmpty())
                {
                    return dtoList;
                }
                else
                {
                    return null;
                }


            }


            if (columnDic.ContainsKey("userName"))
            {
                List<ZailiukaInfoEntity> nameList = new List<ZailiukaInfoEntity>();
                foreach (ZailiukaInfoEntity zEntity in zaiLiuKaList)
                {
                    if (zEntity.UserName == columnDic["userName"])
                    {
                        nameList.Add(zEntity);
                    }
                }

                foreach (ZailiukaInfoEntity infoEntity in nameList)
                {
                    ZailiukaDto dto = new ZailiukaDto();
                    if (infoEntity.Flg == "1")
                    {
                        dto.ZaiLiuKaNo = infoEntity.ZaiLiuKaNo;
                        dto.UserName = infoEntity.UserName;
                        dto.Sex = Enum.GetName(typeof(Sex), Convert.ToInt32(infoEntity.Sex));
                        dto.Birthday = infoEntity.Birthday.ToString();
                        dto.PermitDay = infoEntity.PermitDay;
                        dto.Adress = infoEntity.Adress;




                        foreach (QualificationEntity qEntity in qualificationList)
                        {
                            if (qEntity.ZaiLiuKaNo == dto.ZaiLiuKaNo)
                            {
                                dto.Qualification = Enum.GetName(typeof(Qualification), Convert.ToInt32(qEntity.Type));
                            }
                        }

                        foreach (MotivationEntity mEntity in motivationList)
                        {
                            if (mEntity.ZaiLiuKaNo == dto.ZaiLiuKaNo)
                            {
                               
                                if (mEntity.Type.Contains(','))
                                {
                                    string[] moti = mEntity.Type.Split(',');
                                    foreach (string m in moti)
                                    {
                                        dto.Motivation = "";
                                        dto.Motivation += Enum.GetName(typeof(Motivation), Convert.ToInt32(m)) + ",";
                                    }

                                    dto.Motivation = dto.Motivation.Substring(0, dto.Motivation.Length - 1);
                                }
                                else
                                {
                                    dto.Motivation = Enum.GetName(typeof(Motivation), Convert.ToInt32(mEntity.Type));
                                }

                            }
                        }

                        dtoList.Add(dto);
                    }
                }


            }


            if (!dtoList.ToString().IsEmpty())
            {
                return dtoList;
            }
            else
            {
                return null;
            }

        }


        public ZailiukaDto SelectByNo(string zaiLiuKaNo)
        {
            ZailiukaInfoEntity zaiLiuKaInfoEntity = new ZailiukaInfoEntity();
            QualificationEntity qualificationEntity = new QualificationEntity();
            MotivationEntity motivationEntity = new MotivationEntity();
            zaiLiuKaInfoEntity.IncludeAll();
            qualificationEntity.IncludeAll();
            motivationEntity.IncludeAll();

            zaiLiuKaInfoEntity.Where(a => a.ZaiLiuKaNo == zaiLiuKaNo);
            zaiLiuKaInfoEntity = this.ZailiukaInfo.GetSingle(zaiLiuKaInfoEntity);

            if (zaiLiuKaInfoEntity.Flg == "1")
            {
                qualificationEntity.Where(a => a.ZaiLiuKaNo == zaiLiuKaNo);
                qualificationEntity = this.Qualification.GetSingle(qualificationEntity);

                motivationEntity.Where(a => a.ZaiLiuKaNo == zaiLiuKaNo);
                motivationEntity = this.Motivation.GetSingle(motivationEntity);

                ZailiukaDto dto = new ZailiukaDto();
                dto.ZaiLiuKaNo = zaiLiuKaInfoEntity.ZaiLiuKaNo;
                dto.UserName = zaiLiuKaInfoEntity.UserName;
                dto.Birthday = zaiLiuKaInfoEntity.Birthday.ToString();
                dto.Sex = zaiLiuKaInfoEntity.Sex;
                dto.Qualification = qualificationEntity.Type;
                dto.Adress = zaiLiuKaInfoEntity.Adress;
                dto.Motivation = motivationEntity.Type;
                dto.PermitDay = zaiLiuKaInfoEntity.PermitDay;

                 return dto;

            }
           
            else
            {
                return null;
            }
            

        }

        public int Delete(string zaiLiuKaNo)
        {
            ZailiukaInfoEntity zaiLiuKaInfoEntity = new ZailiukaInfoEntity();
            QualificationEntity qualificationEntity = new QualificationEntity();
            MotivationEntity motivationEntity = new MotivationEntity();
            zaiLiuKaInfoEntity.IncludeAll();
            qualificationEntity.IncludeAll();
            motivationEntity.IncludeAll();

            zaiLiuKaInfoEntity.Where(a => a.ZaiLiuKaNo == zaiLiuKaNo);
            zaiLiuKaInfoEntity = this.ZailiukaInfo.GetSingle(zaiLiuKaInfoEntity);

            //zaiLiuKaInfoEntity.IncludeFlg(true);
            zaiLiuKaInfoEntity.Flg = "0";
            zaiLiuKaInfoEntity.Include(a => new { a.ZaiLiuKaNo, a.UserName, a.Sex, a.Birthday, a.PermitDay, a.Adress, a.UpdateTime, a.Memo, a.Flg });
            zaiLiuKaInfoEntity.Where(a => a.ZaiLiuKaNo == zaiLiuKaNo);
            this.ZailiukaInfo.Update(zaiLiuKaInfoEntity);


            qualificationEntity.Where(a => a.ZaiLiuKaNo == zaiLiuKaNo);
            qualificationEntity = this.Qualification.GetSingle(qualificationEntity);
            //qualificationEntity.IncludeFlg(true);
            qualificationEntity.Flg = "0";
            qualificationEntity.Include(a => new { a.ZaiLiuKaNo, a.Type, a.Memo, a.Flg });
            qualificationEntity.Where(a => a.ZaiLiuKaNo == zaiLiuKaNo);
            this.Qualification.Update(qualificationEntity);


            motivationEntity.Where(a => a.ZaiLiuKaNo == zaiLiuKaNo);
            motivationEntity = this.Motivation.GetSingle(motivationEntity);
            //motivationEntity.IncludeFlg(true);
            motivationEntity.Flg = "0";
            motivationEntity.Include(a => new { a.ZaiLiuKaNo, a.Type, a.Memo, a.Flg });
            motivationEntity.Where(a => a.ZaiLiuKaNo == zaiLiuKaNo);
            int line = this.Motivation.Update(motivationEntity);

            return line;
        }


    }
}

