namespace Common
{
    public class LanguageObject
    {
        public LanguageObject() {}
        public LanguageObject(string en, string ar) 
        {
            En = en;
            Ar = ar;
        }


        public string En {  get; set; }

        public string Ar { get; set; }
    }
}