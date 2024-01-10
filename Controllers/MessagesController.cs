using ChatAppExample.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatAppExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly NotificationService _notificationService;
        private readonly NotifierService _notifierService;

        public MessagesController(NotificationService notificationService, NotifierService notifierService)
        {
            _notificationService = notificationService;
            _notifierService = notifierService;
            _notificationService.Subscribe(_notifierService);
        }
        // GET: api/<MessageSenderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _notifierService.messages;
        }
/*
        // GET api/<MessageSenderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<MessageSenderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _notifierService.SendMessage(value);
        }
    }
}
