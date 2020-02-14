namespace BlogMvcApp.DLL.Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsAlone { get; set; }
        public bool IsStable { get; set; }
        public string Language { get; set; }
    }
}
