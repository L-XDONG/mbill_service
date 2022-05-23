﻿global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using mbill_service.Core.AOP.Middleware;
global using mbill_service.Core.Extensions.ServiceCollection;
global using mbill_service.Modules;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Hosting;
global using AspNetCoreRateLimit;
global using Autofac.Extensions.DependencyInjection;
global using AutoMapper;
global using mbill_service.Controllers.Core;
global using mbill_service.Core.AOP.Attributes;
global using mbill_service.Core.Domains.Common;
global using mbill_service.Core.Domains.Common.Consts;
global using mbill_service.Core.Domains.Entities.Bill;
global using mbill_service.Service.Bill.Statement;
global using mbill_service.Service.Bill.Statement.Input;
global using mbill_service.Service.Bill.Statement.Output;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using mbill_service.Service.Bill.Asset;
global using mbill_service.Service.Bill.Asset.Input;
global using mbill_service.Service.Bill.Asset.Output;
global using mbill_service.Service.Bill.Category;
global using mbill_service.Service.Bill.Category.Input;
global using mbill_service.Service.Bill.Category.Output;
global using Autofac;
global using mbill_service.Core.Domains.Common.Enums.Base;
global using mbill_service.Core.Exceptions;
global using mbill_service.Service.Core.Auth;
global using mbill_service.Service.Core.Auth.Input;
global using mbill_service.Service.Core.User;
global using mbill_service.Service.Core.User.Output;
global using mbill_service.Service.Core.Wx;
global using mbill_service.Service.Core.Auth.Output;
global using System.IO;
global using mbill_service.Core.Common.Configs;
global using mbill_service.Service.Core.Files;
global using mbill_service.Service.Core.Files.Output;
global using mbill_service.ToolKits.Utils;
global using Microsoft.AspNetCore.Http;
global using mbill_service.Service.Core.Logger;
global using mbill_service.Service.Core.Logger.Input;
global using mbill_service.Service.Core.Logger.Output;
global using mbill_service.Service.Core.Permission;
global using mbill_service.Service.Core.Permission.Input;
global using mbill_service.Service.Core.Permission.Output;
global using mbill_service.Service.Core.Wx.Output;
global using mbill_service.Core.Domains.Entities.User;
global using mbill_service.Service.Core.User.Input;
global using mbill_service.Core.Common;
global using mbill_service.Service.Core.DataSeed;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using System.Threading;
global using Microsoft.AspNetCore.Authorization.Infrastructure;
global using System.Security.Claims;
global using mbill_service.Core.Security;
global using mbill_service.Modules.Configs;
global using mbill_service.Core.Interface.IDependency;
global using System.Reflection;
global using mbill_service.Core.Domains.Common.Base;
global using mbill_service.Core.Extensions;
global using FreeSql;
global using FreeSql.Internal;
global using Serilog;
global using System.Diagnostics;
global using Autofac.Extras.DynamicProxy;
global using mbill_service.Core.AOP.Intercepts;
