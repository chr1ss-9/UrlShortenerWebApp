using Microsoft.EntityFrameworkCore;

namespace UrlShortenerWebApp.Models {
    public class UrlShortenerContext : DbContext {
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options)
        : base(options) {
        }

        public DbSet<ShortUrl> ShortUrls { get; set; }
    }
}
