namespace BlogEngineApi.Domain.Statics
{
    public class PostStatus
    {
        //TODO: Create a extension for string that addds a space when a uppercase is found,
        ///which would allow usage of nameof() function in all cases
        public static string PendingSubmit = "Pending Submit";
        public static string PendingApproval = "Pending Approval";
        public static string Published = nameof(Published);
        public static string Rejected = nameof(Rejected);
    }
}