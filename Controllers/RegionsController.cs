using csharpPractice.Data;
using csharpPractice.Models.Domian;
using csharpPractice.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharpPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WalkDbContext dbContext;

        public RegionsController(WalkDbContext dbContext)
        {
            this.dbContext = dbContext;

        }



        [HttpGet]
        public IActionResult GetAll()
            
        {
            //<-------Mget data from database - Domain models<-------
            var regionsDomain = dbContext.Regions.ToList();


            //<-------Map Domain Models to DTOs<-------
            var regionsDto = new List<RegionDTO>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDTO()
                {
                Id = regionDomain.Id, 
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
                });
            }



            //var regions = new List<Region>
            //{
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Cornerstone",
            //        Code ="CS",
            //        RegionImageUrl = "https://www.bing.com/images/search?view=detailV2&ccid=AdC4xE7C&id=43282A8B629DD38598D3EB67888EECABF733F7FB&thid=OIP.AdC4xE7CkLBe3byG1FlqGQHaE6&mediaurl=https%3a%2f%2fwww.todocanada.ca%2fwp-content%2fuploads%2fWeaselhead-Flats-25-Urban-Walking-Trails-in-Calgary.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.01d0b8c44ec290b05eddbc86d4596a19%3frik%3d%252b%252fcz96vsjohn6w%26pid%3dImgRaw%26r%3d0&exph=478&expw=720&q=picture+of+trails+in+calgary&FORM=IRPRST&ck=C93F4872C939C1CCEEB510EF43A5E9D5&selectedIndex=0&itb=0&idpp=overlayview&ajaxhist=0&ajaxserp=0"
            //    },
            //     new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Mckenzie Lake",
            //        Code ="ML",
            //        RegionImageUrl = "https://www.bing.com/images/search?view=detailV2&ccid=4nxdKZpv&id=BB529342DE6316775A4772E3E1554B1E5FB5F276&thid=OIP.4nxdKZpvkPHd0F3Jc7rneQHaE8&mediaurl=https%3A%2F%2Fassets.site-static.com%2FuserFiles%2F1686%2Fimage%2Fcalgary-trails-nose-hill.jpg&cdnurl=https%3A%2F%2Fth.bing.com%2Fth%2Fid%2FR.e27c5d299a6f90f1ddd05dc973bae779%3Frik%3DdvK1Xx5LVeHjcg%26pid%3DImgRaw%26r%3D0&exph=800&expw=1200&q=picture+of+trails+in+calgary&FORM=IRPRST&ck=A0B378D1D05A9B4156A37BB2EEEAC455&selectedIndex=5&itb=0&cw=774&ch=639&ajaxhist=0&ajaxserp=0"
            //    },

            //};
            return Ok(regionsDto);
        }
        //<-------MGet single region(get region by ID)

        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var regionDomain = dbContext.Regions.FirstOrDefault(x=> x.Id == id);
            if (regionDomain == null)
            {
                return BadRequest();
            }


            //<-----Map/convert region domain to region DTO
            var regionsDto = new RegionDTO
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionsDto);
        }

        //<---POST to create new region

        //[HttpPost]
        //public IActionResult Create
        //    { get; set; }

    }

}
