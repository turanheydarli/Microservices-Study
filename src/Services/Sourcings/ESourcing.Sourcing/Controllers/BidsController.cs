using ESourcing.Sourcing.Repositories.Interfaces;
using ESourcing.Sourcings.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ESourcing.Sourcings.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        #region Fields
        private readonly IBidRepository _bidRepository;
        #endregion

        #region Ctor
        public BidsController(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }
        #endregion

        #region Methods
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<ActionResult> SendBid(Bid bid)
        {
            await _bidRepository.SendBid(bid);
            return Ok();
        }

        [ProducesResponseType(typeof(Bid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("{id:length(24)}", Name = "GetWinnerBid")]
        public async Task<ActionResult<Bid>> GetWinnerBid(string id)
        {
            Bid bid = await _bidRepository.GetWinnerBid(id);

            if(bid == null)
            {
                return NotFound();
            }

            return Ok(bid);
        }

        [ProducesResponseType(typeof(IEnumerable<Bid>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<IEnumerable<Bid>>> GetBidsByAuctionId(string id)
        {
            List<Bid> bids = await _bidRepository.GetBidsByAuctionId(id);

            if (bids == null)
            {
                return NotFound();
            }

            return Ok(bids);
        }

        #endregion
    }
}
