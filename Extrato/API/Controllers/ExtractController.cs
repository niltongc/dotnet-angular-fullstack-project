using AutoMapper;
using Extrato.API.Models.Domain;
using Extrato.API.Models.DTO;
using Extrato.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Extrato.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtractController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILauchRepository lauchRepository;

        public ExtractController(IMapper mapper, ILauchRepository lauchRepository)
        {
            this.mapper = mapper;
            this.lauchRepository = lauchRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddLauchDTO addLauchDTO)
        {
            var extractDomainModel = mapper.Map<Extract>(addLauchDTO);

            _ = await lauchRepository.CreateAsync(extractDomainModel);

            return Ok(extractDomainModel);



            return Ok(addLauchDTO);
        }
    }
}
