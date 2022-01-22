using ApiFundacion.Models;
using ApiFundacion.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFundacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {

        private readonly IAreaRepository areaRepository;
        private readonly IMapper mapper;

        

        public AreasController(IAreaRepository areaRepository, IMapper mapper)
        {
            this.areaRepository = areaRepository;
            this.mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            var area = areaRepository.GetAreas();
            return Ok(area);
        }



        //// GET api/<AreasController>/5
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var area = areaRepository.GetArea(id);
            return Ok(area);
        }


    }
}
