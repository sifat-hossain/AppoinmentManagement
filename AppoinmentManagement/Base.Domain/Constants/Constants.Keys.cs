namespace Base.Domain.Constants;

public static partial class Constants
{
    public static class Keys
    {
        public const string Authorization = nameof(Authorization);

        public const string Bearer = nameof(Bearer);

        public static class VehicleCheckAnswerValue
        {
            public const string Yes = "Yes";
            public const string Defect = "Defect";
            public const string NotAnswered = "Not Answered";
        }
    }
}