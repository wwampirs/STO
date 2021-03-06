﻿using STO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IRepository<T> Repository<T>() where T : class, IEntity;
        void Save();
        Task SaveAsync();        
    }
}
