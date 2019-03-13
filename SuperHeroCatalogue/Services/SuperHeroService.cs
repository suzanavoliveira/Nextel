using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using SuperHeroCatalogue.Helpers;
using SuperHeroCatalogue.Models;
using SuperHeroCatalogue;

namespace SuperHeroCatalogue.Services
{
    public interface ISuperHeroService {

        IEnumerable<SuperHero> GetAll();

        IEnumerable<SuperHero> GetAllPaginated(int numberOfPages, int pageNumber);

        SuperHero Get(int id);

        void Insert(SuperHero superHero);

        void Update(int id, SuperHero superHero);

        void Delete(int id);
    }

    public class SuperHeroService : ISuperHeroService
    {
        private SuperHeroCatalogueDb _context;
        private AuditEventService _auditService;

        public SuperHeroService(SuperHeroCatalogueDb context, AuditEventService auditService) {
            this._context = context;
            this._auditService = auditService;
        }

        public void Delete(int id) {
            try {
                var superHero = Get(id);

                if (superHero == null) {
                    throw new Exception("Super Hero not found to delete");
                }

                _context.SuperHeroes.Remove(superHero);

                _auditService.Save(new AuditEvent { CreatedDate = DateTime.Now, Action = "Delete", Entity = "SuperHero", Id = id });
            }
            catch (AppException) {
                throw new AppException("Super Hero cannot be deleted");
            }
        }

        public SuperHero Get(int id)
        {
            try {
                var superHero = _context.SuperHeroes.Find(id);

                return superHero;
            }
            catch (AppException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<SuperHero> GetAll()
        {
            try
            {
                var superHeroes = _context.SuperHeroes.ToList();

                return superHeroes;
            }
            catch (AppException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<SuperHero> GetAllPaginated(int numberOfObjectsPerPage, int pageNumber)
        {
            try
            {
                var superHeroes = _context.SuperHeroes.ToList();

                return superHeroes
                    .Skip(numberOfObjectsPerPage * pageNumber)
                    .Take(numberOfObjectsPerPage); ;
            }
            catch (AppException ex)
            {
                throw ex;
            }
        }

        public void Insert(SuperHero superHero)
        {
            _context.SuperHeroes.Add(superHero);
            _context.SaveChanges();

            _auditService.Save(new AuditEvent { CreatedDate = DateTime.Now, Action = "Create", Entity = "SuperHero", Id = superHero.Id });
        }

        public void Update(int id, SuperHero superHero)
        {
            if (id != superHero.Id) {
                throw new Exception("Cannot update with different ids");
            }

            _context.Entry(superHero).State = EntityState.Modified;

            try {
                _context.SaveChanges();

                _auditService.Save(new AuditEvent { CreatedDate = DateTime.Now, Action = "Update", Entity = "SuperHero", Id = superHero.Id });
            }
            catch (DbUpdateConcurrencyException) {
                throw new Exception("Cannot find a super hero to upload"); 
            }
        }
    }


}
