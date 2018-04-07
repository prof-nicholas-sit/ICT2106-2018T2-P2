using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.AppLogging
{
    public interface IAppLogIterator
    {
        AppLog First();
        AppLog Next();
        Boolean IsDone();
        AppLog CurrentItem();
    }
}
