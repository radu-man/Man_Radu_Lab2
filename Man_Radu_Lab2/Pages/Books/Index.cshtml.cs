using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Man_Radu_Lab2.Data;
using Man_Radu_Lab2.Models;

namespace Man_Radu_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Man_Radu_Lab2.Data.Man_Radu_Lab2Context _context;

        public IndexModel(Man_Radu_Lab2.Data.Man_Radu_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book.
                    Include(a => a.Author).
                    Include(b => b.Publisher).
                    ToListAsync();
            }
        }
    }
}
