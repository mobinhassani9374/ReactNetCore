using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.RoutineBuilder.Entities
{
    public class Routine
    {
        public int Id { get; set; }

        /// <summary>
        /// اسم روال
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// اسم جدول در دیتابیس
        /// </summary>
        public string TableName { get; set; }

        public virtual ICollection<RoutineRole> Roles { get; set; }

        public virtual ICollection<RoutineStep> Steps { get; set; }

        public virtual ICollection<RoutineAction> Actions { get; set; }

        public virtual ICollection<RoutineLog> Logs { get; set; }
    }
}
