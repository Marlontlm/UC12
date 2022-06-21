namespace cadastroPessoa.classes
{
    public class Endereco
    {
        public string? logradouro { get;set; }

        public int? numero { get;set; }

        public string? cidade { get;set; }

        public bool endComercial { get; set; }

        
        public override string ToString() {
            return "Endereço: " + this.logradouro + " " + this.numero + ", " + this.cidade + ". Endereço comercial? " + ((bool)this.endComercial ? "Sim" : "Não");
        }
    }

}