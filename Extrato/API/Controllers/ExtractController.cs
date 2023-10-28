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
        private readonly ITransactionRepository transactionRepository;

        public ExtractController(IMapper mapper, ITransactionRepository transactionRepository)
        {
            this.mapper = mapper;
            this.transactionRepository = transactionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTransactionDTO addTransactionDTO)
        {
            var extractDomainModel = mapper.Map<Extract>(addTransactionDTO);

            _ = await transactionRepository.CreateAsync(extractDomainModel);

            return Ok(extractDomainModel);

        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions(DateTime startDate, DateTime endDate)
        {
            if (startDate == DateTime.MinValue && startDate == DateTime.MinValue)
            {
                // Se o valor padrão DateTime.MinValue for fornecido, defina-o para DateTime.UtcNow.AddDays(-2).
                startDate = DateTime.UtcNow.AddDays(-2);
                endDate = DateTime.UtcNow;
            }

            var extracts = await transactionRepository.GetTransactionsForDataRange(startDate, endDate);

            if (extracts == null) 
            {
                return NotFound();
            }

            return Ok(extracts);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetTransactionById([FromRoute] Guid id)
        {
            var transaction = await transactionRepository.GetTransactionById(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateTransaction([FromBody] UpdateTransactionDTO updateTransactionDTO,[FromRoute] Guid id)
        {
            var extractDomainModel = mapper.Map<Extract>(updateTransactionDTO);

            extractDomainModel = await transactionRepository.UpdateTransactionAsync(id, extractDomainModel);

            if (extractDomainModel == null)
            {
                return BadRequest("Extract not found or not allow to change");
            }

            return Ok(extractDomainModel);
        }
    }
}
