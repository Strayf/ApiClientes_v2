using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Helper
{
    public class Notification
    {
        private List<string> Errors = new List<string>();

        public string ListErrors()
        {
            return string.Join("; ", Errors);
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public bool HasErrors()
        {
            if (Errors.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
