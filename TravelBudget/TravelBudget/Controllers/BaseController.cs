using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using TravelBudget.ViewModels.Enums;

namespace TravelBudget.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ILogger<BaseController> _logger;
        protected readonly IMapper _mapper;
        public BaseController(ILogger<BaseController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public void PopUpNotification(string title, string message = "",  NotificationType notificationType = NotificationType.success)
        {
            var msg = new
            {
                title = title,
                message = message,
                type = notificationType.ToString(),
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }
    }
}
