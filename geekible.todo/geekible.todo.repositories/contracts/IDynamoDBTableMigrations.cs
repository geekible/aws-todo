﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geekible.todo.repositories.contracts
{
    public interface IDynamoDBTableMigrations
    {
        Task BuildDynamoDBTables();
    }
}
