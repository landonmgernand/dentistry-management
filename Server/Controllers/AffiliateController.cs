using System.Collections.Generic;
using System.Linq;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Addresses;
using DentistryManagement.Shared.ViewModels.Affiliates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliateController : ControllerBase
    {
        private readonly IAffiliateService<AffiliateDTO> _affiiliateService;
        private readonly IAddressService _addressService;

        public AffiliateController(IAffiliateService<AffiliateDTO> affiliateService, IAddressService addressService)
        {
            _affiiliateService = affiliateService;
            _addressService = addressService;
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet]
        public ActionResult<IEnumerable<AffiliateViewModel>> GetAffiliates()
        {
            return _affiiliateService.GetAll().Select(a => AffiliateMapper.DTOtoAffiliateVM(a)).ToArray();
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("{id}")]
        public ActionResult<AffiliateViewModel> GetAffiliate(int id)
        {
            var affiliate = _affiiliateService.Get(id);

            if (affiliate is null)
            {
                return NotFound();
            }

            return AffiliateMapper.DTOtoAffiliateVM(affiliate);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{affiliateId}/address")]
        public ActionResult<AddressViewModel> GetAffiliateAddress(int affiliateId)
        {
            var affiliateAddress = _addressService.Get(affiliateId);

            if (affiliateAddress is null)
            {
                return NotFound();
            }

            return AddressMapper.DTOtoAddressVM(affiliateAddress);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateAffiliate([FromBody] CreateAffiliateViewModel createAffiliateViewModel)
        {
            var affiliateDTO = AffiliateMapper.CreateAffiliateVMToDTO(createAffiliateViewModel);
            _affiiliateService.Create(affiliateDTO);

            return Ok(ModelState);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateAffiliate(int id, [FromBody] UpdateAffiliateViewModel updateAffiliateViewModel)
        {
            if (id != updateAffiliateViewModel.Id)
            {
                return BadRequest();
            }

            if (!_affiiliateService.Exist(id))
            {
                return NotFound();
            }

            var affiliateDTO = AffiliateMapper.UpdateAffiliateVMToDTO(updateAffiliateViewModel);
            _affiiliateService.Update(affiliateDTO);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAffiliate(int id)
        {
            if (!_affiiliateService.Exist(id))
            {
                return NotFound();
            }

            _affiiliateService.Delete(id);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{affiliateId}/address")]
        public IActionResult CreateAddress(int affiliateId, [FromBody] CreateAddressViewModel createAddressViewModel)
        {
            if (affiliateId != createAddressViewModel.AffiliateId)
            {
                return BadRequest();
            }

            if (!_affiiliateService.Exist(affiliateId))
            {
                return NotFound();
            }

            var addressDTO = AddressMapper.CreateAddressVMToDTO(createAddressViewModel);
            _addressService.Create(addressDTO);

            return Ok(ModelState);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{affiliateId}/address/{id}")]
        public IActionResult UpdateAddress(int affiliateId, int id, [FromBody] UpdateAddressViewModel updateAddressViewModel)
        {
            if (id != updateAddressViewModel.Id || affiliateId != updateAddressViewModel.AffiliateId)
            {
                return BadRequest();
            }

            if (!_addressService.Exist(id, affiliateId))
            {
                return NotFound();
            }

            var addressDTO = AddressMapper.UpdateAddressVMToDTO(updateAddressViewModel);
            _addressService.Update(addressDTO);

            return NoContent();
        }
    }
}
