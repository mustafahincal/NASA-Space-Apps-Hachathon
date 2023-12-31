﻿using Teapot.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.Entities.Concrete;
using Teapot.Business.Concrete.Messages.Dto;

namespace Teapot.Business.Concrete.Messages
{
    public interface IMessageService
    {

        Task<IDataResult<Message>> Add(AddMessageDto addMessageDto);
        Task<IDataResult<Message>> GetById(int id);
        Task<IDataResult<List<Message>>> GetAll();
        Task<IResult> Delete(int id);
    }
}
