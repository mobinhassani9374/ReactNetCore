using System;
using System.Collections.Generic;
using System.Text;

namespace Exir.RoutineBuilder.Entities
{
    public class RoutineLog
    {
        public int Id { get; set; }


        /// <summary>
        /// شماره منحصر به فرد طرح
        /// </summary>
        public int EntityId { get; set; }


        /// <summary>
        /// کاربر
        /// </summary>
        public int UserId { get; set; }


        /// <summary>
        /// تاریخ انجام عملیات
        /// </summary>
        public DateTime ActionDate { get; set; }


        /// <summary>
        /// شماره مرحله فعلی که عملیات بر روی آن انجام شده است
        /// مثلا وقتی استاد طرحی را از مرحله ۱ ارسال میکند و به مرحله ۲۰۰ میرود
        /// شماره مرحله ۱ در این فیلد قرار میگیرد
        /// </summary>
        public int Step { get; set; }

        /// <summary>
        /// شماره مرحله نهایی که طرح پس از انجام عملیات به آن مرحله می‌رود
        /// مثلا وقتی استاد طرحی را از مرحله ۱ ارسال میکند و به مرحله ۲۰۰ میرود
        /// شماره مرحله ۲۰۰ در این فیلد قرار میگیرد
        /// </summary>
        public int? ToStep { get; set; }


        /// <summary>
        /// توضیح در صورت وجود
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// عملیاتی که انجام شده است
        /// F1, F2, F3, F4, F5, F6, F7
        /// </summary>
        public string Action { get; set; }


        /// <summary>
        /// مقدار فیلد
        /// Routine2Role.DashboardEnum
        /// که کارتابل فعلی را در برمیگیرد
        /// یکسری موارد پیش فرض هم داریم که وابسته به آن جدول ‌می‌تواند نباشد
        /// که در
        /// Routine2Roles.PredefinedDashboardsSSOT
        /// ذخیره می‌شود
        /// نظیر
        /// _Moderator
        /// که می‌شود مدیر ارشد سیستم
        /// </summary>
        public string RoutineRoleTitle { get; set; }

        public virtual Routine Routine { get; set; }

        public int RoutineId { get; set; }
    }
}
