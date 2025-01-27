﻿global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using mbill.Core.AOP.Middleware;
global using mbill.Core.Extensions.ServiceCollection;
global using mbill.Modules;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Hosting;
global using AspNetCoreRateLimit;
global using Autofac.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Mvc.Filters;
global using mbill.Core.Data.Authorization;
global using AutoMapper;
global using mbill.Controllers.Core;
global using mbill.Core.AOP.Attributes;
global using mbill.Core.Domains.Common;
global using mbill.Core.Domains.Common.Consts;
global using mbill.Core.Domains.Entities.Bill;
global using mbill.Service.Bill.Bill;
global using mbill.Service.PreOrder;
global using mbill.Service.Bill.Bill.Input;
global using mbill.Service.Bill.Bill.Output;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using mbill.Service.Bill.Asset;
global using mbill.Service.Bill.Asset.Input;
global using mbill.Service.Bill.Asset.Output;
global using mbill.Service.Bill.Category;
global using mbill.Service.Bill.Category.Input;
global using mbill.Service.Bill.Category.Output;
global using Autofac;
global using mbill.Core.Domains.Common.Enums.Base;
global using mbill.Core.Exceptions;
global using mbill.Service.Core.Auth;
global using mbill.Service.Core.Auth.Input;
global using mbill.Service.PreOrder.Input;
global using mbill.Service.Core.User;
global using mbill.Service.Core.User.Output;
global using mbill.Service.PreOrder.Output;
global using mbill.Service.Core.Wx;
global using mbill.Service.Core.Auth.Output;
global using System.IO;
global using mbill.Core.Common.Configs;
global using mbill.Service.Core.Files;
global using mbill.Service.Core.Files.Output;
global using mbill.ToolKits.Utils;
global using Microsoft.AspNetCore.Http;
global using mbill.Service.Core.Logger;
global using mbill.Service.Core.Logger.Input;
global using mbill.Service.Core.Logger.Output;
global using mbill.Service.Core.Permission;
global using mbill.Service.Core.Permission.Input;
global using mbill.Service.Core.Permission.Output;
global using mbill.Service.Core.Wx.Output;
global using mbill.Core.Domains.Entities.User;
global using mbill.Service.Core.User.Input;
global using mbill.Core.Common;
global using mbill.Service.Core.DataSeed;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using System.Threading;
global using Microsoft.AspNetCore.Authorization.Infrastructure;
global using System.Security.Claims;
global using mbill.Core.Security;
global using mbill.Modules.Configs;
global using mbill.Core.Interface.IDependency;
global using System.Reflection;
global using mbill.Core.Domains.Common.Base;
global using mbill.Core.Extensions;
global using FreeSql;
global using FreeSql.Internal;
global using Serilog;
global using System.Diagnostics;
global using Autofac.Extras.DynamicProxy;
global using mbill.Core.AOP.Intercepts;
