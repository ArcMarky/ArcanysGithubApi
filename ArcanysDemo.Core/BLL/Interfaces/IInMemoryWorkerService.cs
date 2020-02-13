using ArcanysDemo.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcanysDemo.Core.BLL.Interfaces
{
    public interface IInMemoryWorkerService
    {
        ResponseObject StoreDataInMemory(dynamic model, string cacheName);
        ResponseObject GetDataInMemory(string cacheName);
    }
}
