using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController(ICargoDetailService _cargoDetailService) : ControllerBase
    {
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailsDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetailsDto.Barcode,
                CargoCompanyId = createCargoDetailsDto.CargoCompanyId,
                ReceiverCustomer = createCargoDetailsDto.ReceiverCustomer,
                SenderCustomer = createCargoDetailsDto.SenderCustomer,
            };
            _cargoDetailService.TInsert(CargoDetail);
            return Ok("Kargo detayları başarıyla oluşturuldu");
        }


        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayları başarıyla silindi");
        }


        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }


        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailsDto)
        {
            CargoDetail CargoDetails = new CargoDetail()
            {
                Id = updateCargoDetailsDto.Id,
                Barcode = updateCargoDetailsDto.Barcode,
                CargoCompanyId = updateCargoDetailsDto.CargoCompanyId,
                ReceiverCustomer = updateCargoDetailsDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailsDto.SenderCustomer,
            };
            _cargoDetailService.TUpdate(CargoDetails);
            return Ok("Kargo detayları başarıyla güncellendi");
        }
    }
}
