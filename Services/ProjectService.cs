using DataAccessLayer;
//using DataAccessLayer.Custom_Exceptions;
using DataAccessLayer.Repositories;
using DomainModel;
//using Services.CustomExceptions;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ProjectService: IProjectService
    {
        public Project Create(Project project)
        {
            //try { 
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                ProjectRepo projectRepository = new ProjectRepo();

                projectRepository.Create(project);
                context.SaveChanges();
                return project;


            }


                //}

                //catch (ValidationServiceException)
                //{
                //    throw;
                //}
                //catch (RepositoryException)
                //{
                //    throw;
                //}
                //catch (Exception ex)
                //{
                //    throw new ServiceException("User with this Username = " + user.UserName + ", already exists in database.", ex);
                //}
            }

            public Project GetProjectByID(int Id)
        {
            throw new NotImplementedException();

        }

        public Project GetProjectByProjectname(string ProjectName)
        {
            ProjectRepo projectRepository = new ProjectRepo();
            Project project = projectRepository.getProjectByProjectname(ProjectName);
            return project;

        }

        public Project Update(Project project)
        {
            //try
            //{
                ProjectRepo projectRepository = new ProjectRepo();
                projectRepository.Update(project);
                return project;
            //}
            //catch (Exception ex)
            //{
            //    throw new RepositoryException("Communication with database failed. Unable to find User " + user.UserName + ". ", ex);
            //}


        }
        public List<Project> GetAllProjects()
        {
            ProjectRepo projectRepository = new ProjectRepo();
            List<Project> projects = projectRepository.GetAllProjects();
            return projects;
        }


    }
}
