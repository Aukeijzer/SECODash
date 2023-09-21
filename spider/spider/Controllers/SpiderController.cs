﻿using Microsoft.AspNetCore.Mvc;
using SECODashBackend.Models;
using spider.Converter;
using spider.Services;

namespace spider.Controllers;

[ApiController]
[Route("[controller]")]
public class SpiderController
{
    private readonly IGitHubService _gitHubService;
    private readonly ISpiderDataConverter _spiderDataConverter;

    public SpiderController(IGitHubService gitHubService, ISpiderDataConverter spiderDataConverter)
    {
        _gitHubService = gitHubService;
        _spiderDataConverter = spiderDataConverter;
    }
    [HttpGet("{name}")]
    public async Task<ActionResult<List<Project>>> GetByTopic(string name)
    {
        return _spiderDataConverter.ToProjects(await _gitHubService.QueryRepositoriesByName(name));
    }
}