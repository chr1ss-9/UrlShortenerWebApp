﻿namespace UrlShortenerWebApp.Models {
    public class ShortUrl {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
    }
}
