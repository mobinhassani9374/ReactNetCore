﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder.Dto
{
    public class RoutineSummaryDto
    {
        public int Id { get; set; }

        /// <summary>
        /// اسم روال
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// آیا این روال دارای کارتابل ایجاد درخواست است
        /// </summary>
        public bool HaveDashboardCreation { get; set; }

        /// <summary>
        ///  حالا که این روال دارای کارتابل ایجاد درخواست است نام کامپوننت یا url  چیست
        /// </summary>
        public string DashboardCreationComponentName { get; set; }

        /// <summary>
        /// نام داشبوردی که میخواهدی ایجاد درخواست کند
        /// </summary>
        public string DashboardCreationName { get; set; }

        /// <summary>
        /// عنوانی که داشبورد ایجاد درخواست میخواهد
        /// </summary>
        public string DashboardCreationTitle { get; set; }


        /// <summary>
        /// اسم جدول در دیتابیس
        /// </summary>
        public string TableName { get; set; }

        public virtual ICollection<RoutineRoleSummaryDto> Roles { get; set; }
    }
}
