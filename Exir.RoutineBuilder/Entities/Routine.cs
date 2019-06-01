using System;
using System.Collections.Generic;
using System.Text;

namespace Exir.RoutineBuilder.Entities
{
    public class Routine
    {
        public int Id { get; set; }

        /// <summary>
        /// اسم روال
        /// </summary>
        public string Title { get; set; }

        public string ControllerName { get; set; }


        public virtual ICollection<RoutineAction> Actions { get; set; }

        public virtual ICollection<RoutineField> Fields { get; set; }

        public virtual ICollection<RoutineLog> Logs { get; set; }

        public virtual ICollection<RoutineRole> Roles { get; set; }

        public virtual ICollection<RoutineStep> Steps { get; set; }

        public virtual ICollection<RoutineCustomAction> CustomActions { get; set; }
    }
}
