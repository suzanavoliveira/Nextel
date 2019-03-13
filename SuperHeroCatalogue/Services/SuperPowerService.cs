using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using SuperHeroCatalogue.Helpers;
using SuperHeroCatalogue.Models;

namespace SuperHeroCatalogue.Services
{
    public interface ISuperPowerService {

        IEnumerable<SuperPower> GetAll();

        SuperPower Get(int id);

        void Insert(SuperPower superHero);

        void Update(int id, SuperPower superHero);

        void Delete(int id);
    }

    public class SuperPowerService : ISuperPowerService
    {
        private SuperHeroCatalogueDb _context;
        private IAuditEventService _auditService;

        public SuperPowerService(SuperHeroCatalogueDb context, IAuditEventService auditService) {
            this._context = context;
            this._auditService = auditService;
        }

        public void Delete(int id) {
            try {

                var superPower = Get(id);

                if (superPower == null) {
                    throw new AppException("Super Power not found to delete");
                }

                if (_context.SuperHeroes.Any(sh => sh.SuperPowers.Any(sp=>sp.Id.Equals(id)))) {
                    throw new AppException("Cannot delete a Super Power related to a Super Hero");
                }

                _context.SuperPowers.Remove(superPower);

                _auditService.Save(new AuditEvent { CreatedDate = DateTime.Now, Action = "Delete", Entity = "SuperPower", Id = id });
            }
            catch (AppException ex)
            {
                throw ex;
            }
        }

        public SuperPower Get(int id)
        {
            try {
                var superPower = _context.SuperPowers.Find(id);
                return superPower;
            }
            catch (AppException ex) {
                throw ex;
            }
        }

        public IEnumerable<SuperPower> GetAll()
        {
            try {
                var superPowers = _context.SuperPowers.ToList();

                return superPowers;
            }
            catch (AppException ex) { 
                throw ex;
            }
        }

        public IEnumerable<SuperPower> GetAllPaginated(int numberOfObjectsPerPage, int pageNumber)
        {
            try
            {
                var superPowers = _context.SuperPowers.ToList();

                return superPowers
                    .Skip(numberOfObjectsPerPage * pageNumber)
                    .Take(numberOfObjectsPerPage); ;
            }
            catch (AppException ex)
            {
                throw ex;
            }
        }

        public void Insert(SuperPower superPower) {
            _context.SuperPowers.Add(superPower);
            _context.SaveChanges();
            _auditService.Save(new AuditEvent { CreatedDate = DateTime.Now, Action = "Insert", Entity = "SuperPower", Id = superPower.Id });
        }

        public void Update(int id, SuperPower superPower) {
            if (id != superPower.Id) {
                throw new Exception("Cannot update with different ids");
            }

            _context.Entry(superPower).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();

                _auditService.Save(new AuditEvent { CreatedDate = DateTime.Now, Action = "Update", Entity = "SuperPower", Id = superPower.Id });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new AppException("Cannot find a super hero to upload");
            }
        }
    }
}
