namespace ArtGallery.Common.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient.DataClassification;

    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        public const string PathSeparator = "/";

        public const string Id = "{id}";
    }
}
