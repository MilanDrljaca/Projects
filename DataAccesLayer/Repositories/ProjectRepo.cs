using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class ProjectRepo
    {

        public Project Create(Project project)

        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                /*  try
                 -- {*/
                context.Projects.Add(project);
                context.SaveChanges();
                return project;
                /* }

               catch (Exception ex)
               {
                   throw new RepositoryException("Communication with database failed. Unable to create User.", ex);
               }*/
            }
        }

        public Project Update(Project project)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                //try {
                context.Projects.Update(project);
                context.SaveChanges();
                return project;
                //}

                //catch (Exception ex)
                //{
                //    Console.WriteLine("Si normalan brate?");
                //        }
            }
        }

        public Project GetProjectById(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                Project project = context.Projects.Find(id);
                context.SaveChanges();
                return project;

            }
        }
        public Project getProjectByProjectname(string ProjectName)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {


                Project project = context.Projects.FirstOrDefault(m => m.ProjectName == ProjectName);

                context.SaveChanges();
                return project;

            }
        }

        public List<Project> GetAllProjects()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                List<Project> projects = context.Projects.ToList();
                context.SaveChanges();
                return projects;

            }

        }
        public bool DoesProjectExist(string ProjectName)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                return context.Projects.Any(m => m.ProjectName == ProjectName);

            }
        }

    }
}
