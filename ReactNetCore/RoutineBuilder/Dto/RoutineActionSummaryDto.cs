using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder.Dto
{
    public class RoutineActionSummaryDto
    {
        public int Id { get; set; }

        /// <summary>
        /// شماره مرحله
        /// </summary>
        public int Step { get; set; }


        /// <summary>
        /// عملیاتی که انجام شده است
        /// F1, ... F7
        /// </summary>
        public string Action { get; set; }


        /// <summary>
        /// عنوان عملیات نظیر ارسال یا تایید
        /// </summary>
        public string Title { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }



        public int RoutineId { get; set; }

        public virtual RoutineSummaryDto Routine { get; set; }
    }
}
