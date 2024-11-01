﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paven_Darius_Lab2.Data;
using Paven_Darius_Lab2.Models;
using Paven_Darius_Lab2.Models.ViewModels;

namespace Paven_Darius_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Paven_Darius_Lab2.Data.Paven_Darius_Lab2Context _context;

        public IndexModel(Paven_Darius_Lab2.Data.Paven_Darius_Lab2Context context)
        {
            _context = context;
        }

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public IList<Category> Category { get; set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            Category = await _context.Category.ToListAsync();
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                var category = CategoryData.Categories
                    .Where(c => c.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(bc => bc.Book);
            }
        }
    }
}
