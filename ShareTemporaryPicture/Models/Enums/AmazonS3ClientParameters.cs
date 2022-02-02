using System.ComponentModel.DataAnnotations;

namespace ShareTemporaryPicture.Models.Enums
{ 
    public enum AmazonS3ClientParameters
    {
        [Display(Name = "AmazonS3Client:AwsAccessKeyId")]
        AwsAccessKeyId,
        [Display(Name = "AmazonS3Client:AwsSecretAccessKey")]
        AwsSecretAccessKey,
    }
}
