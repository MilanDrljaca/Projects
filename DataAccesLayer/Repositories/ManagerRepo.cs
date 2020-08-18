using DataAccessLayer;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccesLayer.Repositories
{
    public class ManagerRepo
    {
        public List<Manager> GetAllManagers()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                List<Manager> managers = context.Managers.ToList();

                List<Manager> activeManagers = managers.Where(a => a.Active > 0).ToList();
                context.SaveChanges();
                return activeManagers;
            }
        }
        public Manager CreateManager(Manager manager)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Managers.Add(manager);
                context.SaveChanges();
                return manager;
            }
        }

        public Manager GetManagerByManagerName(string managerName)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Manager manager = context.Managers.Find(managerName);
                context.SaveChanges();
                return manager;
            }
        }

        public Manager DeactivateManager(string managerName)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Manager manager = context.Managers.First(a => a.ManagerName == managerName);
                manager.Active = 0;
                context.SaveChanges();
                return manager;
            }
        }
    }
}
