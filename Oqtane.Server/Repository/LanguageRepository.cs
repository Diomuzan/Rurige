using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Oqtane.Models;

namespace Oqtane.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private TenantDBContext _db;

        public LanguageRepository(TenantDBContext context)
        {
            _db = context;
        }

        public IEnumerable<Language> GetLanguages(int siteId)
        {
            return _db.Language.Where(l => l.SiteId == siteId);
        }

        public Language AddLanguage(Language language)
        {
            if (language.IsDefault)
            {
                // Ensure all other languages are not set to default
                _db.Language
                    .Where(l => l.SiteId == language.SiteId)
                    .ToList()
                    .ForEach(l => l.IsDefault = false);
            }

            _db.Language.Add(language);
            _db.SaveChanges();

            return language;
        }

        public void UpdateLanguage(Language language)
        {
            if (language.LanguageId != 0)
            {
                _db.Entry(language).State = EntityState.Modified;
            }
            if (language.IsDefault)
            {
                // Ensure all other languages are not set to default
                _db.Language
                    .Where(l => l.SiteId == language.SiteId &&
                                l.LanguageId != language.LanguageId)
                    .ToList()
                    .ForEach(l => l.IsDefault = false);
            }

            _db.SaveChanges();
        }

        public Language GetLanguage(int languageId)
        {
            return _db.Language.Find(languageId);
        }

        public void DeleteLanguage(int languageId)
        {
            var language = _db.Language.Find(languageId);
            _db.Language.Remove(language);
            _db.SaveChanges();
        }
    }
}
