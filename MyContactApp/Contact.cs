namespace MyContactApp
{
    public class Contact
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return "Nome: "+ Name + " Descrição: "+ Description;
        }
    }
}
