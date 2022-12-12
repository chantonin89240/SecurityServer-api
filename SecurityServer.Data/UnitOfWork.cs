using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SecurityServer.Data.Repository;
using SecurityServer.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data
{
    public class UnitOfWork<Tcontext> : IUnitOfWork<Tcontext>, IDisposable where Tcontext : SecurityServerDbContext
    {
        private readonly Tcontext _context;
        private bool _disposed;
        private string _errorMessage = string.Empty;
        // dictionnaire des repositories 
        private Dictionary<string, object> _repositories;
        // objet transaction
        private IDbContextTransaction _objTran;

        // constructeur qui récupère et ajoute application repository dans le dictionnaire repositories
        public IApplicationRepository ApplicationRepository
        {
            get {
                if (!_repositories.ContainsKey(nameof(ApplicationRepository))) _repositories.Add(nameof(ApplicationRepository), new ApplicationRepository(_context));
                return (ApplicationRepository)_repositories[nameof(ApplicationRepository)];
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (!_repositories.ContainsKey(nameof(UserRepository))) _repositories.Add(nameof(UserRepository), new UserRepository(_context));
                return (UserRepository)_repositories[nameof(UserRepository)];
            }
        }

        //public ClaimRepository Claim { get; set; }
        //public RoleRepository Role { get; set; }

        // constructeur
        public UnitOfWork(Tcontext tcontext)
        {
            this._context = tcontext;
            this._repositories= new Dictionary<string, object>();
        }

        // méthode qui renvoie l'objet DbContext
        public Tcontext Context
        {
            get { return _context; }
        }

        // IDisposable est un mécanisme pour libérer des ressources non gérées.
        // méthode pour libérer les ressources non gérées
        public void Dispose()
        {
            Dispose(_disposed: true);
            // garbage collector récupère la mémoire utilisée par les objets managés
            // supressFinalize demande de ne pas appeller le finaliseur pour l'objet spécifié
            GC.SuppressFinalize(this);
        }

        // 
        protected void Dispose(bool _disposed)
        {
            if (!_disposed)
                if (_disposed)
                    _context.Dispose();
            _disposed = true;
        }

        // méthode de création de transaction
        public void CreateTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }

        // méthode pour sauvegarder les changements de façon permanente dans la bdd, la méthode doit être appeller si les transaction sont terminées avec succées 
        public void Commit()
        {
            _objTran.Commit();
        }

        // méthode d'annulation des changement, appeler si une transaction à échoué 
        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        // méthode d'enregistrement qui implémente la méthode SaveChange du DbContext, la méthode doit être appelé à chaque fois qu'une transaction est effectué  
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch { }
        }

        
    }
}
