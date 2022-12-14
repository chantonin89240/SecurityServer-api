using Microsoft.EntityFrameworkCore;
using SecurityServer.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SecurityServer.Data.Repository
{
    public class BaseRepository<Tentity> : IBaseRepository<Tentity> where Tentity : class
    {
        #region VARIABLE ET CONSTRUCTEUR
        // variable 
        protected readonly DbContext _dbContext;
        protected readonly DbSet<Tentity> _dbSet;

        // initialisation d'une nouvelle instance de baseRepository<Tentity>
        public BaseRepository(DbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this._dbSet = _dbContext.Set<Tentity>();
        }
        #endregion

        #region CREATE
        public Tentity Add(Tentity entity) 
        {
            return this._dbSet.Add(entity).Entity;
        }
        #endregion

        #region DELETE
        public void Delete(int id)
        {
            Tentity entityToDelete = this._dbSet.Find(id);
            if (entityToDelete != null)
            {
                this._dbSet.Remove(entityToDelete);
            }
        }
        #endregion

        #region GET
        public Tentity Get(int id)
        {
            return this._dbSet.Find(id);
        }
        #endregion

        #region GETALL
        public IEnumerable<Tentity> GetAll()
        {
            return this._dbSet.ToList();
        }
        #endregion

        #region UPDATE
        public Tentity Update(Tentity entity)
        {
            return this._dbSet.Update(entity).Entity;
        }
        #endregion
    }
}
