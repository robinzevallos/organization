﻿using Domain.Common;

namespace Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
}
