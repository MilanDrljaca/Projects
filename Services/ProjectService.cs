using DataAccessLayer;
using DataAccessLayer.Repositories;
using DomainModel;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ProjectService : IProjectService
    {
        public Project Create(Project project)
        {
            ProjectRepo projectRepository = new ProjectRepo();
            projectRepository.Create(project);
            return project;
        }

        public Project GetProjectByID(int Id)
        {
            ProjectRepo projectRepository = new ProjectRepo();
            Project project = projectRepository.GetProjectById(Id);
            return project;
        }

        public Project GetProjectByProjectname(string ProjectName)
        {
            ProjectRepo projectRepository = new ProjectRepo();
            Project project = projectRepository.getProjectByProjectname(ProjectName);
            return project;
        }

        public List<Project> GetAllProjects()
        {
            ProjectRepo projectRepository = new ProjectRepo();
            List<Project> projects = projectRepository.GetAllProjects();
            return projects;
        }

        public void Delete(Project project)
        {
            ProjectRepo projectRepository = new ProjectRepo();
            projectRepository.Delete(project);
        }
    }
}