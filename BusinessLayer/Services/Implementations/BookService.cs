using BusinessLayer.Enumerations;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.ViewModels;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services.Implementations
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<BookModel>> GetBooksOrderedByAsync(BookOrderEnum order)
        {
            var bookQuery = _repository.List();
            if (order != BookOrderEnum.Empty)
            {
                switch (order)
                {
                    case BookOrderEnum.Author: { bookQuery = bookQuery.OrderBy(x => x.Author); break; }
                    case BookOrderEnum.Title: { bookQuery = bookQuery.OrderBy(x => x.Title); break; }
                }
            }

            var result = await bookQuery.Include(x => x.Ratings)
                .Select(x => new BookModel()
                {
                    Id = x.Id,
                    Author = x.Author,
                    Title = x.Title,

                    Rating = x.Ratings.Count > 0 ? Convert.ToDecimal(x.Ratings.Average(r => r.Score)) : 0,
                    ReviewsNumber = x.Reviews.Count(),
                })
                .ToListAsync();

            return result;
        }

        public async Task<BookDetailsModel> GetBookDetailsAsync(int bookId)
        {
            var result = await _repository.FilterById(bookId)
                .Include(x => x.Ratings)
                .Include(x => x.Reviews)
                .Select(x => new BookDetailsModel()
                {
                    Id = x.Id,
                    Author = x.Author,
                    Title = x.Title,
                    Cover = x.Cover,
                    Content = x.Content,
                    Rating = x.Ratings.Count > 0 ? Convert.ToDecimal(x.Ratings.Average(r => r.Score)) : 0,
                    Reviews = x.Reviews.Select(r => new ReviewModel()
                    {
                        Id = r.Id,
                        Message = r.Message,
                        Reviewer = r.Reviewer
                    }).ToList(),
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> RemoveBookAsync(int bookId)
        {
            var book = await _repository.GetByIdAsync(bookId);

            if (book is null)
                return false;

            await _repository.RemoveAsync(book);
            return true;
        }

        public async Task<int> AddUpdateBookAsync(AddUpdateBookModel model)
        {
            var bookEntity = new Book()
            {
                Id = model.Id.HasValue ? model.Id.Value : 0,
                Author = model.Author,
                Content = model.Content,
                Cover = model.Cover,
                Genre = model.Genre,
                Title = model.Title,
            };

            Book book;
            if (model.Id.HasValue)
                book = await _repository.UpdateAsync(bookEntity);
            else
                book = await _repository.InsertAsync(bookEntity);

            return book.Id;
        }


    }
}
