
namespace JFW.Sdk.Constants;

/// <summary>
/// Provides a comprehensive collection of MIME type constants for common file formats.
/// MIME types are used to specify the nature and format of documents, files, or assortments of bytes.
/// </summary>
/// <remarks>
/// This class contains constants for the most commonly used MIME types organized by category.
/// Use these constants to ensure consistency when setting Content-Type headers or validating file uploads.
/// </remarks>
public static class MimeTypes
{
    #region Text Types

    /// <summary>
    /// MIME type for plain text files (.txt)
    /// </summary>
    public const string TextPlain = "text/plain";

    /// <summary>
    /// MIME type for HTML documents (.html, .htm)
    /// </summary>
    public const string TextHtml = "text/html";

    /// <summary>
    /// MIME type for CSS stylesheets (.css)
    /// </summary>
    public const string TextCss = "text/css";

    /// <summary>
    /// MIME type for JavaScript files (.js)
    /// </summary>
    public const string TextJavaScript = "text/javascript";

    /// <summary>
    /// MIME type for CSV (Comma-Separated Values) files (.csv)
    /// </summary>
    public const string TextCsv = "text/csv";

    /// <summary>
    /// MIME type for XML documents (.xml)
    /// </summary>
    public const string TextXml = "text/xml";

    #endregion

    #region Application Types

    /// <summary>
    /// MIME type for JSON (JavaScript Object Notation) data (.json)
    /// </summary>
    public const string ApplicationJson = "application/json";

    /// <summary>
    /// MIME type for XML application data (.xml)
    /// </summary>
    public const string ApplicationXml = "application/xml";

    /// <summary>
    /// MIME type for PDF (Portable Document Format) files (.pdf)
    /// </summary>
    public const string ApplicationPdf = "application/pdf";

    /// <summary>
    /// MIME type for ZIP archive files (.zip)
    /// </summary>
    public const string ApplicationZip = "application/zip";

    /// <summary>
    /// MIME type for generic binary data or unknown file types
    /// </summary>
    public const string ApplicationOctetStream = "application/octet-stream";

    /// <summary>
    /// MIME type for URL-encoded form data
    /// </summary>
    public const string ApplicationFormUrlEncoded = "application/x-www-form-urlencoded";

    /// <summary>
    /// MIME type for multipart form data (typically used for file uploads)
    /// </summary>
    public const string MultipartFormData = "multipart/form-data";

    /// <summary>
    /// MIME type for RAR archive files (.rar)
    /// </summary>
    public const string ApplicationRar = "application/vnd.rar";

    /// <summary>
    /// MIME type for 7-Zip archive files (.7z)
    /// </summary>
    public const string Application7Zip = "application/x-7z-compressed";

    #endregion

    #region Image Types

    /// <summary>
    /// MIME type for JPEG image files (.jpg, .jpeg)
    /// </summary>
    public const string ImageJpeg = "image/jpeg";

    /// <summary>
    /// MIME type for PNG (Portable Network Graphics) image files (.png)
    /// </summary>
    public const string ImagePng = "image/png";

    /// <summary>
    /// MIME type for GIF (Graphics Interchange Format) image files (.gif)
    /// </summary>
    public const string ImageGif = "image/gif";

    /// <summary>
    /// MIME type for BMP (Bitmap) image files (.bmp)
    /// </summary>
    public const string ImageBmp = "image/bmp";

    /// <summary>
    /// MIME type for WebP image files (.webp)
    /// </summary>
    public const string ImageWebp = "image/webp";

    /// <summary>
    /// MIME type for SVG (Scalable Vector Graphics) image files (.svg)
    /// </summary>
    public const string ImageSvg = "image/svg+xml";

    /// <summary>
    /// MIME type for ICO (Icon) image files (.ico)
    /// </summary>
    public const string ImageIcon = "image/x-icon";

    /// <summary>
    /// MIME type for TIFF (Tagged Image File Format) image files (.tiff, .tif)
    /// </summary>
    public const string ImageTiff = "image/tiff";

    #endregion

    #region Audio Types

    /// <summary>
    /// MIME type for MP3 audio files (.mp3)
    /// </summary>
    public const string AudioMpeg = "audio/mpeg";

    /// <summary>
    /// MIME type for WAV audio files (.wav)
    /// </summary>
    public const string AudioWav = "audio/wav";

    /// <summary>
    /// MIME type for OGG audio files (.ogg)
    /// </summary>
    public const string AudioOgg = "audio/ogg";

    /// <summary>
    /// MIME type for WebM audio files (.weba)
    /// </summary>
    public const string AudioWebm = "audio/webm";

    /// <summary>
    /// MIME type for AAC audio files (.aac)
    /// </summary>
    public const string AudioAac = "audio/aac";

    #endregion

    #region Video Types

    /// <summary>
    /// MIME type for MP4 video files (.mp4)
    /// </summary>
    public const string VideoMp4 = "video/mp4";

    /// <summary>
    /// MIME type for MPEG video files (.mpeg)
    /// </summary>
    public const string VideoMpeg = "video/mpeg";

    /// <summary>
    /// MIME type for WebM video files (.webm)
    /// </summary>
    public const string VideoWebm = "video/webm";

    /// <summary>
    /// MIME type for OGG video files (.ogv)
    /// </summary>
    public const string VideoOgg = "video/ogg";

    /// <summary>
    /// MIME type for AVI video files (.avi)
    /// </summary>
    public const string VideoAvi = "video/x-msvideo";

    /// <summary>
    /// MIME type for QuickTime video files (.mov)
    /// </summary>
    public const string VideoQuicktime = "video/quicktime";

    #endregion

    #region Microsoft Office Types

