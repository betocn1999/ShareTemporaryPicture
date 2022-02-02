using System.ComponentModel.DataAnnotations;

namespace ShareTemporaryPicture.Models.Enums
{ 
    public enum S3BucketShareTemporaryPictureParameters
    {
        [Display(Name = "S3BucketShareTemporaryPicture:BucketName")]
        BucketName,
        [Display(Name = "S3BucketShareTemporaryPicture:Path")]
        Path,
    }
}
