﻿using Microsoft.Extensions.DependencyInjection;
using Teapot.Business.Concrete.AI;
using Teapot.Business.Concrete.Auths;
using Teapot.Business.Concrete.ChatHistories;
using Teapot.Business.Concrete.Chats;
using Teapot.Business.Concrete.Invites;
using Teapot.Business.Concrete.Messages;
using Teapot.Business.Concrete.ProjectContributors;
using Teapot.Business.Concrete.ProjectImages;
using Teapot.Business.Concrete.Projects;
using Teapot.Business.Concrete.Users;
using Teapot.Business.Images;
using Teapot.Core.Utilities.Security.JWT;

namespace Teapot.Business
{
    public static class BusinessModule
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IProjectService, ProjectManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IChatService, ChatManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IProjectContributorService, ProjectContributorManager>();
            services.AddScoped<IImageService, CloudinaryImageService>();
            services.AddScoped<IProjectFileService, ProjectFileManager>();
            services.AddScoped<IChatHistoryService, ChatHistoryManager>();
            services.AddScoped<IAIService, AIManager>();

            services.AddScoped<IInviteService, InviteManager>();

            return services;
        }
    }
}
