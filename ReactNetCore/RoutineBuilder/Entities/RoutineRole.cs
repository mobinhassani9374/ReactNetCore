namespace ReactNetCore.RoutineBuilder.Entities
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



        /// <summary>
        /// Enum
        /// متناظر با داشبورد مرتبط با روال
        /// مثل
        /// Applicant
        /// Colleague
        /// University
        /// Secretariat
        /// </summary>
        public string DashboardEnum { get; set; }


        /// <summary>
        /// ترتیب کارتابل برای رسم مجدد دیاگرام
        /// </summary>
        public int SortOrder { get; set; }


        public int RoutineId { get; set; }

        public virtual Routine Routine { get; set; }
    }
}