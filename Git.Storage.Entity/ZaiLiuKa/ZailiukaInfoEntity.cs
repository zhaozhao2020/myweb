/*******************************************************************************
 * Copyright (C) Git Corporation. All rights reserved.
 *
 * Author: 代码工具自动生成
 * Create Date: 2013-11-29 22:46:07
 * Blog: http://www.cnblogs.com/qingyuan/ 
 * Description: Git.Framework
 * 
 * Revision History:
 * Date         Author               Description
 * 2013-11-29 22:46:07
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Git.Framework.ORM;

namespace Git.Storage.Entity.ZaiLiuKa
{
    [TableAttribute(DbName = "JooWMS", Name = "ZailiukaInfo", IsInternal = false)]
    public partial class ZailiukaInfoEntity : BaseEntity
    {
        public ZailiukaInfoEntity()
        {   }

        [DataMapping(ColumnName = "ZaiLiuKaNo", DbType = DbType.String, Length = 12, CanNull = false, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public String ZaiLiuKaNo { get; set; }

        public ZailiukaInfoEntity IncludeZaiLiuKaNo(bool flag)
        {
            if (flag && !this.ColumnList.Contains("ZaiLiuKaNo"))
            {
                this.ColumnList.Add("ZaiLiuKaNo");
            }
            return this;
        }


        [DataMapping(ColumnName = "UserName", DbType = DbType.String, Length = 20, CanNull = false, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public string UserName { get; set; }

        public ZailiukaInfoEntity IncludeUserName(bool flag)
        {
            if (flag && !this.ColumnList.Contains("UserName"))
            {
                this.ColumnList.Add("UserName");
            }
            return this;
        }


        [DataMapping(ColumnName = "Sex", DbType = DbType.StringFixedLength, Length = 1, CanNull = false, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public string Sex { get; set; }

        public ZailiukaInfoEntity IncludeSex(bool flag)
        {
            if (flag && !this.ColumnList.Contains("Sex"))
            {
                this.ColumnList.Add("Sex");
            }
            return this;
        }


        [DataMapping(ColumnName = "Birthday", DbType = DbType.Date, CanNull = false, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public System.DateTime Birthday { get; set; }

        public ZailiukaInfoEntity IncludeBirthday(bool flag)
        {
            if (flag && !this.ColumnList.Contains("Birthday"))
            {
                this.ColumnList.Add("Birthday");
            }
            return this;
        }


        [DataMapping(ColumnName = "PermitDay", DbType = DbType.String, Length = 20, CanNull = false, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public string PermitDay { get; set; }

        public ZailiukaInfoEntity IncludePermitDay(bool flag)
        {
            if (flag && !this.ColumnList.Contains("PermitDay"))
            {
                this.ColumnList.Add("PermitDay");
            }
            return this;
        }


        [DataMapping(ColumnName = "Adress", DbType = DbType.String, Length = 20, CanNull = false, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public string Adress { get; set; }

        public ZailiukaInfoEntity IncludeAdress(bool flag)
        {
            if (flag && !this.ColumnList.Contains("Adress"))
            {
                this.ColumnList.Add("Adress");
            }
            return this;
        }


        [DataMapping(ColumnName = "UpdateTime", DbType = DbType.Date, CanNull = false, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public System.DateTime UpdateTime { get; set; }

        public ZailiukaInfoEntity IncludeUpdateTime(bool flag)
        {
            if (flag && !this.ColumnList.Contains("UpdateTime"))
            {
                this.ColumnList.Add("UpdateTime");
            }
            return this;
        }


        [DataMapping(ColumnName = "memo", DbType = DbType.String, Length = 50, CanNull = true, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public string Memo { get; set; }

        public ZailiukaInfoEntity IncludeMemo(bool flag)
        {
            if (flag && !this.ColumnList.Contains("memo"))
            {
                this.ColumnList.Add("memo");
            }
            return this;
        }

        [DataMapping(ColumnName = "flg", DbType = DbType.StringFixedLength, Length = 1, CanNull = false, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public string Flg { get; set; }

        public ZailiukaInfoEntity IncludeFlg(bool flag)
        {
            if (flag && !this.ColumnList.Contains("flg"))
            {
                this.ColumnList.Add("flg");
            }
            return this;
        }


    }
}
