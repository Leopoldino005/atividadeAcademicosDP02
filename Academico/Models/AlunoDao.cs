namespace Academico.Models
{
    public class AlunoDao
    {
        private static IList<Aluno> alunos = new List<Aluno>()
        {
            new Aluno()
            {
                AlunoID = 1,
                Nome = "Pedro",
                Email = "pedro@email.br",
                Telefone = "(21) 98765-4321",
                Endereco = "Condomínio Barra Bonita",
                Complemento = "Prédio Natural Surf",
                Bairro = "Recreio",
                Municipio = "Rio de Janeiro",
                Uf = "RJ",
                Cep = "21123-456"
            }
        };

        public AlunoDao()
        {
        }

        public async Task<Aluno> GravarAluno(Aluno aluno)
        {
            aluno.AlunoID = alunos.Select(a => a.AlunoID).DefaultIfEmpty(0).Max() + 1;
            alunos.Add(aluno);
            return await Task.FromResult(aluno);
        }

        public IList<Aluno> ObterTodos()
        {
            return alunos;
        }
    }
}
