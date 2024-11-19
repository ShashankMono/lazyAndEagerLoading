using LazyAndEagerLoading.Data;
using LazyAndEagerLoading.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LazyAndEagerLoading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LazyAnEagerController : ControllerBase
    {
        private readonly AuthorContext _context;
        public List<Author> _authorLazy;//this for lazy loading example
        public LazyAnEagerController(AuthorContext context)
        {
            _context = context;
            _authorLazy = _context.authors.ToList();
        }

        //Eager loading is the default functionality where if you want data from attached tables then we
        //have to load the data at once in the starting and if at some point we don't need that data then 
        //it holds redudant data which is not supposed to used at that time so, eager loading loads more 
        // data and is not mermory efficient.
        //when lazy loading is enabled eagar loading is disabled
        [HttpGet("/eagerLoading")]
        public IActionResult Get()
        {
            return Ok(_context.authors.Include(a=>a.Books).ToList());
        }

        //Lazy loading loads data from one table
        //when a we just need list of books of author then lazy loading happens and by using _authorLazy
        // a seprate query is fired and the list of books of that particular author is passed.
        // so it's faster and memory efficient loading and if we enable some setting by writing code
        // in program.cs
        //Install entitycore.proxies library from nuget package manager
        //options.UseLazyLoadingProxies(); in builder.services.AddDbcontextoptions
        // for enabling the lazy loading. and when ever we need a data from the attached table
        // like author have list of books then I can get it when it is needed and not to load the whole data 
        // at once just in the starting which happens in eager loading.
        //navigation property to be made virtual

        [HttpGet("/Author/lazyLoading")]
        public IActionResult GetAuthor() {
            return Ok(_authorLazy);// this will give list of author
        }
        [HttpGet("/Books/lazyLoading")]
        public IActionResult GetBooks()
        {
            return Ok(_authorLazy[1].Books.ToList());//here the lazy loading happens and books are given
        }
    }
}
