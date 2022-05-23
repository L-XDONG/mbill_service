﻿global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using FreeSql;
global using System.Data;
global using System.Threading.Tasks;
global using FreeSql.DataAnnotations;
global using mbill.Core.Domains.Common.Base;
global using mbill.Core.Domains.Common.Consts;
global using mbill.Core.Domains.Common;
global using mbill.Core.Domains.Common.Enums.Base;
global using mbill.Core.Domains.Entities.User;
global using mbill.Core.Domains.Entities.Core;
global using mbill.Core.Security;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authorization.Infrastructure;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using System.Security.Claims;
global using mbill.Core.Exceptions;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Newtonsoft.Json;
global using Microsoft.AspNetCore.Mvc.ApiExplorer;
global using Microsoft.AspNetCore.Mvc.Controllers;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using System.Reflection;
global using Castle.DynamicProxy;
global using mbill.Core.AOP.Attributes;
global using mbill.Core.Common.Configs;
global using mbill.ToolKits.Utils;
global using mbill.Core.Extensions;
global using System.Net;
global using AspNetCoreRateLimit;
global using Microsoft.Extensions.Options;
global using Serilog;
global using Serilog.Events;
global using System.IO;
global using mbill.Core.Domains.Common.Options;
global using Microsoft.AspNetCore.Builder;
global using Swashbuckle.AspNetCore.SwaggerUI;
global using Microsoft.Extensions.Configuration;
global using Microsoft.AspNetCore.Mvc.Routing;
global using System.ComponentModel;
global using System.ComponentModel.DataAnnotations;
global using DotNetCore.CAP;
global using DotNetCore.CAP.Messages;
global using Microsoft.Extensions.DependencyInjection;
global using Savorboard.CAP.InMemoryMessageQueue;
global using mbill.Core.AOP.Filters;
global using CSRedis;
global using Microsoft.Extensions.Caching.Distributed;
global using Microsoft.Extensions.Caching.Redis;
global using DotNetCore.Security;
global using Microsoft.AspNetCore.Authentication.Cookies;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.Data.SqlClient;
global using MySqlConnector;
global using Newtonsoft.Json.Linq;
global using System.Linq.Expressions;
global using System.Threading;
global using mbill.Core.Domains.Entities.Bill;
global using mbill.Core.Interface.IRepositories.Base;
global using mbill.Core.Interface.IDependency;
global using static mbill.Core.Domains.Common.Consts.SystemConst;
