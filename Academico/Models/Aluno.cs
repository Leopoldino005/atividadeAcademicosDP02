using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome completo do aluno.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório para contato.")]
        [EmailAddress(ErrorMessage = "Digite um endereço de e-mail válido (ex: nome@dominio.com).")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe um telefone para contato.")]
        [StringLength(15, MinimumLength = 14, ErrorMessage = "O telefone deve estar completo no formato (99) 99999-9999.")]
        [RegularExpression(@"^\(\d{2}\)\s?\d{4,5}-\d{4}$", ErrorMessage = "Formato inválido. Use (99) 99999-9999.")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o logradouro e número do endereço.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Informe o bairro.")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o município.")]
        [Display(Name = "Município")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "Selecione a UF.")]
        [StringLength(2, ErrorMessage = "Selecione um estado válido.")]
        [Display(Name = "UF")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O CEP deve conter 8 dígitos no formato 00000-000.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido. Utilize o formato 00000-000.")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        public Aluno()
        {
        }
    }
}
