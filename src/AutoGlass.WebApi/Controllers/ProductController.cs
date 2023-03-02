using System.Threading.Tasks;
using AutoGlass.Application.Interfaces;
using AutoGlass.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlass.WebApi.Controllers
{
    [Route("v1/Product")]
    public class ProductController : BaseController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }


        [HttpGet(Name = "Product")]
        public async Task<IActionResult> GetAll(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 25) =>
            CustomResponse(
                    await _productAppService.GetAll(skip, take)
            );


        [HttpGet("{id:Int}", Name = "ProductByRegister")]
        public async Task<IActionResult> GetById(
            [FromRoute] int? id
           ) =>
            CustomResponse(
                    await _productAppService.GetById(id.Value)
            );


        [HttpPost(Name = "RegisterProduct")]
        public async Task<IActionResult> RegisterProduct(
            [FromBody] ProductViewModel product) =>
            CustomResponse(await _productAppService.Insert(product));

        [HttpPut("{id:Int}", Name = "UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(
             [FromRoute] int? id,
             [FromBody] ProductViewModel product
             )
        {
            if (id is null || id != product.Id)
                return CustomResponse("Id inválido");

            return CustomResponse(await _productAppService.Update(product));
        }

        [HttpDelete("{id:Int}/remove", Name = "RemoveProduct")]
        public async Task<IActionResult> RemoveProduct(
            [FromRoute] int id) =>
            CustomResponse(await _productAppService.Remove(id));
    }
}
