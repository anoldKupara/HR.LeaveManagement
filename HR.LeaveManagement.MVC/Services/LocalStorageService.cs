﻿using Hanssens.Net;
using HR.LeaveManagement.MVC.Contracts;
using System.Collections.Generic;

namespace HR.LeaveManagement.MVC.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private LocalStorage _localStorage;
        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "HR.LeaveManagement"
            };
            _localStorage = new LocalStorage(config);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                _localStorage.Remove(key);
            }
        }

        public void SetStorageValue<T>(string key, T value)
        {
            _localStorage.Store(key, value);
            _localStorage.Persist();
        }

        public T GetStorageValue<T>(string key)
        {
            return _localStorage.Get<T>(key);
        }

        public bool Exists(string key)
        {
            return _localStorage.Exists(key);
        }
    }
}
