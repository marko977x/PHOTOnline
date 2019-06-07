namespace PHOTOnline.Business.UserManagement.Input
{
    public class UpdatePasswordInput
    {
        public string UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
