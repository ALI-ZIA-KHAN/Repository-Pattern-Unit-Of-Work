using CRUDOperationInDotNetCore.Interfaces;
using CRUDOperationInDotNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;


//ctrl M O shortcut for having funcitons closed 

//after model work we created controller by adding Controller
namespace CRUDOperationsin.NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {       
        private readonly IUnitOfWork uow;

        public BrandController(IUnitOfWork uow)
        {
            this.uow=uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            var res= await uow.brandRepository.GetBrandsAsync();
            return Ok(res);

        }

        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            await uow.brandRepository.AddBrand(brand);
            await uow.SaveAsync();
            return StatusCode(201);          
        }
     
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrand(int id)
        {      
            await uow.brandRepository.DeleteBrand(id);
           await uow.SaveAsync();
            return Ok();

        }
    }
}



//Use Task when the operation is asynchronous (e.g., accessing a database, making network requests).
//Use ActionResult when you want to return specific HTTP status codes with data.
//Use IEnumerable or a specific collection type when you are returning a collection of items.