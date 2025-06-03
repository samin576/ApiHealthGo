using System.Threading.Tasks;
using Dapper;
using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;
using MyFirstCRUD.infrastructure;
using MyFirstCRUD.Repository;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
namespace MyFirstCRUD
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            char op = '0';

            do
            {
                Console.WriteLine("1-Nação 2-Especialidade:");
                int resposta = int.Parse(Console.ReadLine());
                if (resposta == 1)
                {
                    Console.WriteLine("-- Cadastro de país --");
                    Console.WriteLine("C-CREATE");
                    Console.WriteLine("R-READ");
                    Console.WriteLine("U-UPDATE");
                    Console.WriteLine("D-DELETE\n");
                    Console.WriteLine("S-SAIR");
                    op = Console.ReadLine().ToUpper()[0];
                    switch (op)
                    {
                        case 'C':
                            await CreateNacao();
                            break;
                        case 'R':
                            await ReadNacao();
                            break;
                        case 'U':
                            await UpdateNacao();
                            break;
                        case 'D':
                            await DeleteNacao();
                            break;
                    }
                }
                else if (resposta == 2)
                {
                    Console.WriteLine("-- Cadastro de Especialidade --");
                    Console.WriteLine("C - CREATE");
                    Console.WriteLine("R - READ");
                    Console.WriteLine("U - UPDATE");
                    Console.WriteLine("D - DELETE\n");
                    Console.WriteLine("S - SAIR");

                    op = Console.ReadLine().ToUpper()[0];

                    switch (op)
                    {
                        case 'C':
                            await CreateEspecialidade();
                            break;
                        case 'R':
                            await ReadEspecialidade();
                            break;
                        case 'U':
                            await UpdateEspecialidade();
                            break;
                        case 'D':
                            await DeleteEspecialidade();
                            break;
                    }
                }
                Console.WriteLine("Pressione 'Enter' para continuar.");
                Console.ReadLine();
                Console.Clear();
            } while (op != 'S');
        }
        //ESPECIALIDADE
        static async Task ReadEspecialidade()
        {
            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            IEnumerable<EspecialidadeEntity> especialidadeList = await especialidadeRepository.GetAll();
            foreach (EspecialidadeEntity especialidade in especialidadeList)
            {
                Console.WriteLine($"Id: {especialidade.Id}");
                Console.WriteLine($"Nome: {especialidade.Nome}\n");
            }

        }

        static async Task CreateEspecialidade()
        {
            EspecialidadeInsertDTO especialidade = new EspecialidadeInsertDTO();

            Console.WriteLine("Digite o nome da Especialidade: ");
            especialidade.Nome = Console.ReadLine();

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Insert(especialidade);
            Console.WriteLine("Especialidade cadastrada com sucesso.");
        }

        static async Task DeleteEspecialidade()
        {
            await ReadEspecialidade();
            Console.WriteLine("Digite o Id que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Delete(id);

            Console.WriteLine("Especialidade deletada com sucesso.");
        }

        static async Task UpdateEspecialidade()
        {
            await ReadEspecialidade();
            Console.WriteLine("Digite o Id que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            EspecialidadeEntity especialidade = await especialidadeRepository.GetById(id);
            Console.WriteLine($"Digite um novo nome para {especialidade.Nome} ou aperte 'Enter' para manter: ");

            string newName = Console.ReadLine();
            if (newName != string.Empty)
            {
                especialidade.Nome = newName;
                Console.WriteLine("Nome alterado com sucesso.");
            }
        }
        //NACAO
        static async Task ReadNacao()
        {
            INacaoRepository nacaoRepository = new NacaoRepository();
            IEnumerable<NacaoEntity> nacaoList = await nacaoRepository.GetAll();
            foreach (var nation in nacaoList)
            {
                Console.WriteLine($"Id: {nation.Id}");
                Console.WriteLine($"Nome: {nation.Nome}");
            }
        }

        static async Task CreateNacao()
        {
            NacaoInsertDTO nacao = new NacaoInsertDTO();

            Console.WriteLine("Digite o nome:");
            nacao.Nome = Console.ReadLine();
            INacaoRepository nacaoRepository = new NacaoRepository();
            await nacaoRepository.Insert(nacao);
            Console.WriteLine("Nação cadastrada com sucesso!");
        }

        static async Task DeleteNacao()
        {
            await ReadNacao();
            Console.WriteLine("Digite o Id que quer deletar");
            int id = int.Parse(Console.ReadLine());
            INacaoRepository nacaoRepository = new NacaoRepository();
            await nacaoRepository.Delete(id);
            Console.WriteLine("Nação cadastrada com sucesso");
        }
        static async Task UpdateNacao()
        {
            await ReadNacao();
            Console.WriteLine("Digite o Id que quer alterar");
            int id = int.Parse(Console.ReadLine());
            INacaoRepository nacaoRepository = new NacaoRepository();
            NacaoEntity nacao = await nacaoRepository.GetById(id);
            Console.WriteLine($"Digite um novo nome para {nacao.Nome} ou aperte enter para deixar assim");
            string newName = Console.ReadLine();
            if (newName != string.Empty)
            {
                nacao.Nome = newName;
                await nacaoRepository.Update(nacao);
                Console.WriteLine("Nação alterada com sucesso!");
            }
        }
    }
}