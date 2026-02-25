namespace VHBurguer.DTOs.PromocaoDto
{
    public class LerPromocaoDto
    {
        public int PromocaoID { get; set; }
        public string Nome { get; set; } = null!;

        public DateTime DataExpiracao { get; set; }

        public bool StatusPromocao { get; set; }
    }
}
