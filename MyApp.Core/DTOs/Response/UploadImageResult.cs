﻿namespace MyApp.Core.DTOs.Response
{
    public class UploadImageResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string? ImageUrl { get; set; }
    }
}
