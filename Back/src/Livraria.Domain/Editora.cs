namespace Livraria.Domain
{
    public class Editora
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Editora(int id, string nome){
            this.Id = id;
            this.Nome = nome;
        }
        public Editora(){

        }
    }

}