    /// <summary>
    /// MIME type for Microsoft Word documents (.doc)
    /// </summary>
    public const string ApplicationMsWord = "application/msword";

    /// <summary>
    /// MIME type for Microsoft Word documents (.docx)
    /// </summary>
    public const string ApplicationMsWordOpenXml = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

    /// <summary>
    /// MIME type for Microsoft Excel spreadsheets (.xls)
    /// </summary>
    public const string ApplicationMsExcel = "application/vnd.ms-excel";

    /// <summary>
    /// MIME type for Microsoft Excel spreadsheets (.xlsx)
    /// </summary>
    public const string ApplicationMsExcelOpenXml = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

    /// <summary>
    /// MIME type for Microsoft PowerPoint presentations (.ppt)
    /// </summary>
    public const string ApplicationMsPowerPoint = "application/vnd.ms-powerpoint";

    /// <summary>
    /// MIME type for Microsoft PowerPoint presentations (.pptx)
    /// </summary>
    public const string ApplicationMsPowerPointOpenXml = "application/vnd.openxmlformats-officedocument.presentationml.presentation";

    #endregion

    #region Font Types

    /// <summary>
    /// MIME type for TrueType font files (.ttf)
    /// </summary>
    public const string FontTtf = "font/ttf";

    /// <summary>
    /// MIME type for OpenType font files (.otf)
    /// </summary>
    public const string FontOtf = "font/otf";

    /// <summary>
    /// MIME type for WOFF (Web Open Font Format) font files (.woff)
    /// </summary>
    public const string FontWoff = "font/woff";

    /// <summary>
    /// MIME type for WOFF2 (Web Open Font Format 2) font files (.woff2)
    /// </summary>
    public const string FontWoff2 = "font/woff2";
    #endregion

    /// <summary>
    /// Gets a dictionary mapping common file extensions to their corresponding MIME types.
    /// </summary>
    /// <returns>A dictionary where keys are file extensions (with leading dot) and values are MIME types.</returns>
    /// <example>
    /// <code>
    /// var mimeType = MimeTypes.GetMimeTypeByExtension(".pdf");
    /// // Returns: "application/pdf"
    /// </code>
    /// </example>
    public static Dictionary<string, string> GetExtensionMap()
    {
        return new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase)
            {
                // Text
                { ".txt", TextPlain },
                { ".html", TextHtml },
                { ".htm", TextHtml },
                { ".css", TextCss },
                { ".js", TextJavaScript },
                { ".csv", TextCsv },
                { ".xml", TextXml },

                // Application
                { ".json", ApplicationJson },
                { ".pdf", ApplicationPdf },
                { ".zip", ApplicationZip },
                { ".rar", ApplicationRar },
                { ".7z", Application7Zip },

                // Images
                { ".jpg", ImageJpeg },
                { ".jpeg", ImageJpeg },
                { ".png", ImagePng },
                { ".gif", ImageGif },
                { ".bmp", ImageBmp },
                { ".webp", ImageWebp },
                { ".svg", ImageSvg },
                { ".ico", ImageIcon },
                { ".tiff", ImageTiff },
                { ".tif", ImageTiff },

                // Audio
                { ".mp3", AudioMpeg },
                { ".wav", AudioWav },
                { ".ogg", AudioOgg },
                { ".aac", AudioAac },

                // Video
                { ".mp4", VideoMp4 },
                { ".mpeg", VideoMpeg },
                { ".webm", VideoWebm },
                { ".ogv", VideoOgg },
                { ".avi", VideoAvi },
                { ".mov", VideoQuicktime },

                // Microsoft Office
                { ".doc", ApplicationMsWord },
                { ".docx", ApplicationMsWordOpenXml },
                { ".xls", ApplicationMsExcel },
                { ".xlsx", ApplicationMsExcelOpenXml },
                { ".ppt", ApplicationMsPowerPoint },
                { ".pptx", ApplicationMsPowerPointOpenXml },

                // Fonts
                { ".ttf", FontTtf },
                { ".otf", FontOtf },
                { ".woff", FontWoff },
                { ".woff2", FontWoff2 }
            };
    }

    /// <summary>
    /// Gets the MIME type for a given file extension.
    /// </summary>
    /// <param name="extension">The file extension (with or without leading dot).</param>
    /// <returns>The corresponding MIME type, or application/octet-stream if not found.</returns>
    /// <example>
    /// <code>
    /// var mimeType = MimeTypes.GetMimeTypeByExtension(".json");
    /// // Returns: "application/json"
    /// 
    /// var unknownType = MimeTypes.GetMimeTypeByExtension(".unknown");
    /// // Returns: "application/octet-stream"
    /// </code>
    /// </example>
    public static string GetMimeTypeByExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
            return ApplicationOctetStream;

        // Ensure extension starts with a dot
        if (!extension.StartsWith("."))
            extension = "." + extension;

        var map = GetExtensionMap();
        return map.TryGetValue(extension, out var mimeType)
            ? mimeType
            : ApplicationOctetStream;
    }

    /// <summary>
    /// Gets the MIME type for a given filename by extracting its extension.
    /// </summary>
    /// <param name="filename">The filename or file path.</param>
    /// <returns>The corresponding MIME type, or application/octet-stream if not found.</returns>
    /// <example>
    /// <code>
    /// var mimeType = MimeTypes.GetMimeTypeByFilename("document.pdf");
    /// // Returns: "application/pdf"
    /// 
    /// var mimeType2 = MimeTypes.GetMimeTypeByFilename("/path/to/image.png");
    /// // Returns: "image/png"
    /// </code>
    /// </example>
    public static string GetMimeTypeByFilename(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
            return ApplicationOctetStream;

        var extension = System.IO.Path.GetExtension(filename);
        return GetMimeTypeByExtension(extension);
    }
}
