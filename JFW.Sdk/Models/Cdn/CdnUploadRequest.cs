
namespace JFW.Sdk.Models;

/// <summary>
/// The cdn upload request model
/// </summary>
public class CdnUploadRequest
{
    /// <summary>
    /// This contains the file to upload.
    /// </summary>
    public Stream UploadFile { get; set; } = null!;

    /// <summary>
    /// This is used to change the saving file name. E.g. "profile.jpg", "feedback.png", etc.
    /// Note: If this is not set, the file name will be the same as the uploaded file name.
    /// </summary>
    public string? FileName { get; set; }

    /// <summary>
    /// This is the prefix folder before the file name. E.g. "profile", "assets", etc.
    /// </summary>
    public string? PrefixFolder { get; set; }

    /// <summary>
    /// This is the object reference of the uploaded file. This is used to reference the object.
    /// </summary>
    public string? RefObject { get; set; }

    /// <summary>
    /// This is the reference id of the uploaded file. This is used to reference the Id of the object.
    /// </summary>
    public long? RefId { get; set; }

    /// <summary>
    /// This is the notes of the uploaded file. E.g. "Profile picture", "Feedback screenshot", etc.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// This is the tags of the uploaded file. E.g. "#MyProfile", "#Feedback", etc.
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// This is the z-order of the uploaded file.
    /// By default, the value is 0.
    /// E.g. 1, 2, 3, etc.
    /// </summary>
    public long? ZOrder { get; set; } = 0;

    /// <summary>
    /// This is the root folder of the uploaded file in the CDN. By default, it is set to "User".
    /// For further information, visit here: https://help.jframework.io/other-concepts/cdn/cdn-storage
    /// </summary>
    public CdnPathType? CdnPathType { get; set; } = Constants.CdnPathType.User;

    /// <summary>
    /// The test mode of the file upload.
    /// </summary>
    public bool TestMode { get; set; } = false;

    /// <summary>
    /// Converts the CDN upload request to MultipartFormDataContent for API upload.
    /// </summary>
    /// <returns>A MultipartFormDataContent instance ready for use with the HTTP helper.</returns>
    /// <exception cref="ArgumentNullException">Thrown when UploadFile is null.</exception>
    /// <exception cref="ArgumentException">Thrown when UploadFile stream cannot be read.</exception>
    /// <example>
    /// <code>
    /// var request = new CdnUploadRequest
    /// {
    ///     UploadFile = fileStream,
    ///     FileName = "avatar.jpg",
    ///     PrefixFolder = "profiles",
    ///     RefObject = "User",
    ///     RefId = 12345
    /// };
    /// 
    /// var multipartData = request.ToMultipartFormData();
    /// var httpContent = HttpHelper.CreateContent(multipartData, MimeTypes.MultipartFormData);
    /// </code>
    /// </example>
    public MultipartFormDataContent ToMultipartFormData()
    {
        if (UploadFile == null)
            throw new ArgumentNullException(nameof(UploadFile), "UploadFile stream cannot be null.");

        if (!UploadFile.CanRead)
            throw new ArgumentException("UploadFile stream must be readable.", nameof(UploadFile));

        var multipartData = new MultipartFormDataContent();

        // Add the file - use the specified FileName or default to "file"
        var fileName = FileName ?? "file";
        var fileContent = FileContent.FromStream(fileName, UploadFile);
        multipartData.AddFile("UploadFile", fileContent);

        // Add optional text fields only if they have values
        if (!string.IsNullOrWhiteSpace(FileName))
            multipartData.AddField(nameof(FileName), FileName);

        if (!string.IsNullOrWhiteSpace(PrefixFolder))
            multipartData.AddField(nameof(PrefixFolder), PrefixFolder);

        if (!string.IsNullOrWhiteSpace(RefObject))
            multipartData.AddField(nameof(RefObject), RefObject);

        if (RefId.HasValue)
            multipartData.AddField(nameof(RefId), RefId.Value.ToString());

        if (!string.IsNullOrWhiteSpace(Notes))
            multipartData.AddField(nameof(Notes), Notes);

        if (!string.IsNullOrWhiteSpace(Tags))
            multipartData.AddField(nameof(Tags), Tags);

        if (ZOrder.HasValue)
            multipartData.AddField(nameof(ZOrder), ZOrder.Value.ToString());

        if (CdnPathType.HasValue)
            multipartData.AddField(nameof(CdnPathType), CdnPathType.Value.ToString());

        multipartData.AddField(nameof(TestMode), TestMode.ToString().ToLower());

        return multipartData;
    }
}