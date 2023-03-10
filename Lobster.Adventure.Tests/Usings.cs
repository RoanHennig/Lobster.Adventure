global using Xunit;
global using FluentAssertions;
global using Microsoft.AspNetCore.Mvc;
global using Lobster.Adventure.Logic.Models;
global using Lobster.Adventure.Tests.Fixtures;
global using Microsoft.Extensions.Logging;
global using Moq;
global using Lobster.Adventure.Logic.Interfaces.Services;
global using Lobster.Adventure.Controllers;
global using Lobster.Adventure.Logic.Interfaces.Services.Create;
global using Lobster.Adventure.Logic.Interfaces.Services.Save;
global using Lobster.Adventure.Logic.Interfaces.Services.Read;
global using Lobster.Adventure.Logic.Interfaces.Services.Get;
global using Lobster.Adventure.DataAccess.Entities;
global using Lobster.Adventure.Logic.Interfaces.Mapping;
global using Microsoft.Extensions.DependencyInjection;
global using MongoDB.Driver;
global using Lobster.Adventure.DataAccess.Interfaces.Repositories;
