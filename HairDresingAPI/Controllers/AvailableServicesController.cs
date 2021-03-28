using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDresingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AvailableServicesController : SharedController<AvailableService>
    {
        public AvailableServicesController(IRepository<AvailableService> repository) : base(repository)
        {

        }
    }
}
