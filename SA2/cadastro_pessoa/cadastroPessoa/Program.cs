using cadastroPessoa.classes;

Console.Clear();
Console.WriteLine(@$"
---------------------------------------------
|   Bem vindo ao sistema de cadastro de     |
|       Pessoas Físicas e Jurídicas         |
---------------------------------------------
");

Console.Write("Carregando ");
Console.BackgroundColor = ConsoleColor.White;

for (var i = 0; i < 10; i++)
{
    Console.Write(". ");
    Thread.Sleep(500);
}

Console.ResetColor();
List<PessoaFisica> listaPF = new List<PessoaFisica>();
//List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();

string? opcao;

do 
{
    Console.Clear();
    Console.WriteLine(@$"
---------------------------------------------
|       Escolha uma das opções abaixo:      |
|-------------------------------------------|
|       1 - Pessoa Física                   |
|       2 - Pessoa Jurídica                 |
|                                           |
|       0 - Sair do Sistema                 |
---------------------------------------------
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            //cria um novo objeto 
            PessoaFisica metodoPF = new PessoaFisica();

            string? opcaoPF;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
---------------------------------------------
|       Escolha uma das opções abaixo:      |
|-------------------------------------------|
|       1 - Cadastrar Pessoa Física         |
|       2 - Listar Pessoas Cadastradas      |
|                                           |
|       0 - Voltar ao Menu anterior         |
---------------------------------------------
");

            opcaoPF = Console.ReadLine();

            switch (opcaoPF)
            {
                case "1":
                    PessoaFisica novaPF = new PessoaFisica();
                    Endereco novoEndPF = new Endereco();

                    Console.Clear();

                    Console.WriteLine("Digite o nome da Pessoa Física que deseja cadastrar:");
                    novaPF.nome = Console.ReadLine();
                    
                    bool dataValida;
                    do
                    {
                        Console.WriteLine("Digite a data de nascimento no formato DD/MM/AAAA:");
                        string? dataNasc = Console.ReadLine();

                        dataValida = metodoPF.ValidarDataNascimento(dataNasc);
                        if (dataValida)
                        {
                            novaPF.dataNascimento = dataNasc;
                        } else 
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Data Inválida! Por favor digite uma data válida.");
                            Console.ResetColor();
                        }
                    } while (dataValida == false);

                    
                    Console.WriteLine("Digite o CPF:");
                    novaPF.cpf = Console.ReadLine();

                    Console.WriteLine("Digite o rendimento (utilize apenas números):");
                    novaPF.rendimento = float.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o endereço");
                    Console.WriteLine("Logradouro:");
                    novaPF.endereco = novoEndPF;
                    novoEndPF.logradouro = Console.ReadLine();

                    Console.WriteLine("Número:");
                    novoEndPF.numero = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Cidade:");
                    novoEndPF.cidade = Console.ReadLine();

                    Console.WriteLine("Este endereço é comercial? S/N");
                    string? endCom = Console.ReadLine().ToLower();

                    if (endCom == "S")
                    {
                        novoEndPF.endComercial = true;
                    } else
                    {
                        novoEndPF.endComercial = false;
                    }

                    //listaPF.Add(novaPF);

                    //Cria o arquivo .txt e escreve no arquivo         
                    /*StreamWriter sw = new StreamWriter($"{novaPF.nome}.txt");
                    sw.Write(novaPF.nome);
                    sw.Close();*/

                    //Usando método Using com StreamWriter
                    using (StreamWriter sw = new StreamWriter($"{novaPF.nome}.txt"))
                    {
                        sw.WriteLine(@$"Nome:{novaPF.nome}
Data de Nascimento: {novaPF.dataNascimento}
CPF: {novaPF.cpf} 
{novaPF.endereco}
Rendimento: {novaPF.rendimento}");
                   }

                    Console.WriteLine("Cadastro realizado com sucesso!");
                    Thread.Sleep(3000);
                    break;

                    case "2":
                        Console.Clear();
                    
//                         if (listaPF.Count > 0)
//                         {
//                             foreach (PessoaFisica cadaPessoa in listaPF)
//                             {
//                                 Console.WriteLine(@$"
// Nome: {cadaPessoa.nome}
// Data de Nacimento: {cadaPessoa.dataNascimento}
// {cadaPessoa.endereco}
// Rendimento: {(cadaPessoa.rendimento).ToString("C")}
// Taxa de imposto a ser paga: {metodoPF.PagarImposto(cadaPessoa.rendimento).ToString("C")}"
//         );
//                             Console.WriteLine(@"Aperte 'Enter' para continuar!");
//                             Console.ReadLine();
//                             }
//                         } else
//                         {
//                             Console.WriteLine("Lista vazia!");
//                             Thread.Sleep(2000);
                        //}
                        
                        //Usando método Using com StreamReader
                        using (StreamReader sr = new StreamReader("ana.txt"))
                        {
                          string linha;
                          while ((linha = sr.ReadLine()) != null)
                          {
                            Console.WriteLine($"{linha}");
                              
                          }  
                        }
                         Console.WriteLine(@"Aperte 'Enter' para continuar!");
                         Console.ReadLine();

                    break;
                    case "0":
                    break;
                    default:
                    Console.Clear();
                    Console.WriteLine($"Opção Inválida. Digite outra opção");
                    Thread.Sleep(2000);
                    break;
            } 
            } while (opcaoPF != "0"); 

        break;  

        case "2":
            PessoaJuridica metodopj = new PessoaJuridica();

            string? opcaoPJ;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
---------------------------------------------
|       Escolha uma das opções abaixo:      |
|-------------------------------------------|
|       1 - Cadastrar Pessoa Jurídica       |
|       2 - Listar Pessoas Cadastradas      |
|                                           |
|       0 - Voltar ao Menu anterior         |
---------------------------------------------
");
                opcaoPJ = Console.ReadLine();

                switch (opcaoPJ)
                    {
                        case "1":
                            PessoaJuridica novaPJ = new PessoaJuridica();
                            Endereco novoEndPJ = new Endereco();

                            Console.Clear();

                            Console.WriteLine("Digite a Razão Social da Pessoa Jurídica que deseja cadastrar:");
                            novaPJ.razaosocial = Console.ReadLine();

                            Console.WriteLine("Digite o rendimento (utilize apenas números):");
                            novaPJ.rendimento = float.Parse(Console.ReadLine());

                            Console.WriteLine("Digite o endereço");
                            Console.WriteLine("Logradouro:");
                            novaPJ.endereco = novoEndPJ;
                            novoEndPJ.logradouro = Console.ReadLine();

                            Console.WriteLine("Número:");
                            novoEndPJ.numero = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Cidade:");
                            novoEndPJ.cidade = Console.ReadLine();

                            Console.WriteLine("Este endereço é comercial? S/N");
                            string endCom = Console.ReadLine().ToLower();

                            if (endCom == "S")
                            {
                                novoEndPJ.endComercial = true;
                            } else
                            {
                                novoEndPJ.endComercial = false;
                            }

                            bool cnpjValido;
                            do
                            {
                                Console.WriteLine("Digite o CNPJ:");
                                string? cnpjTeste = Console.ReadLine();

                                cnpjValido = metodopj.ValidarCnpj(cnpjTeste);
                                if (cnpjValido)
                                {
                                    novaPJ.cnpj = cnpjTeste;
                                } else 
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("CNPJ Inválido! Por favor digite um CNPJ válido.");
                                    Console.ResetColor();
                                }
                            } while ( cnpjValido == false);

                            metodopj.Inserir(novaPJ);
                            //listaPJ.Add(novaPJ);
                            Console.WriteLine("Cadastro realizado com sucesso!");
                            Thread.Sleep(3000);
                        break;

                        case "2":  
                            Console.Clear();
                            //metodopj.Inserir(novaPJ);
                            List<PessoaJuridica> listaPj = metodopj.Ler();

                             if (listaPj.Count > 0)
                                {
                                    foreach (PessoaJuridica item in listaPj)
                                    { 
                                        Console.WriteLine($@"{item.razaosocial}");

                                        Console.WriteLine($"Aperte 'Enter' para continuar!");
                                        Console.ReadLine();
                                    } 
                                } else
                                    {
                                        Console.WriteLine("Lista vazia!");
                                        Thread.Sleep(2000);
                                    }
                    
//                             if (listaPJ.Count > 0)
//                             {
//                                 foreach (PessoaJuridica cadaPessoa in listaPJ)
//                                 {
//                                     Console.WriteLine($@"
// Razão Social: {cadaPessoa.razaosocial}
// CNPJ: {cadaPessoa.cnpj}
// {cadaPessoa.endereco}
// Rendimento: {(cadaPessoa.rendimento).ToString("C")}
// Taxa de imposto a ser paga: {metodopj.PagarImposto(cadaPessoa.rendimento).ToString("C")}";
//                                 }
//                                     Console.WriteLine(@"Aperte 'Enter' para continuar!");
//                                     Console.ReadLine();
//                             } else
//                             {
//                                 Console.WriteLine("Lista vazia!");
//                                 Thread.Sleep(2000);
//                             }
                        break;

                        case "0":
                        break;

                        default:
                        Console.Clear();
                        Console.WriteLine($"Opção Inválida. Digite outra opção");
                        Thread.Sleep(2000);
                        break;
                    }
            } while(opcaoPJ != "0"); 

           
            Console.Clear();
           
            break;

        case "0":
            Console.Clear();
            Console.WriteLine("Obrigado por utilizar nosso sistema!");
            Thread.Sleep(2000);
            break;

        default:
            Console.Clear();
            Console.WriteLine($"Opção Inválida. Digite outra opção");
            Thread.Sleep(2000);
            break;
        }
} while (opcao != "0");




