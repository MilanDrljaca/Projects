using System;
using System.Collections.Generic;
using System.Text;
using DomainModel;

namespace Services.Interfaces
{
    public interface IProjectService
    {
        public Project Create(Project project);
        public Project GetProjectByProjectname(string ProjectName);
        public Project GetProjectByID(int Id);
        public Project Update(Project project);
        public List<Project> GetAllProjects();
    }
}
