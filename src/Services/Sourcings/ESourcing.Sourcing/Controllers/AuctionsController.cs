using ESourcing.Sourcing.Repositories.Interfaces;
using ESourcing.Sourcings.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ESourcing.Sourcings.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        #region Fields
        private readonly IRepository<Auction> _auctionRepository;
        #endregion

        #region Ctor
        public AuctionsController(IRepository<Auction> auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        #endregion

        #region Methods
        [ProducesResponseType(typeof(IEnumerable<Auction>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Auction>>> GetAuctions()
        {
            var auctions = await _auctionRepository.GetAll();

            if (auctions == null)
            {
                return NotFound();
            }

            return Ok(auctions);
        }

        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Auction>> GetAuction(string id)
        {
            var auction = await _auctionRepository.Get(id);

            if (auction == null)
            {
                return NotFound();
            }

            return Ok(auction);
        }

        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<ActionResult<Auction>> CreateAuction([FromBody] Auction auction)
        {
            await _auctionRepository.Create(auction);
            return CreatedAtAction("GetAuction", new { id = auction.Id }, auction);
        }

        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)]
        [HttpPut]
        public async Task<IActionResult> UpdateAuction([FromBody] Auction auction)
        {
            return Ok(await _auctionRepository.Update(auction));
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> DeleteAuction(string id)
        {
            await _auctionRepository.Delete(id);
            return Ok();
        }
        #endregion

    }
}
