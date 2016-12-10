using Microsoft.AspNetCore.Mvc;
using Lauderdale.Application.Interfaces.Services;
using System;
using Lauderdale.Domain.Operator;
using Lauderdale.Domain.Entities;
using Lauderdale.App.Domain.Interfaces.Repository;

namespace Lauderdale.UI.Web.Controllers
{
    [Route("api/cities")]
    public class CityController : Controller
    {
        private readonly ICityService _service;
        private readonly IUnitOfWork _unitOfWork;

        public CityController(ICityService service, IUnitOfWork unitOfWork)
        {
            this._service = service;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cities = _service.ListAllCities();
                return Ok(cities);
            }
            catch (OperationResultException ex)
            {
                return Json(ex.result);
            }
            catch (Exception ex)
            {
                return Json(OperationResult.Alert("Ops", ex.Message, NoteType.danger));
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var city = _service.GetCityById(id);
                return Ok(city);
            }
            catch (OperationResultException ex)
            {
                return Json(ex.result);
            }
            catch (Exception ex)
            {
                return Json(OperationResult.Alert("Ops", ex.Message, NoteType.danger));
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]City city)
        {
            try
            {
                _service.SaveCity(city);
                _unitOfWork.Commit();
                return Ok(OperationResult.Success);
            }
            catch (OperationResultException ex)
            {
                return Json(ex.result);
            }
            catch (Exception ex)
            {
                return Json(OperationResult.Alert("Ops", ex.Message, NoteType.danger));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _service.RemoveCity(id);
                _unitOfWork.Commit();
                return Ok(OperationResult.Success);
            }
            catch (OperationResultException ex)
            {
                return Json(ex.result);
            }
            catch (Exception ex)
            {
                return Json(OperationResult.Alert("Ops", ex.Message, NoteType.danger));
            }
        }
    }
}
