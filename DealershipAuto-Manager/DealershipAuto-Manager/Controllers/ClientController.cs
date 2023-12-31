﻿using DealershipAuto_Manager.Dtos;
using DealershipAuto_Manager.Models;
using DealershipAuto_Manager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipAuto_Manager.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Route("clients")] //POST api/clients
        public IActionResult Add(AddClientDto client) 
        {
            _clientService.Add(client);
            return Ok();
        }

        [HttpGet]
        [Route("clients")] //GET api/clients
        public IActionResult GetAll()
        {
            var result = _clientService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("clients/{idClient}")] //GET api/clients/{idClient}
        public IActionResult GetById(Guid idClient)
        {
            var result = _clientService.Get(idClient);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPut]
        [Route("clients/{idClient}")] //PUT api/clients/{idClient}
        public IActionResult Update(Guid idClient, UpdateClientDto client)
        {
            _clientService.Update(idClient, client);
            return Ok(); 
        }

        [HttpDelete]
        [Route("clients/{idClient}")] //PUT api/clients/{idClient}
        public IActionResult Delete(Guid idClient)
        {
            _clientService.Delete(idClient);
            return NoContent();
        }
    }
}
