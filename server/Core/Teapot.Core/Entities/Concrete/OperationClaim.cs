﻿using System;
using System.Collections.Generic;
using System.Text;
using Teapot.Core.Entities.Abstract;

namespace Teapot.Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
