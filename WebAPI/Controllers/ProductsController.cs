using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetListProducts;
using Application.Products.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/{tenant}/[Controller]")]
[Authorize]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ListProductDto[]>> GetList()
    {
        return Ok(await mediator.Send(new GetListProductsQuery()));
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ProductDto>> Get(int Id)
    {
        return Ok(await mediator.Send(new GetProductQuery { Id = Id }));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateProductCommand command)
    {
        return Created(string.Empty, await mediator.Send(command));
    }
}
