using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficMonitor.Common.Models.SeedWork
{
    public interface IClock
    {
        DateTime GetUtcNow();
        public static DateTime GetNow()=>DateTime.UtcNow;
    }
}
