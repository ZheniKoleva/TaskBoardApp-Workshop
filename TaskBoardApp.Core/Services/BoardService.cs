using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Core.Contracts;
using TaskBoardApp.Core.Data;
using TaskBoardApp.Core.Data.Common;
using TaskBoardApp.Core.Data.Models;
using TaskBoardApp.Core.Models;

namespace TaskBoardApp.Core.Services
{
    public class BoardService : IBoardService
    {
        //private readonly IConfiguration config;

        private readonly IRepository repo;

        public BoardService(
          // IConfiguration _config,
           IRepository _repo)
        {
            //config = _config;
            repo = _repo;
        }

        public async Task<IEnumerable<BoardViewModel>> GetAllBoards()
        {
            return await repo.All<Board>()
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })
                })
                .ToListAsync();
        }

        

       
       

       
        //public async Task Add(ProductDto productDto)
        //{
        //    var product = new Product()
        //    {
        //        Name = productDto.Name,
        //        Price = productDto.Price,
        //        Quantity = productDto.Quantity
        //    };

        //    await repo.AddAsync(product);
        //    await repo.SaveChangesAsync();
        //}

        //public async Task Delete(Guid id)
        //{
        //    var product = await repo.All<Product>()
        //        .FirstOrDefaultAsync(p => p.Id == id);

        //    if (product != null)
        //    {
        //        product.IsActive = false;

        //        await repo.SaveChangesAsync();
        //    }
        //}

        
        //public async Task<IEnumerable<ProductDto>> GetAll()
        //{
        //    return await repo.AllReadonly<Product>()
        //        .Where(p => p.IsActive)
        //        .Select(p => new ProductDto()
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            Price = p.Price,
        //            Quantity = p.Quantity
        //        }).ToListAsync();
        //}
    }
}
