﻿global using Ecommerce.Data.Entities;
global using Ecommerce.Data.Model;
global using Ecommerce.Infrastructure.Context;
global using Ecommerce.Infrastructure.UnitOfWorkPattern;
global using Ecommerce.Services.Email;
global using Ecommerce.Services.FileManagers;
global using Ecommerce.Services.IServices;
global using MailKit.Net.Smtp;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using MimeKit;
global using System.IdentityModel.Tokens.Jwt;
global using System.Linq.Expressions;
global using System.Security.Claims;
global using System.Text;