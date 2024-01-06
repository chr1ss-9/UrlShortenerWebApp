using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using UrlShortenerWebApp.Models;

namespace UrlShortenerWebApp.Controllers {
    public class UrlShortenerController : Controller {
        private readonly UrlShortenerContext _context;

        public UrlShortenerController(UrlShortenerContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string url) {
            // Generate the shortened URL
            string shortenedUrl = GenerateShortenedUrl(url);

            // Pass the shortened URL to the view
            return View("ShortenedUrl", shortenedUrl);
        }

        [HttpPost]
        public IActionResult ShortenUrl(string originalUrl) {
            // Generate the short URL and save it to the database
            var shortUrl = GenerateShortenedUrl(originalUrl);
            var newUrl = new ShortUrl {
                OriginalUrl = originalUrl,
                ShortenedUrl = shortUrl
            };
            _context.ShortUrls.Add(newUrl);
            _context.SaveChanges();

            return RedirectToAction("ShortUrl", new { shortenedUrl = UrlEncoder.Default.Encode(shortUrl) });
        }

        [HttpGet("{shortenedUrl}")]
        public IActionResult ShortUrl(string shortenedUrl) {
            // Retrieve the original URL using the GetOriginalUrl method
            var originalUrl = GetOriginalUrl(shortenedUrl);

            if (originalUrl == null) {
                // Handle the case where the original URL is not found
                return NotFound();
            }

            // Redirect to the original URL
            return Redirect(originalUrl);
        }

        private string GenerateShortenedUrl(string originalUrl) {
            // Generate a hash of the original URL
            using (SHA256 sha256Hash = SHA256.Create()) {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(originalUrl));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < data.Length; i++) {
                    builder.Append(data[i].ToString("x2"));
                }
                string hash = builder.ToString();

                // Take a portion of the hash as the shortened URL
                string shortenedUrl = hash.Substring(0, 8); // You can adjust the length as needed

                return shortenedUrl;
            }
        }
        private string GetOriginalUrl(string shortenedUrl) {
            // Reverse the process of generating the shortened URL
            string hash = shortenedUrl;

            // Reconstruct the original URL from the hash
            string originalUrl = Encoding.UTF8.GetString(StringToByteArray(hash));

            return originalUrl;
        }

        private static byte[] StringToByteArray(string hex) {
            int length = hex.Length;
            if (length % 2 != 0) {
                throw new ArgumentException("The input string must have an even number of characters.");
            }

            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2) {
                string substring = hex.Substring(i, 2);
                if (int.TryParse(substring, NumberStyles.HexNumber, null, out int intValue)) {
                    bytes[i / 2] = (byte)intValue;
                } else {
                    // Skip non-hexadecimal characters
                    continue;
                }
            }
            return bytes;
        }
    }
}
