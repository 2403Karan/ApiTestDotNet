using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.DAOs;
using Task.Models;

namespace Task.Controllers
{
    [ApiController]
    [Route("/testapp/api/v1/[controller]")]
    public class OfficesController : ControllerBase
    {
        private readonly OfficeDAO _officeDAO;

        public OfficesController(IConfiguration configuration)
        {
            _officeDAO = new OfficeDAO(configuration);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Office>> GetAllOffices() => Ok(_officeDAO.GetAllOffices());

        [HttpGet("{id}")]
        public ActionResult<Office?> GetOfficeById(Guid id) => Ok(_officeDAO.GetOfficeById(id));
    }
}