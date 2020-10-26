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
    [TableAttribute(DbName = "JooWMS", Name = "Qualification", IsInternal = false)]
    public partial class QualificationEntity : BaseEntity
    {
        public QualificationEntity()
        {   }
        

        [DataMapping(ColumnName = "ZaiLiuKaNo", DbType = DbType.String, Length = 12, CanNull = false, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public String ZaiLiuKaNo { get; set; }

        public QualificationEntity IncludeZaiLiuKaNo(bool flag)
        {
            if (flag && !this.ColumnList.Contains("ZaiLiuKaNo"))
            {
                this.ColumnList.Add("ZaiLiuKaNo");
            }
            return this;
        }



        [DataMapping(ColumnName = "Type", DbType = DbType.StringFixedLength, Length = 1, CanNull = false, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public string Type { get; set; }

        public QualificationEntity IncludeType(bool flag)
        {
            if (flag && !this.ColumnList.Contains("Type"))
            {
                this.ColumnList.Add("Type");
            }
            return this;
        }



        [DataMapping(ColumnName = "UpdateTime", DbType = DbType.Date, CanNull = false, DefaultValue = null,  AutoIncrement = false, IsMap = true)]
        public System.DateTime UpdateTime { get; set; }

        public QualificationEntity IncludeUpdateTime(bool flag)
        {
            if (flag && !this.ColumnList.Contains("UpdateTime"))
            {
                this.ColumnList.Add("UpdateTime");
            }
            return this;
        }


       
        [DataMapping(ColumnName = "memo", DbType = DbType.String, Length = 50, CanNull = true, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public string Memo { get; set; }

        public QualificationEntity IncludeMemo(bool flag)
        {
            if (flag && !this.ColumnList.Contains("memo"))
            {
                this.ColumnList.Add("memo");
            }
            return this;
        }



        [DataMapping(ColumnName = "flg", DbType = DbType.StringFixedLength, Length = 1, CanNull = false, DefaultValue = null, AutoIncrement = false, IsMap = true)]
        public string Flg { get; set; }

        public QualificationEntity IncludeFlg(bool flag)
        {
            if (flag && !this.ColumnList.Contains("flg"))
            {
                this.ColumnList.Add("flg");
            }
            return this;
        }


    }
}
