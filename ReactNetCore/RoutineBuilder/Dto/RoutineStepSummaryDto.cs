using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder.Dto
{
    public class RoutineStepSummaryDto
    {
        public int Id { get; set; }

        /// <summary>
        /// عنوان مرحله
        /// مثل
        /// در انتظار بررسی توسط دبیرخانه
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// شماره مرحله
        /// </summary>
        public int Step { get; set; }


        /// <summary>
        /// عملیات مختلف روال که در اثر آن طرح
        /// از یک مرحله به مرحله دیگر میرود
        /// این موارد برای هر روال متفاوت است و وابسته به
        /// ENUM
        /// همان روال می‌باشد
        /// </summary>
        public int? F1 { get; set; }
        public int? F2 { get; set; }
        public int? F3 { get; set; }
        public int? F4 { get; set; }
        public int? F5 { get; set; }
        public int? F6 { get; set; }
        public int? F7 { get; set; }


        public int RoutineId { get; set; }

        public virtual RoutineSummaryDto Routine { get; set; }
    }
}
