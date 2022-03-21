using ArenaHoldings.ArticleManagement.Api.DataEntities;
using ArenaHoldings.ArticleManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArenaHoldings.ArticleManagement.Api.repositories.services
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(ArticleContext articleContext, ILogger logger) : base(articleContext, logger)
        {
        }

        public override async Task<bool> CreateOrUpdate(User userEntity)
        {
            try
            {
                var existingUser = await dbSet.FirstOrDefaultAsync(x => x.Id == userEntity.Id);
                if (existingUser == null)
                    return await Add(userEntity);

                existingUser.Name = userEntity.Name;
                existingUser.Email = userEntity.Email;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} CreateOrUpdate function error", typeof(UserRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.FirstOrDefaultAsync(x => x.Id == id)
                                        ;

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Get All User function error", typeof(UserRepository));
                return new List<User>();
            }
        }
    }
}
