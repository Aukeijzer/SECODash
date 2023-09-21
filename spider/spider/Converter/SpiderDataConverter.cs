﻿using SECODashBackend.Models;
using spider.Models;

namespace spider.Converter;

public class SpiderDataConverter : ISpiderDataConverter
{
    public List<Project> ToProjects(SpiderData data)
    {
        var projects = new List<Project>();
        foreach (var repository in data.search.nodes)
        {
            projects.Add(new Project()
            {
                Name = repository.name,
                ReadMe = repository.readmeText,
                Owner = repository.owner.login
            });
        }
        return projects;
    }
}