using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController(ICargoCustomerService _cargoCustomerService) : ControllerBase
    {

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomersDto)
        {
            CargoCustomer CargoCustomers = new CargoCustomer()
            {
                Name = createCargoCustomersDto.Name,
                Surname = createCargoCustomersDto.Surname,
                Email = createCargoCustomersDto.Email,
                City = createCargoCustomersDto.City,
                District = createCargoCustomersDto.District,
                Address = createCargoCustomersDto.Address,
            };
            _cargoCustomerService.TInsert(CargoCustomers);
            return Ok("Müşteri bilgileri başarıyla oluşturuldu");
        }


        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Müşteri bilgileri başarıyla silindi");
        }


        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }


        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomersDto)
        {
            CargoCustomer CargoCustomers = new CargoCustomer()
            {
                Id = updateCargoCustomersDto.Id,
                Name = updateCargoCustomersDto.Name,
                Surname = updateCargoCustomersDto.Surname,
                Email = updateCargoCustomersDto.Email,
                City = updateCargoCustomersDto.City,
                District = updateCargoCustomersDto.District,
                Address = updateCargoCustomersDto.Address,
            };
            _cargoCustomerService.TUpdate(CargoCustomers);
            return Ok("Müşteri bilgileri başarıyla güncellendi");
        }

    }
}
