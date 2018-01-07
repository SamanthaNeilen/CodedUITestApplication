namespace CodedUITestApplication.Shared.Constants
{
    public static class RegularExpressions
    {
        public const string EmailRegularExpression = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,6})+)$";
        public const string DutchZipCodeRegularExpression = "^[1-9][0-9]{3}([A-Z]{2})$";
        public const string DutchPhoneNumberRegularExpression = "^(((0)[1-9]{2}[0-9][-]?[1-9][0-9]{5})|((\\+31|0|0031)[1-9][0-9][-]?[1-9][0-9]{6}))$";
        public const string NumericRegularExpression = "^([0-9]*)$";
    }
}
