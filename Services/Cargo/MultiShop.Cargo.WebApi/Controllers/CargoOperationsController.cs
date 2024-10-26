using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController(ICargoOperationService _cargoOperationService) : ControllerBase
    {
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationsDto)
        {
            CargoOperation CargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationsDto.Barcode,
                Description = createCargoOperationsDto.Description,
                OperationDate = createCargoOperationsDto.OperationDate,
            };
            _cargoOperationService.TInsert(CargoOperation);
            return Ok("Kargo operasyonları başarıyla oluşturuldu");
        }


        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo operasyonları başarıyla silindi");
        }


        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }


        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationsDto)
        {
            CargoOperation CargoOperations = new CargoOperation()
            {
                Id = updateCargoOperationsDto.Id,
                Barcode = updateCargoOperationsDto.Barcode,
                Description = updateCargoOperationsDto.Description,
                OperationDate = updateCargoOperationsDto.OperationDate,
            };
            _cargoOperationService.TUpdate(CargoOperations);
            return Ok("Kargo operasyonları başarıyla güncellendi");
        }
    }
}
