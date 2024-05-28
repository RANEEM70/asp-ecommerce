using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCrafters_backend_teamwork.src.DTOs;

public class ProductCreateDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    public double Price { get; set; }

}
public class ProductReadDto
{
    public Guid Id { get;  set;}
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    public double Price { get; set; }

}
