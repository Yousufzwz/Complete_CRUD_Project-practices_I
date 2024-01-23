﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Domain.Exceptions;

public class DuplicateTitleException : Exception
{
    public DuplicateTitleException():base("Title is duplicate! Give another one please.") { }
}
