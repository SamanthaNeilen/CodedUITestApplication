using CodedUITestApplication.Shared.Constants;
using CodedUITestApplication.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace CodedUITestApplication.Shared.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.Name))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.EmailAdress))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [RegularExpression(RegularExpressions.EmailRegularExpression, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.InvalidEmailAdress))]
        public string EmailAdress { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.PhoneNumber))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        [MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [RegularExpression(RegularExpressions.DutchPhoneNumberRegularExpression, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.InvalidPhonenumber))]
        public string PhoneNumber { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.Street))]
        [MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        public string Street { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.HouseNumber))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        [RegularExpression(RegularExpressions.NumericRegularExpression, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.InvalidHouseNumber))]
        public int HouseNumber { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.HouseNumberExtension))]
        [MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        public string HouseNumberExtension { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.ZipCode))]
        [MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        [RegularExpression(RegularExpressions.DutchZipCodeRegularExpression, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.InvalidZipCode))]
        public string ZipCode { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.City))]
        [MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        public string City { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.Country))]
        [MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        public string Country { get; set; }
    }
}
