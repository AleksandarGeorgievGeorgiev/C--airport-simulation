namespace ProCP.Services
{
    public class LoggingConstants
    {
        public static string PrimarySecurityCheckFailed => "PcsValidationFailed";
        public static string PrimarySecurityCheckSucceeded => "PcsCheckSucceeded";
        public static string BagStaysInSecurity => "Bag doesn't leave security because it is not secure";

        public static string BagReceivedText = "Bag received in";
        public static string BagTransporterIdText = "Transporter id";
        public static string BagReceivedInTemplate = BagReceivedText + " {0}, " + " by transporting node with " + BagTransporterIdText + " {1}";
    }
}