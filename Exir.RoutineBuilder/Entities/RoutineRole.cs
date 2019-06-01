using System;
using System.Collections.Generic;
using System.Text;

namespace Exir.RoutineBuilder.Entities
{
    public class RoutineRole
    {
        public int Id { get; set; }


        /// <summary>
        /// عنوان کارتابل
        /// مثل
        /// استاد
        /// دانشگاه
        /// دبیرخانه
        /// </summary>
        public string Title { get; set; }

        public string TitleEn { get; set; }

        /// <summary>
        /// مراحل کارتابل
        /// که به صورت
        /// JSON
        /// ذخیره خواهد شد
        /// و برای نمایش در «تازه‌ها» مورد استفاده قرار میگیرد
        /// مثلا
        /// ["200", "210", "220", "230"]
        /// </summary>
        public string StepsJson { get; set; }

        public int Order { get; set; }

        public virtual Routine Routine { get; set; }

        public int RoutineId { get; set; }

    }
}
