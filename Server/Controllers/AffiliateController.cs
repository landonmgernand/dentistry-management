using System.Collections.Generic;
using System.Linq;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services;
using DentistryManagement.Shared.ViewModels.Addresses;
using DentistryManagement.Shared.ViewModels.Affiliates;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliateController : ControllerBase
    {
        private readonly AffiliateService _service;

        public AffiliateController(AffiliateService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AffiliateViewModel>> GetAffiliates()
        {
            return _service.GetAll().Select(a => AffiliateMapper.DTOtoAffiliateVM(a)).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<AffiliateViewModel> GetAffiliate(int id)
        {
            var affiliate = _service.Get(id);

            if (affiliate is null)
            {
                return NotFound();
            }

            return AffiliateMapper.DTOtoAffiliateVM(affiliate);
        }

        [HttpGet("{affiliateId}/address")]
        public ActionResult<AddressViewModel> GetAffiliateAddress(int affiliateId)
        {
            var affiliateAddress = _service.GetAffiliateAddress(affiliateId);

            if (affiliateAddress is null)
            {
                return NotFound();
            }

            return AddressMapper.DTOtoAddressVM(affiliateAddress);
        }

        [HttpPost]
        public ActionResult CreateAffiliate([FromBody] CreateAffiliateViewModel createAffiliateViewModel)
        {
            var affiliateDTO = AffiliateMapper.CreateAffiliateVMToDTO(createAffiliateViewModel);
            _service.Create(affiliateDTO);

            return Ok(ModelState);
        }

        [HttpPost("{affiliateId}/address")]
        public ActionResult CreateAffiliateAddress(int affiliateId, [FromBody] CreateAddressViewModel createAddressViewModel)
        {
            if (affiliateId != createAddressViewModel.AffiliateId)
            {
                return BadRequest();
            }

            var affiliate = _service.Get(createAddressViewModel.AffiliateId);

            if (affiliate is null)
            {
                return NotFound();
            }

            var addressDTO = AddressMapper.CreateAddressVMToDTO(createAddressViewModel);
            _service.CreateAffiliateAddress(addressDTO);

            return Ok(ModelState);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAffiliate(int id, UpdateAffiliateViewModel updateAffiliateViewModel)
        {
            if (id != updateAffiliateViewModel.Id)
            {
                return BadRequest();
            }

            if (!_service.Exist(id))
            {
                return NotFound();
            }

            var affiliateDTO = AffiliateMapper.UpdateAffiliateVMToDTO(updateAffiliateViewModel);
            _service.Update(affiliateDTO);

            return NoContent();
        }

        [HttpPut("{affiliateId}/address/{id}")]
        public ActionResult UpdateAffiliiateAddress(int affiliateId, int id, UpdateAddressViewModel updateAddressViewModel)
        {
            if (id != updateAddressViewModel.Id || affiliateId != updateAddressViewModel.AffiliateId)
            {
                return BadRequest();
            }

            var addressDTO = AddressMapper.UpdateAddressVMToDTO(updateAddressViewModel);
            _service.UpdateAffiliateAddress(addressDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAffiliate(int id)
        {
            if (!_service.Exist(id))
            {
                return NotFound();
            }

            _service.Delete(id);

            return NoContent();
        }
    }
}
