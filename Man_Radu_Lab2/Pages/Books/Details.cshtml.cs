using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Man_Radu_Lab2.Data;
using Man_Radu_Lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Man_Radu_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Man_Radu_Lab2.Data.Man_Radu_Lab2Context _context;

        public DetailsModel(Man_Radu_Lab2.Data.Man_Radu_Lab2Context context)
        {
            _context = context;
        }

      public Book Book { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
                "PublisherName");
                ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID",
                "LastName");
                Book = book;
            }
            return Page();
        }
    }
}
