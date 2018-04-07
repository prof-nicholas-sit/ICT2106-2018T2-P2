using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.AppLogging
{
    public class AppLogIterator : IAppLogIterator
    {
        private List<AppLog> _listOfLogs;
        private int _current = 0;

        public AppLogIterator(List<AppLog> listOfLogs)
        {
            this._listOfLogs = listOfLogs;
        }

        public AppLog First()
        {
            return _listOfLogs[0];
        }

        public AppLog Last()
        {
            return _listOfLogs.Last();
        }

        public AppLog Next()
        {
            AppLog ret = null;
            if (_current < _listOfLogs.Count - 1)
            {
                ret = _listOfLogs[++_current];
            }

            return ret;
        }

        public AppLog CurrentItem()
        {
            return _listOfLogs[_current];
        }

        public bool IsDone()
        {
            return _current >= _listOfLogs.Count;
        }
    }
}
