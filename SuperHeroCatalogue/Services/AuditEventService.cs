using SuperHeroCatalogue;
using SuperHeroCatalogue.Models;

namespace SuperHeroCatalogue.Services
{
    public interface IAuditEventService {
        void Save(AuditEvent auditEvent);
    }

    public class AuditEventService : IAuditEventService
    {
        private SuperHeroCatalogueDb _context;

        public AuditEventService(SuperHeroCatalogueDb context) {
            this._context = context;
        }

        public void Save(AuditEvent auditEvent) {
            _context.AuditEvents.Add(auditEvent);
            _context.SaveChanges();            
        }
    }
}
