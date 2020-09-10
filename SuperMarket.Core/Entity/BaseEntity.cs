using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Core.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
   
        private Nullable<DateTime> _createdDate = DateTime.Now;
        public Nullable<DateTime> CreatedDate { get { return _createdDate; } set { _createdDate = value; } }

        private string _createdComputerName = Environment.MachineName;
        public string CreatedComputerName { get { return _createdComputerName; } set { _createdComputerName = value; } }
        
        public string CreatedIP { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIP { get; set; }
    }
}
