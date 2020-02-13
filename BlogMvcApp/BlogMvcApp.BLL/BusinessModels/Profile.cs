namespace BlogMvcApp.BLL.BusinessModels
{
    public class Profile
    {
        public bool IsStable { get; set; }
        public bool IsAlone { get; set; }

        public Profile(bool isStable, bool isAlone)
        {
            IsStable = isStable;
            IsAlone = isAlone;
        }

        public bool GetResultBool()
        {
            return IsStable || IsAlone;
        }
    }
}
