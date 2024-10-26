using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController(ICargoCompanyService _cargoCompanyService) : ControllerBase
    {


        [HttpGet]
        public IActionResult CargoCompanyList() 
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto) 
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName,
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Kargo şirketi başarıyla oluşturuldu");
        }


        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id) 
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo şirketi başarıyla silindi");
        }


        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id) 
        {
            var value = _cargoCompanyService.TGetById(id);
            return Ok(value);
        }


        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto) 
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                Id = updateCargoCompanyDto.Id,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName,
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Kargo şirketi başarıyla güncellendi");
        }



    }
}
