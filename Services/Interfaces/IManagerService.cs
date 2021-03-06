﻿using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IManagerService
    {
        public List<Manager> GetAllManagers();
        public List<Manager> GetAllActiveManagers();
        public Manager CreateManager(Manager manager);
        public Manager GetManagerByManagerName(string managerName);
        public Manager GetManagerById(int id);
        public void Edit(Manager manager);
    }

}
