using System.Collections.Generic;
using AutoMapper;
using UpdateODGovernmentFees.Data;
using UpdateODGovernmentFees.DTOs;
using UpdateODGovernmentFees.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace UpdateODGovernmentFees.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GovernmentFeesController : ControllerBase
    {
        private readonly IGovernmentFeesContext _repository;
        private readonly IMapper _mapper;

        public GovernmentFeesController(IGovernmentFeesContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GovernmentFeeReadDTO>> GetAllCommands()
        {
            var commandItems = _repository.GetAllGovernmentFees();
            return Ok(_mapper.Map<IEnumerable<GovernmentFeeReadDTO>>(commandItems));
        }


        [HttpGet("{id}", Name = "GetCommandByID")]
        public ActionResult<GovernmentFeeReadDTO> GetCommandByID(int id)
        {
            var commandItem = _repository.GetGovernmentFeeByID(id);

            if (commandItem != null)
                return Ok(_mapper.Map<GovernmentFeeReadDTO>(commandItem));

            else
                return NotFound();

        }

        [HttpPost]
        public ActionResult<GovernmentFeeReadDTO> CreateCommand(GovernmentFeeDTO commandCreate)
        {
            var commandModel = _mapper.Map<GovernmentFee>(commandCreate);
            _repository.CreateGovernmentFee(commandModel);
            if (_repository.SaveChanges())
            {
                var commandReadDTO = _mapper.Map<GovernmentFeeReadDTO>(commandModel);
                return CreatedAtRoute(nameof(GetCommandByID), new { ID = commandModel.ID }, commandReadDTO);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(GovernmentFeeDTO commandUpdate, int id)
        {
            var commandModelFromRepo = _repository.GetGovernmentFeeByID(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(commandUpdate, commandModelFromRepo);
            }
            _repository.UpdateGovernmentFee(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(JsonPatchDocument<GovernmentFeeDTO> patchDocument, int id)
        {
            var commandModelFromRepo = _repository.GetGovernmentFeeByID(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                var commandToPatch = _mapper.Map<GovernmentFeeDTO>(commandModelFromRepo);
                patchDocument.ApplyTo(commandToPatch, ModelState);
                if (!TryValidateModel(commandToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    _mapper.Map(commandToPatch, commandModelFromRepo);
                    _repository.UpdateGovernmentFee(commandModelFromRepo);
                    _repository.SaveChanges();
                    return NoContent();
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetGovernmentFeeByID(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _repository.DeleteGovernmentFee(commandModelFromRepo);
                _repository.SaveChanges();
                return NoContent();
            }
        }
    }
}